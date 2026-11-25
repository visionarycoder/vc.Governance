---
title: GEMINI (Gemini CLI)
address: governance/gemini-md
owner: agent/pm
version: 1.5.0
last_updated: 2026-11-24
---

# GEMINI (Gemini CLI)

This repository is the process-only software delivery governance framework. Read [.agents/README.md](.agents/README.md) first; it redirects to the documentation entry points under [docs/](docs/).

Rules for agents:
- All framework Markdown lives in `docs/`; the repository overview is in [README.md](README.md).
- Every Markdown file needs YAML front matter with `title`, `address`, `owner`, `version`, `last_updated`.
- Before finishing, run from the repo root:
  `dotnet run --project tools/governance-validator/GovernanceValidator.csproj -- .` and
  `dotnet run --project tools/link-checker/LinkChecker.csproj -- .`
