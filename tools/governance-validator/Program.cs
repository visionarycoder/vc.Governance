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

if (errors.Count > 0)
{
    Console.Error.WriteLine(string.Join('\n', errors));
    return 1;
}

Console.WriteLine("All markdown front‑matter validated successfully.");
return 0;

