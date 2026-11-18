---
title: ONBOARDING – Software Delivery Governance
address: governance/onboarding
owner: agent/pm
version: 1.0.0
last_updated: 2026-11-17
---

# ONBOARDING – Software Delivery Governance

## Prerequisites
- Git installed and access to this repository.
- .NET 11 SDK and .NET 8 runtime (download from https://dotnet.microsoft.com/download).
- A terminal that can run `dotnet` commands (PowerShell, Bash, CMD).

## Verify the repository locally
```bash
# From the root of the repo
dotnet run --project tools/governance-validator/GovernanceValidator.csproj -- .
dotnet run --project tools/link-checker/LinkChecker.csproj -- .
```
If everything is OK you will see:
```
All markdown front‑matter validated successfully.
All wikilinks resolved.
```
Any failures will be printed to *stderr* with the file path and problem.

## Adding a new decision record
```bash
# Create a new markdown file from the template (the script is a placeholder)
new-record --template decision-record --title "Add new workflow: Feature Freeze"
# Edit the file, then commit
git add .
git commit -m "Add Feature‑Freeze workflow"
git push
```
The `new-record` script simply copies the template from `templates/decision-records/` and opens it in your default editor.

## Logging governance actions (optional)
All agents can append a line to `logs/gov-actions.jsonl`:
```json
{"timestamp":"2026-11-15T08:12:00Z","agent":"project-manager","action":"create-work-item","target":"software-delivery-governance/workflows/feature-freeze.md"}
```
The file is version‑controlled so the history is immutable.

## CI status badge
The repository includes a GitHub Actions workflow at `.github/workflows/software-delivery.yml`. After the first push you will see a badge in the README showing the validation status.

---
*If you encounter any issues with the tools, open an issue in the `software-delivery-governance` folder or contact the admin assistant.*