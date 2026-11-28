using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

var cases = new (string Name, Action<JsonObject> Mutate, bool ExpectedValid, string? ExpectedMessage)[]
{
    ("complete independent manifest", _ => { }, true, null),
    ("missing reverse trace link", m => m["requirements"]![0]!["implementedBy"] = new JsonArray(), false, "reverse direction"),
    ("self-verification", m => m["verifications"]![0]!["verifier"] = "agent/developer", false, "not independent"),
    ("stale evidence", m => m["verifications"]![0]!["evidence"]![0]!["revision"] = 2, false, "stale evidence"),
    ("stale checkpoint", m => m["inputs"]![0]!["revision"] = 4, false, "checkpoint is stale"),
    ("explicit invalidation while working", m =>
    {
        m["gate"] = "working";
        m["inputs"]![0]!["revision"] = 4;
        m["checkpoint"]!["state"] = "invalidated";
        m["verifications"]![0]!["outcome"] = "pending";
        m["verifications"]![0]!["evidence"] = new JsonArray();
    }, true, null),
    ("open blocker at verified gate", m => m["syndromes"] = new JsonArray(new JsonObject
    {
        ["id"] = "SYN-001", ["code"] = "EVIDENCE_MISMATCH", ["severity"] = "blocker",
        ["owner"] = "agent/ta", ["state"] = "open",
        ["references"] = new JsonArray("requirement/demo@3")
    }), false, "unresolved blocker"),
    ("correction bound requires escalation", m =>
    {
        m["gate"] = "blocked";
        m["correction"] = new JsonObject
        {
            ["attempts"] = 3, ["maxAttempts"] = 3,
            ["scope"] = new JsonArray("component/demo@2"), ["state"] = "active"
        };
    }, false, "requires escalation"),
    ("unbounded correction limit", m => m["correction"]!["maxAttempts"] = 4, false, "between 1 and 3")
};

var failures = 0;
foreach (var test in cases)
{
    var manifest = CreateManifest();
    test.Mutate(manifest);
    var path = Path.Combine(Path.GetTempPath(), $"lsi-{Guid.NewGuid():N}.json");
    try
    {
        File.WriteAllText(path, manifest.ToJsonString(new JsonSerializerOptions { WriteIndented = true }));
        var errors = IntegrityManifestValidator.Validate(path);
        var passed = test.ExpectedValid ? errors.Count == 0 : errors.Any(x => x.Contains(test.ExpectedMessage!, StringComparison.Ordinal));
        Console.WriteLine($"{(passed ? "PASS" : "FAIL")} {test.Name}");
        if (!passed)
        {
            failures++;
            foreach (var error in errors)
                Console.Error.WriteLine(error);
        }
    }
    finally
    {
        File.Delete(path);
    }
}

var examplePath = Path.Combine(AppContext.BaseDirectory, "change-set.lsi.json");
var exampleErrors = IntegrityManifestValidator.Validate(examplePath);
var examplePassed = exampleErrors.Count == 0;
Console.WriteLine($"{(examplePassed ? "PASS" : "FAIL")} documented manifest example");
if (!examplePassed)
{
    failures++;
    foreach (var error in exampleErrors)
        Console.Error.WriteLine(error);
}

Console.WriteLine($"{cases.Length + 1 - failures}/{cases.Length + 1} LSI tests passed.");
return failures == 0 ? 0 : 1;

static JsonObject CreateManifest()
{
    const string inputHash = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    var inputs = new JsonArray(new JsonObject
    {
        ["address"] = "requirement/demo",
        ["revision"] = 3,
        ["sha256"] = inputHash
    });
    return new JsonObject
    {
        ["schemaVersion"] = 1,
        ["changeSet"] = "changeset/demo-001",
        ["gate"] = "verified",
        ["inputs"] = inputs,
        ["requirements"] = new JsonArray(new JsonObject
        {
            ["id"] = "REQ-001",
            ["input"] = "requirement/demo",
            ["implementedBy"] = new JsonArray("IMPL-001"),
            ["verifiedBy"] = new JsonArray("TEST-001")
        }),
        ["implementations"] = new JsonArray(new JsonObject
        {
            ["id"] = "IMPL-001",
            ["artifact"] = "component/demo@2",
            ["author"] = "agent/developer",
            ["satisfies"] = new JsonArray("REQ-001")
        }),
        ["verifications"] = new JsonArray(new JsonObject
        {
            ["id"] = "TEST-001",
            ["artifact"] = "test/demo@4",
            ["verifier"] = "agent/test-developer",
            ["outcome"] = "passed",
            ["verifies"] = new JsonArray("REQ-001"),
            ["evidence"] = new JsonArray(new JsonObject
            {
                ["input"] = "requirement/demo",
                ["revision"] = 3,
                ["sha256"] = inputHash
            })
        }),
        ["syndromes"] = new JsonArray(),
        ["correction"] = new JsonObject
        {
            ["attempts"] = 0,
            ["maxAttempts"] = 3,
            ["scope"] = new JsonArray(),
            ["state"] = "closed"
        },
        ["checkpoint"] = new JsonObject
        {
            ["state"] = "valid",
            ["fingerprint"] = Fingerprint(inputs)
        }
    };
}

static string Fingerprint(JsonArray inputs)
{
    var canonical = string.Concat(inputs
        .Select(x => x!.AsObject())
        .OrderBy(x => (string)x["address"]!, StringComparer.Ordinal)
        .Select(x => $"{(string)x["address"]!}@{(int)x["revision"]!}:{((string)x["sha256"]!).ToLowerInvariant()}\n"));
    return "sha256:" + Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(canonical))).ToLowerInvariant();
}
