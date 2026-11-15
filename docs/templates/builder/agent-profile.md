---
metadata-version: 1.0.0
title: Local Builder agent profile template
description: Record a stable project agent address and its rehydration context.
document-type: template
repository: vc.Governance
language: Standard Technical English
updated: 2026-11-11
version: # VERSION
1.0.0
last_updated: 2026-11-14
---

# Local Builder agent profile template

Keep one profile at `.builder/agents/<agent-id>/profile.md` for each logical agent. The Project Manager creates the profile and controls its lifecycle. The profile supports rehydration; it does not authenticate an actor or grant permissions.

## Identity and lifecycle

| Field | Value |
| --- | --- |
| Project ID | `<stable-project-id>` |
| Agent ID | `<unique, immutable project-local ID>` |
| Agent address | `<project-id/agent-id>` |
| Role | `<one role from the project role model>` |
| Lifecycle state | `<ready/active/hibernated/retired>` |
| Created by | `<Project Manager identity>` |
| Created at | `<date and time with timezone>` |
| Last rehydrated | `<date and time with timezone, or never>` |
| Current work item | `<WI-id or none>` |

## Bounded responsibilities

- **Assigned responsibilities:** `<role-scoped responsibilities>`
- **Authority limits:** `<decisions this agent cannot make or approve>`
- **Permitted project paths:** `<paths authorized by the current work assignment>`
- **Required escalation route:** `<responsible owner and message/work-item route>`

## Durable context

| Context record | Exact path and revision | Purpose |
| --- | --- | --- |
| Agent instructions | `<path and revision>` | `<role and bounded instructions>` |
| Current work item | `<path and revision>` | `<assigned objective and completion criteria>` |
| Formal assignment | `<path, revision, or none when not required>` | `<authorized scope>` |
| Design/requirements | `<paths and revisions>` | `<current governing inputs>` |
| Application surface | `<path and revision>` | `<existing components, contracts, and methods>` |
| Last checkpoint | `<path and revision, or none>` | `<resume point>` |

## Rehydration

The Project Manager reuses this logical address when resuming the same agent's work. Before rehydrating, the Project Manager checks the current profile, work item, assignment, published messages and linked outcomes, and exact referenced context. The Project Manager records the new activation time and nudges the agent to poll published files by its exact `To` address. A stale or absent board summary does not establish that the agent has no messages.

The rehydrated agent continues only under a current assignment and applicable inputs. Missing or conflicting context is reported to the Project Manager; the agent must not invent prior decisions or treat old session text as current approval. Do not run multiple active instances under the same address unless the Project Manager has explicitly separated their work and identities.

When an agent is retired, preserve its profile and message history. Do not transfer its address to another logical agent.
