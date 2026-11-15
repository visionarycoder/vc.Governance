---
metadata-version: 1.0.0
title: Architecture decision records
description: Index decisions that explain the governance structure and its trade-offs.
document-type: index
repository: vc.Governance
language: Standard Technical English
updated: 2026-11-11
version: # VERSION
1.0.0
last_updated: 2026-11-14
---

# Architecture decision records

These records explain adopted decisions, their context, consequences, and alternatives. They do not issue application approvals or replace the controlling governance specifications. A record's accepted status must cite the decision authority that established it.

| Record | Status | Recorded | Basis |
| --- | --- | --- | --- |
| [ADR 0001: Approval process structure](0001-approval-process-structure.md) | Accepted record of existing decisions | 2026-11-08 | Human-owner decisions GOV-OD01–GOV-OD09 and the adopted role hierarchy |
| [ADR 0002: Internal component handlers](0002-internal-component-handlers.md) | Accepted record of owner instruction | 2026-11-09 | GOV-OD10: handlers within every component |
| [ADR 0003: CEO and human-owner authority](0003-ceo-and-human-owner-authority.md) | Accepted record of explicit owner decisions | 2026-11-11 | GOV-OD11–GOV-OD12: shared human identity, distinct capacities, and project-specific commitment limits |
| [ADR 0004: QA conflict escalation](0004-qa-conflict-escalation.md) | Accepted record of explicit owner decisions | 2026-11-11 | GOV-OD13–GOV-OD14: direct QA escalation and independent review when an escalation authority is implicated |
| [ADR 0005: Enforcement handoff and deployment boundary](0005-enforcement-handoff-and-deployment-boundary.md) | Accepted record of explicit owner decision | 2026-11-11 | GOV-OD15: governance handoff; platform and deployment remain open |
| [ADR 0006: Local agent Builder workflow](0006-local-agent-builder-workflow.md) | Accepted record of explicit owner decision | 2026-11-11 | GOV-OD16: local Markdown coordination, direct agent messages, and PM-owned board and assignments |
| [ADR 0007: Local message queue and agent polling](0007-local-message-queue-and-agent-polling.md) | Accepted record of explicit owner decision | 2026-11-11 | GOV-OD17: long-running pollers, `To`-address subscriptions, and PM-directed work requests |
| [ADR 0008: Immutable message publication](0008-immutable-message-publication.md) | Accepted record of explicit owner decision | 2026-11-11 | GOV-OD18: immutable message files, atomic publication contract, and PM-only board summary; replaces ADR 0007's shared-board storage |

Use [the table of contents](../toc.md) and [topic index](../index.md) to find the governing specifications.
