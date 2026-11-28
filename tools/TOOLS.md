---
title: Governance Tools Repository
address: governance/tools
owner: agent/pm
version: 1.6.0
last_updated: 2026-11-27
---

# Governance Tools Repository

This repository contains the command‑line tools used by the **vc.Governance** platform.  The tools are organized as separate .NET projects and are referenced from a single solution file (`GovernanceTools.slnx`).

---

## The tools at a glance

| Tool | Project | What it checks |
|------|---------|----------------|
| Governance validator | `governance-validator/GovernanceValidator.csproj` | Every `*.md` file (recursive, including `README.md`, `docs/`, `.agents/`) starts with a YAML front‑matter block containing `title`, `address`, `owner`, `version`, and `last_updated`. Also checks that every `*.json` and `*.jsonl` file under a `templates/` folder is well‑formed JSON (each line, for JSONL). The LSI command validates its required fields and cross-field integrity rules. |
| LSI manifest validation | `governance-validator/GovernanceValidator.csproj -- --integrity <manifest.json>` | Checks bidirectional requirement links, independent verification, exact revision/hash evidence, syndrome state, correction bounds, and checkpoint freshness. |
| Link checker | `link-checker/LinkChecker.csproj` | Every double‑bracket wikilink resolves to a Markdown file with that name (file name without `.md`, any folder). Regular `[text](path)` links are not checked. |

Both tools take one optional argument, the root folder to scan (default `.`). They print problems to *stderr* as `path: message`, one per line, and exit with `0` on success or `1` if any problem was found, so they can gate CI and pre‑commit checks.

## Quick usage

Run from the **repository root** (not from `tools/`):

```bash
dotnet run --project tools/governance-validator/GovernanceValidator.csproj -- .
dotnet run --project tools/link-checker/LinkChecker.csproj -- .
dotnet build tools/GovernanceTools.slnx --configuration Release
dotnet run --project tools/governance-validator/tests/IntegrityValidatorTests.csproj --configuration Release

dotnet run --project tools/governance-validator/GovernanceValidator.csproj -- --integrity path/to/change-set.lsi.json
```

Success output:

```
All markdown front‑matter validated successfully.
All template JSON validated successfully.
All wikilinks resolved.
```

To scan only part of the repo, pass a different root, e.g. `-- docs/the-method`. Note that wikilinks are then resolved only against files under that root.

### Typical failures and fixes

| Message | Fix |
|---------|-----|
| `missing front‑matter delimiter` | The file must begin with `---`, the YAML block, then a closing `---`. |
| `invalid JSON` | Fix the syntax in the named template file (line number shown for JSONL). |
| `missing required key 'owner'` | Add the key to the front matter (all five keys are required). |
| `broken link` followed by the target | Create a Markdown file with the linked name, or correct the link text. |

### LSI test suite

The dependency-free C# test runner invokes the validator against valid and invalid manifests. Build the tools solution first. Governance CI is self-contained and does not require a sibling application checkout.

## When to run them

- Before every commit that adds or edits Markdown (new docs, decision records, version bumps).
- Automatically in CI: `.github/workflows/software-delivery.yml` runs the tool build, LSI tests, governance validation, and link check on every push and pull request.
- AI agents are instructed to run both before finishing (see `AGENTS.md` and `CLAUDE.md`).

### Requirements

The SDK is pinned in `tools/global.json` (.NET 11 SDK, roll‑forward to the latest minor); the tools target `net8.0`. The validator restores `YamlDotNet` from NuGet on first run.

---

## Repository layout

```
tools/
├─ governance-validator/      # "GovernanceValidator" console app
│   ├─ GovernanceValidator.csproj
│   └─ Program.cs
├─ link-checker/             # "LinkChecker" console app
│   ├─ LinkChecker.csproj
│   └─ Program.cs
├─ GovernanceTools.slnx      # Solution file that aggregates the two projects
└─ TOOLS.md                  # (this file)
```

Each subdirectory name matches the project name (kebab‑case) and contains the standard .NET project layout (`bin/`, `obj/`, `*.csproj`, `Program.cs`).

---

## Adding a new tool

1. **Create a sub‑directory** named in kebab‑case that reflects the tool’s purpose, e.g. `my‑awesome‑tool`.
2. **Initialize a .NET console project** inside that folder:
   ```bash
   cd my-awesome-tool
   dotnet new console -n MyAwesomeTool
   ```
   This creates `MyAwesomeTool.csproj` and a basic `Program.cs`.
3. **Rename the project file** to match the folder name (optional but recommended):
   ```bash
   mv MyAwesomeTool.csproj my-awesome-tool.csproj
   ```
4. **Add any NuGet packages** the tool needs, e.g. `dotnet add package YamlDotNet`.
5. **Add the project to the solution** so it is built with the others:
   ```bash
   cd ..   # back to the tools root
   dotnet slnx add my-awesome-tool/my-awesome-tool.csproj
   ```
   The command updates `GovernanceTools.slnx` with a new `<Project Path="my-awesome-tool/my-awesome-tool.csproj" />` entry.
6. **Commit the new folder** and the updated `GovernanceTools.slnx`.

---

## Building all tools

From the `tools` root run:
```bash
dotnet build GovernanceTools.slnx -c Release
```
All projects defined in the solution are compiled and their binaries appear under each project's `bin/Release/net8.0/` folder.

---

## Running a tool

Besides `dotnet run` (see Quick usage), you can invoke the built binaries directly, passing the root folder to scan:
```bash
./governance-validator/bin/Release/net8.0/GovernanceValidator ..
./link-checker/bin/Release/net8.0/LinkChecker ..
```
(Paths are relative to `tools/`; on Windows use `GovernanceValidator.exe` and backslashes.)

---

## Why the split‑by‑project layout?

* **Isolation** – each tool has its own dependencies and build output, preventing version clashes.
* **Extensibility** – new tools can be added without modifying existing code.
* **Solution‑wide tooling** – the single `.slnx` file lets CI pipelines build, test, and package all tools together.

---

## FAQ

*Q*: Do I need to rename the namespace inside the source files?
*A*: It is recommended but not required.  Follow the pattern used in the existing projects (`RootNamespace` matches the project name).

*Q*: How do I reference a tool from another project?
*A*: Add a project reference (`dotnet add <other>.csproj reference <tool>/my‑tool.csproj`) or invoke the compiled binary directly.

---

**Maintainer tip** – keep `GovernanceTools.slnx` under version control; it is the single source of truth for which tools belong to the repository.
