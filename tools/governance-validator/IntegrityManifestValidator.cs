using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

public static class IntegrityManifestValidator
{
    private static readonly Regex HashPattern = new("^[0-9a-f]{64}$", RegexOptions.CultureInvariant);

    public static List<string> Validate(string path)
    {
        IntegrityManifest? manifest;
        try
        {
            manifest = JsonSerializer.Deserialize<IntegrityManifest>(File.ReadAllText(path), new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException)
        {
            return [$"{path}: unable to read LSI manifest ({ex.Message})"];
        }

        if (manifest is null)
            return [$"{path}: LSI manifest is empty"];
        if (manifest.Inputs is null || manifest.Requirements is null || manifest.Implementations is null
            || manifest.Verifications is null || manifest.Syndromes is null
            || manifest.Correction is null || manifest.Checkpoint is null
            || manifest.Inputs.Any(x => x is null)
            || manifest.Requirements.Any(x => x is null || x.ImplementedBy is null || x.VerifiedBy is null)
            || manifest.Implementations.Any(x => x is null || x.Satisfies is null)
            || manifest.Verifications.Any(x => x is null || x.Verifies is null || x.Evidence is null)
            || manifest.Verifications.Where(x => x is not null).SelectMany(x => x.Evidence ?? []).Any(x => x is null)
            || manifest.Syndromes.Any(x => x is null || x.References is null)
            || manifest.Correction?.Scope is null)
            return [$"{path}: LSI manifest contains a missing or null required object or collection"];

        var errors = new List<string>();
        void Error(string message)
        {
            var code = message.Contains("trace", StringComparison.OrdinalIgnoreCase) || message.Contains("requirement", StringComparison.OrdinalIgnoreCase)
                ? "LSI_TRACE"
                : message.Contains("evidence", StringComparison.OrdinalIgnoreCase) || message.Contains("hash", StringComparison.OrdinalIgnoreCase)
                    ? "LSI_EVIDENCE"
                    : message.Contains("checkpoint", StringComparison.OrdinalIgnoreCase)
                        ? "LSI_CHECKPOINT"
                        : message.Contains("correction", StringComparison.OrdinalIgnoreCase)
                            ? "LSI_CORRECTION"
                            : message.Contains("syndrome", StringComparison.OrdinalIgnoreCase) || message.Contains("blocker", StringComparison.OrdinalIgnoreCase)
                                ? "LSI_SYNDROME"
                                : message.Contains("independent", StringComparison.OrdinalIgnoreCase)
                                    ? "LSI_INDEPENDENCE"
                                    : "LSI_MANIFEST";
            errors.Add($"{path}: [{code}] {message}");
        }

        if (manifest.SchemaVersion != 1)
            Error("schemaVersion must be 1");
        if (string.IsNullOrWhiteSpace(manifest.ChangeSet))
            Error("changeSet is required");
        if (manifest.Gate is not ("working" or "verified" or "blocked"))
            Error("gate must be working, verified, or blocked");
        if (manifest.Inputs.Count == 0)
            Error("at least one protected input is required");

        var inputs = new Dictionary<string, IntegrityInput>(StringComparer.Ordinal);
        foreach (var input in manifest.Inputs)
        {
            if (string.IsNullOrWhiteSpace(input.Address) || input.Revision < 1 || !IsHash(input.Sha256))
            {
                Error($"input '{input.Address}' must have an address, positive revision, and lowercase SHA-256 hash");
                continue;
            }
            if (!inputs.TryAdd(input.Address, input))
                Error($"duplicate input address '{input.Address}'");
        }

        var requirements = UniqueBy(manifest.Requirements, x => x.Id);
        var implementations = UniqueBy(manifest.Implementations, x => x.Id);
        var verifications = UniqueBy(manifest.Verifications, x => x.Id);
        if (requirements.Count != manifest.Requirements.Count)
            Error("requirement identifiers must be unique and nonempty");
        if (implementations.Count != manifest.Implementations.Count)
            Error("implementation identifiers must be unique and nonempty");
        if (verifications.Count != manifest.Verifications.Count)
            Error("verification identifiers must be unique and nonempty");

        foreach (var requirement in manifest.Requirements)
        {
            if (string.IsNullOrWhiteSpace(requirement.Id))
                Error("requirement id is required");
            if (string.IsNullOrWhiteSpace(requirement.Input) || !inputs.ContainsKey(requirement.Input))
                Error($"requirement '{requirement.Id}' references unknown input '{requirement.Input}'");
            if (HasDuplicates(requirement.ImplementedBy) || HasDuplicates(requirement.VerifiedBy))
                Error($"requirement '{requirement.Id}' contains duplicate trace links");
        }

        foreach (var implementation in manifest.Implementations)
        {
            if (string.IsNullOrWhiteSpace(implementation.Artifact) || string.IsNullOrWhiteSpace(implementation.Author))
                Error($"implementation '{implementation.Id}' must identify its artifact and author");
            if (implementation.Satisfies.Count == 0)
                Error($"implementation '{implementation.Id}' must link to a requirement");
            if (HasDuplicates(implementation.Satisfies))
                Error($"implementation '{implementation.Id}' contains duplicate requirement links");
            foreach (var requirementId in implementation.Satisfies)
                if (!requirements.ContainsKey(requirementId))
                    Error($"implementation '{implementation.Id}' references unknown requirement '{requirementId}'");
        }

        foreach (var verification in manifest.Verifications)
        {
            if (string.IsNullOrWhiteSpace(verification.Artifact) || string.IsNullOrWhiteSpace(verification.Verifier))
                Error($"verification '{verification.Id}' must identify its artifact and verifier");
            if (verification.Outcome is not ("pending" or "passed" or "failed"))
                Error($"verification '{verification.Id}' has an invalid outcome");
            if (verification.Verifies.Count == 0)
                Error($"verification '{verification.Id}' must link to a requirement");
            if (HasDuplicates(verification.Verifies))
                Error($"verification '{verification.Id}' contains duplicate requirement links");
            foreach (var requirementId in verification.Verifies)
                if (!requirements.ContainsKey(requirementId))
                    Error($"verification '{verification.Id}' references unknown requirement '{requirementId}'");

            var evidenceInputs = new HashSet<string>(StringComparer.Ordinal);
            foreach (var evidence in verification.Evidence)
            {
                if (string.IsNullOrWhiteSpace(evidence.Input))
                {
                    Error($"verification '{verification.Id}' evidence input is required");
                    continue;
                }
                if (!evidenceInputs.Add(evidence.Input))
                    Error($"verification '{verification.Id}' contains duplicate evidence for '{evidence.Input}'");
                if (!inputs.TryGetValue(evidence.Input, out var current))
                {
                    Error($"verification '{verification.Id}' references unknown input '{evidence.Input}'");
                    continue;
                }
                if (evidence.Revision != current.Revision || !string.Equals(evidence.Sha256, current.Sha256, StringComparison.Ordinal))
                    Error($"verification '{verification.Id}' has stale evidence for '{evidence.Input}'");
            }

            foreach (var requirementId in verification.Verifies)
            {
                if (!requirements.TryGetValue(requirementId, out var requirement) || !inputs.ContainsKey(requirement.Input))
                    continue;
                if (verification.Outcome == "passed" && !evidenceInputs.Contains(requirement.Input))
                    Error($"verification '{verification.Id}' omits input evidence for requirement '{requirementId}'");
            }
        }

        foreach (var requirement in manifest.Requirements)
        {
            var expectedImplementations = manifest.Implementations.Where(x => x.Satisfies.Contains(requirement.Id, StringComparer.Ordinal)).Select(x => x.Id);
            var expectedVerifications = manifest.Verifications.Where(x => x.Verifies.Contains(requirement.Id, StringComparer.Ordinal)).Select(x => x.Id);
            if (!SameSet(requirement.ImplementedBy, expectedImplementations))
                Error($"requirement '{requirement.Id}' implementation links disagree in the reverse direction");
            if (!SameSet(requirement.VerifiedBy, expectedVerifications))
                Error($"requirement '{requirement.Id}' verification links disagree in the reverse direction");

            foreach (var verification in manifest.Verifications.Where(x => x.Verifies.Contains(requirement.Id, StringComparer.Ordinal)))
            {
                foreach (var implementation in manifest.Implementations.Where(x => x.Satisfies.Contains(requirement.Id, StringComparer.Ordinal)))
                    if (string.Equals(implementation.Author, verification.Verifier, StringComparison.OrdinalIgnoreCase))
                        Error($"verification '{verification.Id}' is not independent of implementation '{implementation.Id}'");
            }
        }

        var openBlockers = manifest.Syndromes.Where(x => x.Severity == "blocker" && x.State == "open").ToArray();
        var syndromeIds = new HashSet<string>(StringComparer.Ordinal);
        foreach (var syndrome in manifest.Syndromes)
        {
            if (string.IsNullOrWhiteSpace(syndrome.Id) || !syndromeIds.Add(syndrome.Id))
                Error($"syndrome id '{syndrome.Id}' is missing or duplicated");
            if (string.IsNullOrWhiteSpace(syndrome.Code) || string.IsNullOrWhiteSpace(syndrome.Owner) || syndrome.References.Count == 0)
                Error($"syndrome '{syndrome.Id}' must include code, owner, and artifact references");
            if (syndrome.Severity is not ("blocker" or "warning") || syndrome.State is not ("open" or "resolved"))
                Error($"syndrome '{syndrome.Id}' has an invalid severity or state");
        }

        var correction = manifest.Correction;
        if (correction.MaxAttempts is < 1 or > 3)
            Error("correction.maxAttempts must be between 1 and 3");
        if (correction.Attempts < 0 || correction.Attempts > correction.MaxAttempts)
            Error("correction.attempts exceeds its configured bound");
        if (correction.Attempts > 0 && correction.Scope.Count == 0)
            Error("correction scope is required when correction has been attempted");
        var scopedArtifacts = manifest.Implementations.SelectMany(x => new[] { x.Id, x.Artifact })
            .Concat(manifest.Verifications.SelectMany(x => new[] { x.Id, x.Artifact }))
            .ToHashSet(StringComparer.Ordinal);
        foreach (var scope in correction.Scope)
            if (!scopedArtifacts.Contains(scope))
                Error($"correction scope references unknown artifact '{scope}'");
        if (correction.State is not ("active" or "closed" or "escalated"))
            Error("correction.state must be active, closed, or escalated");
        if (correction.Attempts == correction.MaxAttempts && correction.State != "escalated")
            Error("reaching the correction bound requires escalation");
        if (correction.State == "escalated" && manifest.Gate != "blocked")
            Error("escalated correction requires a blocked gate");

        if (manifest.Checkpoint.State is not ("valid" or "invalidated"))
            Error("checkpoint.state must be valid or invalidated");
        var actualFingerprint = Fingerprint(manifest.Inputs);
        if (manifest.Checkpoint.State == "valid" && !string.Equals(manifest.Checkpoint.Fingerprint, actualFingerprint, StringComparison.Ordinal))
            Error("checkpoint is stale; invalidate it after protected inputs change");
        if (manifest.Gate == "verified")
        {
            if (manifest.Requirements.Count == 0)
                Error("verified gate requires at least one requirement");
            foreach (var requirement in manifest.Requirements)
            {
                if (requirement.ImplementedBy.Count == 0)
                    Error($"verified gate has no implementation for requirement '{requirement.Id}'");
                if (requirement.VerifiedBy.Count == 0)
                    Error($"verified gate has no verification for requirement '{requirement.Id}'");
            }
            if (manifest.Verifications.Any(x => x.Outcome != "passed"))
                Error("verified gate requires every verification outcome to be passed");
            if (openBlockers.Length > 0)
                Error("verified gate is blocked by unresolved blocker syndromes");
            if (manifest.Checkpoint.State != "valid")
                Error("verified gate requires a current valid checkpoint");
            if (correction.State == "active")
                Error("verified gate cannot have active correction");
        }
        if (manifest.Gate == "blocked" && openBlockers.Length == 0 && correction.State != "escalated")
            Error("blocked gate requires an open blocker syndrome or escalated correction");

        return errors;
    }

    private static Dictionary<string, T> UniqueBy<T>(IEnumerable<T> values, Func<T, string> key)
    {
        var result = new Dictionary<string, T>(StringComparer.Ordinal);
        foreach (var value in values)
        {
            var id = key(value);
            if (!string.IsNullOrWhiteSpace(id))
                result.TryAdd(id, value);
        }
        return result;
    }

    private static bool IsHash(string? value) => value is not null && HashPattern.IsMatch(value);

    private static bool HasDuplicates(IEnumerable<string> values)
    {
        var seen = new HashSet<string>(StringComparer.Ordinal);
        return values.Any(x => !seen.Add(x));
    }

    private static bool SameSet(IEnumerable<string> left, IEnumerable<string> right) =>
        new HashSet<string>(left, StringComparer.Ordinal).SetEquals(right);

    private static string Fingerprint(IEnumerable<IntegrityInput> inputs)
    {
        var canonical = string.Concat(inputs
            .OrderBy(x => x.Address, StringComparer.Ordinal)
            .Select(x => $"{x.Address}@{x.Revision}:{x.Sha256?.ToLowerInvariant()}\n"));
        return "sha256:" + Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(canonical))).ToLowerInvariant();
    }
}

internal sealed class IntegrityManifest
{
    public required int SchemaVersion { get; init; }
    public required string ChangeSet { get; init; }
    public required string Gate { get; init; }
    public required List<IntegrityInput> Inputs { get; init; }
    public required List<IntegrityRequirement> Requirements { get; init; }
    public required List<IntegrityImplementation> Implementations { get; init; }
    public required List<IntegrityVerification> Verifications { get; init; }
    public required List<IntegritySyndrome> Syndromes { get; init; }
    public required IntegrityCorrection Correction { get; init; }
    public required IntegrityCheckpoint Checkpoint { get; init; }
}

internal sealed class IntegrityInput
{
    public required string Address { get; init; }
    public required int Revision { get; init; }
    public required string Sha256 { get; init; }
}

internal sealed class IntegrityRequirement
{
    public required string Id { get; init; }
    public required string Input { get; init; }
    public required List<string> ImplementedBy { get; init; }
    public required List<string> VerifiedBy { get; init; }
}

internal sealed class IntegrityImplementation
{
    public required string Id { get; init; }
    public required string Artifact { get; init; }
    public required string Author { get; init; }
    public required List<string> Satisfies { get; init; }
}

internal sealed class IntegrityVerification
{
    public required string Id { get; init; }
    public required string Artifact { get; init; }
    public required string Verifier { get; init; }
    public required string Outcome { get; init; }
    public required List<string> Verifies { get; init; }
    public required List<IntegrityEvidence> Evidence { get; init; }
}

internal sealed class IntegrityEvidence
{
    public required string Input { get; init; }
    public required int Revision { get; init; }
    public required string Sha256 { get; init; }
}

internal sealed class IntegritySyndrome
{
    public required string Id { get; init; }
    public required string Code { get; init; }
    public required string Severity { get; init; }
    public required string Owner { get; init; }
    public required string State { get; init; }
    public required List<string> References { get; init; }
}

internal sealed class IntegrityCorrection
{
    public required int Attempts { get; init; }
    public required int MaxAttempts { get; init; }
    public required List<string> Scope { get; init; }
    public required string State { get; init; }
}

internal sealed class IntegrityCheckpoint
{
    public required string State { get; init; }
    public required string Fingerprint { get; init; }
}
