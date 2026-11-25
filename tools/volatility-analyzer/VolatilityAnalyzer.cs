using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace VolatilityAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Assume repository root is current directory.
            string repoRoot = Directory.GetCurrentDirectory();
            // Path to the AddOns folders (sibling repo vc.App.Latimessis).
            string addOnsPath = Path.Combine(repoRoot, "..", "vc.App.Latimessis", "tools", "Dsuite", "AddOns");
            if (!Directory.Exists(addOnsPath))
            {
                Console.Error.WriteLine($"AddOns path not found: {addOnsPath}");
                Environment.Exit(1);
            }

            string outputDir = Path.Combine(repoRoot, "docs", "volatility");
            Directory.CreateDirectory(outputDir);

            foreach (var dir in Directory.GetDirectories(addOnsPath))
            {
                var gateName = Path.GetFileName(dir);
                var report = new
                {
                    gate = gateName,
                    BoundaryViolations = new List<object>() // empty for now; future analysis can populate
                };
                string json = JsonSerializer.Serialize(report, new JsonSerializerOptions { WriteIndented = true });
                string outPath = Path.Combine(outputDir, $"volatility-analysis-{gateName}.json");
                File.WriteAllText(outPath, json);
                Console.WriteLine($"Wrote {outPath}");
            }
        }
    }
}
