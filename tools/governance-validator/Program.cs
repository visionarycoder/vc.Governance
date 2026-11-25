using System.Text.RegularExpressions;
using YamlDotNet.RepresentationModel;

string[] requiredKeys = ["title", "address", "owner", "version", "last_updated"];
var frontMatterRegex = new Regex(@"^---\s*(.*?)\s*---", RegexOptions.Singleline);

var root = args.Length > 0 ? args[0] : ".";
var files = Directory.GetFiles(root, "*.md", SearchOption.AllDirectories);
var errors = new List<string>();
foreach (var file in files)
{
    var text = File.ReadAllText(file);
    var frontMatterMatch = frontMatterRegex.Match(text);
    if (! frontMatterMatch.Success)
    {
        errors.Add($"{file}: missing front‑matter delimiter");
        continue;
    }

    var yaml = new YamlStream();
    yaml.Load(new StringReader(frontMatterMatch.Groups[1].Value));
    var mapping = (YamlMappingNode) yaml.Documents[0].RootNode;
    var keys = new HashSet<string>();
    foreach (var entry in mapping.Children)
    {
        keys.Add(entry.Key.ToString());
    }
    foreach (var req in requiredKeys)
    {
        if (!keys.Contains(req))
            errors.Add($"{file}: missing required key '{req}'");
    }
}

var jsonFiles = Directory.GetFiles(root, "*.json*", SearchOption.AllDirectories)
    .Where(f => (f.EndsWith(".json") || f.EndsWith(".jsonl"))
        && f.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).Contains("templates")
        && !f.Contains($"{Path.DirectorySeparatorChar}obj{Path.DirectorySeparatorChar}"));
foreach (var file in jsonFiles)
{
    if (file.EndsWith(".jsonl"))
    {
        var lines = File.ReadAllLines(file);
        for (var i = 0; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i])) continue;
            try { System.Text.Json.JsonDocument.Parse(lines[i]).Dispose(); }
            catch (System.Text.Json.JsonException ex) { errors.Add($"{file}:{i + 1}: invalid JSON ({ex.Message})"); }
        }
    }
    else
    {
        try { System.Text.Json.JsonDocument.Parse(File.ReadAllText(file)).Dispose(); }
        catch (System.Text.Json.JsonException ex) { errors.Add($"{file}: invalid JSON ({ex.Message})"); }
    }
}

// Dependency reference verification (generic)
// Scan all .csproj files for <Reference> entries with HintPath and ensure the target file exists.
var csprojFiles = Directory.GetFiles(root, "*.csproj", SearchOption.AllDirectories);
foreach (var proj in csprojFiles)
{
    try
    {
        var xml = new System.Xml.XmlDocument();
        xml.Load(proj);
        var nsMgr = new System.Xml.XmlNamespaceManager(xml.NameTable);
        nsMgr.AddNamespace("msb", "http://schemas.microsoft.com/developer/msbuild/2003");
        var nodes = xml.SelectNodes("//msb:Reference/msb:HintPath", nsMgr);
        if (nodes != null)
        {
            foreach (System.Xml.XmlNode node in nodes)
            {
                var hintPath = node.InnerText;
                var fullPath = Path.IsPathRooted(hintPath) ? hintPath : Path.Combine(Path.GetDirectoryName(proj), hintPath);
                if (!File.Exists(fullPath))
                {
                    errors.Add($"{proj}: missing referenced assembly at '{fullPath}'");
                }
            }
        }
    }
    catch (Exception ex)
    {
        errors.Add($"{proj}: unable to parse for references ({ex.Message})");
    }
}

// Gate folder and project file existence validation
var gateRoot = Path.Combine(root, "..", "vc.App.Latimessis", "tools", "Dsuite", "AddOns");
if (Directory.Exists(gateRoot))
{
    var gateDirs = Directory.GetDirectories(gateRoot);
    foreach (var dir in gateDirs)
    {
        var csproj = Path.Combine(dir, Path.GetFileName(dir) + ".csproj");
        var cs = Path.Combine(dir, Path.GetFileName(dir) + ".cs");
        if (!File.Exists(csproj) || !File.Exists(cs))
            errors.Add($"{dir}: missing .csproj or .cs file");
        else if (new FileInfo(csproj).Length == 0 || new FileInfo(cs).Length == 0)
            errors.Add($"{dir}: .csproj or .cs file is empty");
    }
}
else
{
    errors.Add($"Gate root not found: {gateRoot}");
}


var volatilityJson = Directory.GetFiles(root, "volatility-analysis-*.json", SearchOption.AllDirectories);
foreach (var file in volatilityJson)
{
    try {
        var doc = System.Text.Json.JsonDocument.Parse(File.ReadAllText(file));
        var rootElem = doc.RootElement;
        if (rootElem.TryGetProperty("BoundaryViolations", out var violations) && violations.GetArrayLength() > 0)
        {
            errors.Add($"{file}: found {violations.GetArrayLength()} boundary violation(s)");
        }
    } catch (System.Text.Json.JsonException ex) {
        errors.Add($"{file}: invalid JSON ({ex.Message})");
    }
}


