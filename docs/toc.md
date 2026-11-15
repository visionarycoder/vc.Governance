---
metadata-version: 1.0.0
title: Table of contents
description: List current governance documents by responsibility.
document-type: index
repository: vc.Governance
language: Standard Technical English
updated: 2026-11-11
version: # VERSION
1.0.0
last_updated: 2026-11-14
---

# Table of contents

[Repository overview](../README.md) · [Documentation guide](README.md) · [Topic index](index.md)

The primary documentation governs how code is designed, assigned, reviewed, tested, and changed. Retained implementation notes appear after governance and process documents. Only current repository files are linked.

## Authority and decision rights

- [Source authority](governance/source-authority.md)
- [Owner architecture policy](governance/owner-architecture-policy.md)
- [Roles and decisions](governance/roles-and-decisions.md)
- [Decision and approval matrix](governance/decision-and-approval-matrix.md)
- [Architecture decision records](adr/README.md)
- [ADR 0001: Approval process structure](adr/0001-approval-process-structure.md)
- [ADR 0002: Internal component handlers](adr/0002-internal-component-handlers.md)
- [ADR 0003: CEO and human-owner authority](adr/0003-ceo-and-human-owner-authority.md)
- [ADR 0004: QA conflict escalation](adr/0004-qa-conflict-escalation.md)
- [ADR 0005: Enforcement handoff and deployment boundary](adr/0005-enforcement-handoff-and-deployment-boundary.md)
- [ADR 0006: Local agent Builder workflow](adr/0006-local-agent-builder-workflow.md)
- [ADR 0007: Local message queue and agent polling](adr/0007-local-message-queue-and-agent-polling.md)
- [ADR 0008: Immutable message publication](adr/0008-immutable-message-publication.md)
- [Owner decisions: approvals and artifact contracts](governance/owner-decisions-2026-11-07.md)
- [Owner decisions: approval validity](governance/owner-decisions-2026-11-08.md)
- [Owner decisions: authority, escalation, and enforcement handoff](governance/owner-decisions-2026-11-11.md)
- [Change and approval validity](governance/change-approval-validity.md)
- [Open decisions](governance/open-decisions.md)

## Development process

- [System and project design](process/system-and-project-design.md)
- [Service lifecycle](process/service-lifecycle.md)
- [Local agent Builder workflow](process/local-agent-builder.md)
- [Lifecycle gate criteria](process/lifecycle-gates.md)
- [Project tracking](process/project-tracking.md)
- [Token based costing](process/token-costing.md)

## Design and review standards

- [Design standard](standards/design-standard.md)
- [Standard Technical English rules](standards/rules.ste.md)
- [Numerical methods](standards/numerical-methods.md)

- [Markdown authoring and validation](standards/markdown-authoring.md)

## Artifact contracts and templates

- [Governance artifact contracts](artifacts/README.md)
- [Artifact templates](templates/artifacts/README.md)
- [Developer agent prompt](templates/developer-agent-prompt.md)
- [Local agent Builder templates](templates/builder/README.md)

## Repository-local documentation skills

- [Skill catalog](../.agents/README.md)
- [Workflow documentation](../.agents/skills/document-agentic-workflows/SKILL.md)
- [Artifact-contract documentation](../.agents/skills/document-governance-artifacts/SKILL.md)
- [Decision records](../.agents/skills/record-governance-decisions/SKILL.md)
- [Workflow documentation review](../.agents/skills/review-agentic-workflow-docs/SKILL.md)

## Repository and enforcement boundaries

- [Framework and implementation ownership](implementation/repository-ownership.md)
- [Enforcement boundaries](implementation/enforcement-boundaries.md)

## Source and reconciliation records

- [Sources and bibliography](sources.md)
- [Source review](research/source-review.md)
- [Whole-book reconciliation](research/reconciliation.md)
- [Supporting-pattern review](research/supporting-pattern-review.md)
- [Existing method-tracing evidence](research/method-tracing-review.md)

- [Navigation reconciliation](research/navigation-reconciliation.md)

## Retained coding constraints and implementation notes

- [Project bootstrap and design conformance](implementation/project-bootstrap.md)

- [Current Microsoft technical standard](standards/microsoft-technical-standard.md)
- [Implementation pattern catalog](patterns/README.md)
- [Mandatory component proxies](patterns/component-proxies.md)
- [Internal component handlers](standards/component-handlers.md)
- [Attribute-driven method I/O tracing](patterns/method-io-tracing.md)
- [UI visualization pattern](patterns/ui-visualization.md)
- [C# technical-policy templates](templates/dotnet/README.md)

## Machine-readable governance records

- [Approval matrix](governance/approval-matrix.json).
- [Lifecycle gate criteria](process/lifecycle-gates.json).
- [Change and approval validity](governance/change-approval-validity.json).
- [Method rule records](standards/rules.json).
- [Artifact schema](artifacts/schemas/artifact.schema.json).
- [Operational conformance obligations](artifacts/conformance-checks.json).
- [Lifecycle/validity acceptance cases](artifacts/lifecycle-validity-cases.json).
- [Lifecycle/validity validation report](artifacts/lifecycle-validity-validation.json).
- [Historical source identities](research/source-identities.json).
