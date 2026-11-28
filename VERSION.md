---
title: VERSION
address: governance/version
owner: agent/pm
version: 1.11.0
last_updated: 2026-11-27
---

# VERSION

1.11.0
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
| 1.11.0 | 2026-11-27 | Logical Software Integrity gates, validator, tests, and CI enforcement; removed stale application-specific cross-repository build dependencies. |
| 1.10.0 | 2026-11-27 | Clone-detection workflow (surface-area review guidance reused; written code compared for duplicates like Visual Studio Code Clone Detection); implementation plan reviewed and approved before writing code; PM role fulfilled by the coding harness; acceptance verifies shared-code leverage. |
| 1.9.0 | 2026-11-27 | IFX reuse-escalation workflow (DA → AA → IFX AA → IFX DA, source migration tickets, PM unblock notification); PM ownership of ticket execution flow, work monitoring, and effort restart; zero-cost pause as the block state of a blocked DA, no additional agent phase. |
| 1.8.0 | 2026-11-25 | Closed component call hierarchy (Client → Manager; Manager → Engine/Access; Engine → Access; Manager ↔ Manager via the message bus as a virtual client); Util component type (`Suite.Util.<Capability>` with durable Application Architect and developer agent); handler-pattern rule for Manager, Engine, and Access components. |
| 1.7.2 | 2026-11-25 | Added manager-status.md manager completion tracker. |
| 1.7.1 | 2026-11-25 | Added handler guidance and common-folder ban. |
| 1.6.0 | 2026-11-25 | Generic dependency checks and governance file updates. |
| 1.5.0 | 2026-11-24 | Governance validator also checks that JSON and JSONL files under `templates/` are well-formed. |
| 1.4.0 | 2026-11-24 | Added `templates/agent-context/` (manifest, event, and checkpoint templates for durable agent context). |
| 1.3.0 | 2026-11-24 | Added durable context and rehydration-by-address governance (`durable-context-and-rehydration.md`), linked from agent recovery and context management; removed unrelated climate-report notes. |
| 1.2.0 | 2026-11-24 | Framework Markdown consolidated under `docs/`; duplicate nested folders and placeholder stubs removed; agent entry points (`.agents/`, `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`, Copilot instructions) added; tooling guide expanded; `vc.Governance.slnx` added. |
| 1.0.0 | 2026-11-17 | Initial governance documents, validator and link checker, CI workflow. |
