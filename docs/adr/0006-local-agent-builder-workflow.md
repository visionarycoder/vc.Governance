---
metadata-version: 1.0.0
title: ADR 0006: Local agent Builder workflow
description: Record the owner-selected local Markdown coordination and agent-address conventions.
document-type: governance-policy
repository: vc.Governance
language: Standard Technical English
updated: 2026-11-11
version: # VERSION
1.0.0
last_updated: 2026-11-14
---

# ADR 0006: Local agent Builder workflow

## Status

Accepted as a record of the human owner's explicit decision GOV-OD16, recorded
on 2026-11-11. It selects a local Markdown coordination convention. It does not
select an agent runtime, authenticate identities, enforce permissions, or
replace existing lifecycle or artifact contracts.

## Context

The human owner requested project-local Markdown artifacts for a Builder that
coordinates an agent swarm. The requested concepts include a message board,
directly addressable agents, PM-created or rehydrated agents, standardized work
items, an application-surface inventory, and refactor/fix requests.

The existing governance assigns work to the Project Manager and keeps business,
architecture, testing, and acceptance authority with their responsible roles.
The [work-assignment contract](../templates/artifacts/work-assignment.md) and
[lifecycle](../process/service-lifecycle.md) remain controlling. A local
coordination file cannot provide technical enforcement; see
[enforcement boundaries](../implementation/enforcement-boundaries.md).

## Decision

1. Use project-local Markdown records for Builder coordination. Keep application
   instances in the application project, not vc.Governance.
2. The Project Manager maintains the message board, creates and rehydrates
   agents, issues formal work assignments, updates board state, and nudges
   agents to check the board.
3. Give each logical agent an immutable, project-scoped address. Agents may
   communicate directly through messages addressed to those IDs. A message does
   not assign work, approve a change, transfer authority, or supersede an
   existing decision route.
4. When a direct message requires another agent to perform work, the Project
   Manager records or updates the work item, checks prerequisites, and issues
   the applicable formal assignment before that work begins.
5. The Solution Architect maintains the project application-surface index.
   The responsible Application Architect maintains each component's contracts
   and methods within the accepted design. The inventory includes every
   component, contract, and method in the agreed application scope, with brief
   descriptions and exact design/source references.
6. Use a fix request to bound refactoring or repair of existing code to a
   specific revision, permitted paths, preserved behavior, and verification
   criteria. It does not authorize requirement or design changes.
7. Keep runtime selection, authentication, permission enforcement, and worker
   isolation open. Do not claim that Markdown files provide those controls.
   Preserve existing approval routes, phase gates, and repository boundaries.

The [local agent Builder workflow](../process/local-agent-builder.md) and
[Builder templates](../templates/builder/README.md) implement this
coordination convention. The decision does not change the v1.0.0 core artifact
schema.

## Consequences

- Agents can address project messages to stable logical identities without
  creating a second assignment channel.
- The Project Manager has an explicit responsibility to keep the board current
  and prompt agents to act on it.
- The work board, direct messages, work items, fixes, and application surface
  remain coordination aids. Governance artifacts retain their existing
  authority and approval meaning.
- A local file layout does not prove that the correct agent read a message or
  prevent an agent from editing an unauthorized file. Runtime enforcement
  remains separate work.

## Alternatives

| Alternative | Disposition |
| --- | --- |
| Route all agent communication through the Project Manager | Not selected; agents may directly message a stable recipient address. The Project Manager still owns assignments and board maintenance. |
| Let a direct message create or transfer assigned work | Not selected; it would bypass the existing Project Manager assignment boundary. |
| Treat a role name or Markdown profile as authentication | Not selected; local records do not authenticate identities or grant permissions. |
| Replace the formal Work Assignment with the Builder ticket | Not selected; the ticket links the required formal assignment and does not change the artifact contract. |

## Related decisions and specifications

- [GOV-OD16](../governance/owner-decisions-2026-11-11.md): local Builder coordination decision.
- [GOV-OD17](../governance/owner-decisions-2026-11-11.md): message queue, long-running polling agents, and PM-directed work requests.
- [Roles and decisions](../governance/roles-and-decisions.md): role authority and Project Manager assignment responsibility.
- [Local agent Builder workflow](../process/local-agent-builder.md): operational coordination procedure.
- [Builder templates](../templates/builder/README.md): project-local Markdown forms.
- [Work-assignment contract](../templates/artifacts/work-assignment.md): formal assignment fields and authority.
- [Open decisions](../governance/open-decisions.md): runtime, identity, isolation, and enforcement remain unresolved.
