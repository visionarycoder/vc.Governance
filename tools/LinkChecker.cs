using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Program
{
    static int Main(string[] args)
    {
        var root = args.Length > 0 ? args[0] : ".";
        var files = Directory.GetFiles(root, "*.md", SearchOption.AllDirectories);
        var missing = new List<string>();
        var linkPattern = new Regex(@"\[\[([^\]]+)\]\]");
        var existing = new HashSet<string>();
        foreach (var f in files)
            existing.Add(Path.GetFileNameWithoutExtension(f));
        foreach (var f in files)
        {
            var text = File.ReadAllText(f);
            foreach (Match m in linkPattern.Matches(text))
            {
                var target = m.Groups[1].Value;
                if (!existing.Contains(target))
                    missing.Add($"{f}: broken link [[{target}]]");
            }
        }
        if (missing.Count > 0)
        {
            Console.Error.WriteLine(string.Join('\n', missing));
            return 1;
        }
        Console.WriteLine("All wikilinks resolved.");
        return 0;
    }
}
