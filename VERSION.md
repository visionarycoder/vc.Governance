---
title: VERSION
address: governance/version
owner: agent/pm
version: 1.7.1
last_updated: 2026-11-25
---

# VERSION

1.5.0
This is the version of the **vc.Governance** repository: the software delivery governance framework, the method documents, the implementation standards, and the validation tooling. It is the value shown in the [README](README.md).

## Versioning rules

- The version follows `MAJOR.MINOR.PATCH`.
- **MAJOR** – a change to governance authority, roles, or artifact ownership that alters how existing work is governed.
- **MINOR** – new or restructured framework content, standards, or tooling capability (for example moving content under `docs/` or adding agent entry points).
- **PATCH** – corrections, clarifications, and link or formatting fixes.
- When the version changes, update this file, the `version` and `last_updated` front matter of `README.md`, and any document whose content changed.

## Change history

| Version | Date | Summary |
|---------|------|---------|
| 1.5.0 | 2026-11-24 | Governance validator also checks that JSON and JSONL files under `templates/` are well-formed. |
| 1.4.0 | 2026-11-24 | Added `templates/agent-context/` (manifest, event, and checkpoint templates for durable agent context). |
| 1.3.0 | 2026-11-24 | Added durable context and rehydration-by-address governance (`durable-context-and-rehydration.md`), linked from agent recovery and context management; removed unrelated climate-report notes. |
| 1.2.0 | 2026-11-24 | Framework Markdown consolidated under `docs/`; duplicate nested folders and placeholder stubs removed; agent entry points (`.agents/`, `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`, Copilot instructions) added; tooling guide expanded; `vc.Governance.slnx` added. |
| 1.0.0 | 2026-11-17 | Initial governance documents, validator and link checker, CI workflow. |
