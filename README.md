---
title: Software Delivery Governance
address: governance
owner: agent/pm
version: 1.11.0
last_updated: 2026-11-27
---

# Software Delivery Governance

![Validation CI](https://github.com/visionarycoder/vc.Governance/actions/workflows/software-delivery.yml/badge.svg)

**Current version: 1.11.0** (see [VERSION.md](VERSION.md))

## Purpose

`vc.Governance` is a documentation-and-tooling repository that defines how software is delivered under the Volatility-Based Decomposition (VBD) method. It is **process-only**: it contains no product code. It specifies who holds authority, how work and artifacts are governed, what standards implementations must meet, and provides tooling that keeps the Markdown knowledge base consistent.

## What the repository contains

| Path | Contents |
|------|----------|
| `docs/` | **All Markdown describing the governance framework lives here**, split into the folders below. |
| `docs/software-delivery-governance/` | The governance model: `principles`, `roles`, `authority` (ownership, escalation, councils, subagents/swarms), `artifacts` (lifecycle, decision records, change sets, revisions, provenance), `workflows`, `work`, `messaging`, `infrastructure` (address resolution), and `validation`. Entry point: `software-delivery-governance.md`. |
| `docs/the-method/` | The project-design method: ontology, requirements analysis, decomposition, composition, detailed design, design validation, activities and dependencies, project network, effort estimation, scheduling and risk, and the governance specification. |
| `docs/implementation-standards/` | Engineering standards: `architecture`, `code-quality`, `data-and-security`, `framework-guidance`, `verification-and-delivery`, review `checklists`, and `templates`. Entry point: `implementation-standards.md`. |
| `templates/` | `decision-records/` (decision record template) and `agent-context/` (durable agent context shapes) and `logical-software-integrity/` (an executable LSI manifest example). |
| `scripts/` | Helper scripts, e.g. `new-record.sh`, which scaffolds a record from the template. |
| `vc.Governance.slnx` | Visual Studio solution: opens both tools plus the key docs, scripts and templates as solution items. |
| `tools/` | .NET console tools (`governance-validator`, `link-checker`) aggregated by `GovernanceTools.slnx`; see [tools/TOOLS.md](tools/TOOLS.md). |
| Logical Software Integrity | LSI policy, manifest validator, automated tests, and integration contracts. |
| `logs/gov-actions.jsonl` | Optional, version-controlled append-only log of governance actions. |
| `.github/workflows/software-delivery.yml` | CI that runs the validator and link checker. |
| `docs/ONBOARDING.md` | Setup and contributor workflow guide. |

## Documentation conventions

Every Markdown file must start with YAML front matter containing `title`, `address`, `owner`, `version`, and `last_updated`. The validator checks this recursively across the repository (including this README and the tooling docs), and the link checker verifies that wikilinks resolve. The repository version lives in [VERSION.md](VERSION.md); bump it and `last_updated` when making a release-level change. Validate an LSI manifest with `dotnet run --project tools/governance-validator/GovernanceValidator.csproj -- --integrity <manifest.json>`.

## Prerequisites

- Git
- .NET 11 SDK and .NET 8 runtime ([download](https://dotnet.microsoft.com/download))
- Any terminal able to run `dotnet` (PowerShell, Bash, CMD)

## Quick start

From the repository root:

```bash
dotnet run --project tools/governance-validator/GovernanceValidator.csproj -- .
dotnet run --project tools/link-checker/LinkChecker.csproj -- .
```

Success prints:

```
All markdown front-matter validated successfully.
All wikilinks resolved.
```

Failures are written to stderr with the file path and problem. CI runs the same checks on each push.

## Common tasks

- **Validate an LSI manifest:** use the `--integrity` command above; see [Logical Software Integrity](docs/software-delivery-governance/validation/logical-software-integrity.md).
- **Add a decision record:** copy `templates/decision-records/template.md` (or run `scripts/new-record.sh`), fill in the front matter, edit, and commit. See [ONBOARDING.md](docs/ONBOARDING.md).
- **Log a governance action:** append a JSON line to `logs/gov-actions.jsonl`.
- **Add or change a document:** include complete front matter, keep links valid, then run both tools before committing.

## Where to start reading

1. [ONBOARDING.md](docs/ONBOARDING.md) – setup and workflow.
2. [software-delivery-governance/software-delivery-governance.md](docs/software-delivery-governance/software-delivery-governance.md) – the governance model.
3. [the-method/](docs/the-method/) – the design method.
4. [implementation-standards/implementation-standards.md](docs/implementation-standards/implementation-standards.md) – engineering standards.
