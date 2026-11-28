using System.Text.RegularExpressions;
using YamlDotNet.RepresentationModel;

if (args.Length == 2 && args[0] == "--integrity")
{
    var integrityErrors = IntegrityManifestValidator.Validate(args[1]);
    if (integrityErrors.Count > 0)
    {
        Console.Error.WriteLine(string.Join('\n', integrityErrors));
        return 1;
    }
    Console.WriteLine("LSI manifest validated successfully.");
    return 0;
}
if (args.Length > 0 && args[0] == "--integrity")
{
    Console.Error.WriteLine("Usage: GovernanceValidator --integrity <manifest.json>");
    return 2;
}

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
                var projDir = Path.GetDirectoryName(proj) ?? "";
                var fullPath = Path.IsPathRooted(hintPath) ? hintPath : Path.Combine(projDir, hintPath);
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

if (errors.Count > 0)
{
    Console.Error.WriteLine(string.Join('\n', errors));
    return 1;
}
Console.WriteLine("All markdown front‑matter validated successfully.");
Console.WriteLine("All template JSON validated successfully.");
return 0;


