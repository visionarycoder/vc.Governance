---
title: IFX Reuse Escalation
address: governance/workflows/ifx-reuse-escalation
type: governance
owner: agent/ceo
status: active
aliases: [ifx-reuse-escalation]
tags: [governance, ifx, reuse, escalation, workflow]
version: 1.2.0
last_updated: 2026-11-27
---

# IFX Reuse Escalation

`DA finds match -> DA -> AA (read-only review) -> IFX AA (definition) -> PM (tickets) -> IFX DA (build) -> PM (migration tickets) -> source AA + DA (migrate existing code) -> PM (unblock + notify) -> originating DA (rescan Surface Area, leverage IFX)`.

## Sequence

1. A developer agent researching existing code through the [Surface Area](../artifacts/surface-area.md) finds a possible match with code already in the suite. [Clone detection](clone-detection.md) surfaces the same kind of match by comparing written code for duplicates.
2. The DA escalates the possible match to its Application Architect through the documented pathway.
3. The AA reviews the existing code, read-only, to determine whether it offers an opportunity to refactor and simplify the application suite.
4. If the AA agrees, the AA sends a message to the IFX Application Architect with a description of the request.
5. If the IFX AA agrees that the code can be refactored, the IFX AA defines the new reusable code.
6. The originating DA is marked blocked and enters a zero-cost pause while it waits for the refactoring process to complete.
7. The project manager creates the tickets and queues the work with the IFX developer agent, who builds the new reusable code.
8. The project manager creates additional tickets for the source Application Architect and developer agent to update the existing originating code to use the new shared code in IFX.
9. When the IFX build and the source migration are complete, the project manager removes the block on the originating DA.
10. The DA does not notice the block being removed. The project manager notifies the DA to continue its effort.
11. On resuming, the DA rescans the Surface Area, finds the shared code reference that matches its needs, and leverages the IFX code in place of creating something new, which would have been duplicated code.

## Rules

- A zero-cost pause is the block state of a blocked agent. It is not an additional phase in the states of an agent.
- The AA's review of existing code is read-only.
- The project manager owns the execution flow of all tickets in this workflow and oversees all work efforts as the monitor.
- If any agent fails to respond or times out, the project manager is responsible for how to restart the effort, per [agent recovery](../infrastructure/agent-recovery.md).
- Adding or moving code into IFX remains an architectural decision owned by the IFX Application Architect, per [architecture and VBD boundaries](../../implementation-standards/architecture/architecture-and-vbd-boundaries.md).

## Related

- [Surface Area](../artifacts/surface-area.md)
- [Authority and Escalation](../authority/authority-and-escalation.md)
- [Durable Context and Rehydration](../infrastructure/durable-context-and-rehydration.md)
- [Project Manager](../roles/project-manager.md)
- [Clone Detection](clone-detection.md)
- [Implementation](implementation.md)
