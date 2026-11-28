---
title: Logical Software Integrity
address: governance/validation/logical-software-integrity
type: governance
owner: agent/ceo
status: active
aliases: [logical-software-integrity, lsi]
tags: [governance, integrity, traceability, verification]
version: 1.0.0
last_updated: 2026-11-27
---

# Logical Software Integrity

Logical Software Integrity (LSI) is a Change Set gate over authoritative requirements, design, implementation, verification, and recovery evidence. It extends existing ownership, revision, Change Set, verification, and durable-context mechanisms. It does not change VBD decomposition or transfer authority between roles.

## Gate contract

A work item carries one version-controlled `*.lsi.json` manifest for its Change Set. Validate it with:

```text
dotnet run --project tools/governance-validator/GovernanceValidator.csproj -- --integrity path/to/change-set.lsi.json
```

The manifest schema version is 1:

| Field | Contract |
|---|---|
| `schemaVersion` | Integer `1`. |
| `changeSet` | Address of the owning Change Set. |
| `gate` | `working`, `verified`, or `blocked`. |
| `inputs` | Exact authoritative input addresses, revisions, and lowercase SHA-256 hashes (requirements, contracts, and design baselines in scope). |
| `requirements` | Requirement identifiers, their input address, and `implementedBy` and `verifiedBy` arrays. |
| `implementations` | Implementation artifact address, author identity, and `satisfies` requirement identifiers. |
| `verifications` | Verification artifact address, verifier identity, outcome (`pending`, `passed`, or `failed`), `verifies` identifiers, and revision-pinned evidence. |
| `syndromes` | Findings with unique `id`, `code`, `severity` (`blocker` or `warning`), accountable `owner`, `state` (`open` or `resolved`), and artifact `references`. |
| `correction` | `attempts`, `maxAttempts` (1–3), affected artifact `scope`, and `state` (`active`, `closed`, or `escalated`). |
| `checkpoint` | `state` (`valid` or `invalidated`) and fingerprint of the exact input set. |

Every requirement lists the implementation and verification identifiers that point back to it; every implementation and verification lists the requirements it covers. Both directions must agree. A `verified` gate requires implementation and passing verification for every requirement, passing evidence for current input revisions/hashes, and a verifier identity distinct from each implementation author for that requirement. The Test Architect retains verification-design and acceptance authority.

The fingerprint is SHA-256 over UTF-8 lines sorted by ordinal address:

```text
address@revision:lowercase-sha256\n
```

The checkpoint fingerprint is `sha256:<hex>` over the concatenated lines. If it differs from current inputs while state is `valid`, validation fails. When an input changes, the PM marks dependent checkpoints `invalidated`, records affected work/evidence, pauses that work, and issues a revised assignment before resumption. Verification evidence is rerun against the revised baseline.

## Syndromes and bounded correction

A syndrome is a durable, addressable integrity finding, not a new authority path. Its owner is the existing artifact owner. An unresolved blocker prevents `verified`. Route requirement changes to the PO, system design to the SA, component design and implementation to the owning AA/DA, and verification to the TA/Test Dev under existing escalation rules.

Correction is limited to its listed artifact scope and no more than three attempts. Reaching the configured bound requires `escalated` state and a `blocked` gate. Correction cannot silently alter requirements, architecture, verification design, or ownership. Repeated or cross-boundary failures stop automated correction and return to the responsible owner and PM.

## Evidence and trust boundary

The validator checks manifest shape, exact revision/hash references, bidirectional traceability, reviewer separation, syndrome disposition, correction bounds, and checkpoint freshness. It does not authenticate identities or independently reproduce a build. The consuming CI provider must bind the manifest revision and verification run to authenticated actors and immutable run evidence. Protect required checks so local CLI output alone cannot authorize integration.

## Ownership and sequence

The PM owns assignment, manifest association, pause/resume, and Change Set sequencing. PO, SA, AA, TA, DA, and Test Dev retain existing decision rights. Evidence is independent of implementation; the work owner does not self-approve verification. Conflicts and exceptions use [authority and escalation](../authority/authority-and-escalation.md).

1. Freeze and hash approved inputs; identify requirements, VBD boundaries, owners, and acceptance tests.
2. Establish both-direction trace links and implementation scope before work becomes active.
3. Implement within scope. Record findings as syndromes; pause when an input revision changes.
4. Independently verify against exact revisions and hashes; close or escalate findings.
5. Invalidate dependent checkpoints on revision/dependency changes. Rehydrate from authoritative artifacts and replay only after PM reassignment.
6. Set `gate` to `verified` only when checks pass. Product acceptance remains with the PO.

## Existing mechanism reuse

LSI is carried by the Change Set and provenance/revision model, uses existing verification roles and workflows, records syndromes through owned artifacts and decisions, and treats checkpoints as disposable derived state under [durable context and rehydration](../infrastructure/durable-context-and-rehydration.md). It creates no parallel role, approval ladder, work queue, or decomposition.

See [required integrations](integration-requirements.md) for follow-up contracts in `vc.Agentic` and `vc.Ifx`.
