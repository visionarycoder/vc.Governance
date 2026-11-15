---
metadata-version: 1.0.0
title: Local agent Builder templates
description: Index Markdown templates for local project-agent coordination.
document-type: index
repository: vc.Governance
language: Standard Technical English
updated: 2026-11-11
version: # VERSION
1.0.0
last_updated: 2026-11-14
---

# Local agent Builder templates

These templates provide local Markdown records for an agent Builder. Copy them into an application project's `.builder/` directory and replace instructional text with project-owned content. Do not store application work items or application design records in vc.Governance.

Follow the [local agent Builder workflow](../../process/local-agent-builder.md). That process supplements the existing lifecycle; it does not replace governance artifacts or grant runtime permissions.

| Record | Template | Purpose |
| --- | --- | --- |
| Message board | [messages.md](messages.md) | PM-only rebuildable summary of the immutable message-file queue |
| Direct message | [message-record.md](message-record.md) | Publish an immutable request, notification, acknowledgement, response, or resolution |
| Agent profile | [agent-profile.md](agent-profile.md) | Track a logical agent address and the context needed to rehydrate it |
| Work item | [work-item.md](work-item.md) | Describe a bounded request, its assignee, inputs, and completion evidence |
| Fix request | [fix-request.md](fix-request.md) | Bound a refactor or repair to existing code and preserved behavior |
| Application-surface index | [application-surface.md](application-surface.md) | List components and link to their contract and method inventories |
| Component surface | [component-surface.md](component-surface.md) | Inventory one component, its contracts, and every method in scope |

## Authority and use

The Project Manager maintains the board summary, creates and rehydrates agents, and assigns work. The Project Manager, Product Owner, and Solution Architect are long-running agents that poll published message files for their exact `To` address. Other active agents poll according to their Builder instructions. Agents may communicate directly by stable address, but direct communication does not assign work. To request a work item for another agent role, address a `work-item-request` message to the Project Manager and specify the requested role. A formal Project Manager Work Assignment remains required when the lifecycle or action requires it. Link that assignment from the work item; do not make a summary row or ticket a second assignment channel.

The Solution Architect and Application Architects maintain the application surface within their design responsibilities. A fix request does not authorize implementation until the Project Manager has issued the required assignment and the applicable design, requirement, and test prerequisites are current.

These files are Markdown coordination conventions. They do not authenticate identities, protect files, enforce isolation, or select an execution runtime. Do not treat role or address fields as proof of authority.

## Concurrent-write mitigation

Senders publish separate message files; only the Project Manager writes the board summary. Recipients publish separate acknowledgement and response files instead of editing originals. Agents poll final message files by exact `To`, not just summary rows. Follow the [publication and helper handoff](../../process/local-agent-builder.md#publication-and-concurrent-write-contract). Atomic publication requires a verified helper; these templates do not implement it.
