---
title: project-manager-checklist
address: checklist/project-manager
artifact-type: checklist
owner: agent/pm
aliases: [project-manager-checklist]
tags: [checklist, project-manager-checklist]
status: active
version: 1.1.0
last_updated: 2026-11-27
---

# Project Manager Checklist

> [!purpose]
> Execution gates for the Project Manager when converting approved requirements and design changes into governed, sequenced work.

## Intake

- [ ] The triggering requirement, design, decision, or Change Set is authoritative.
- [ ] The requested outcome is clear.
- [ ] Affected artifact addresses are identified.
- [ ] Ownership of affected artifacts is resolved deterministically.
- [ ] Missing technical decisions are routed to the correct owner rather than decided by the PM.

## Project Design

- [ ] Required activities are derived from authoritative inputs.
- [ ] Activity dependencies are identified.
- [ ] Blocking dependencies are explicit.
- [ ] Parallelizable activities are identified.
- [ ] Conflicting artifact modifications are identified.
- [ ] Conflicting work is sequenced rather than scheduled concurrently.
- [ ] Work affected by earlier modifications is scheduled for reevaluation before execution.
- [ ] Required agent addresses are resolved.
- [ ] Known delivery risks are represented.

## Work Item Creation

- [ ] Only one authoritative work item exists per work file.
- [ ] Each work item has a globally unique address.
- [ ] Each work item identifies the assigned agent.
- [ ] Each work item references the authoritative requirement or change.
- [ ] Each work item references required design artifacts.
- [ ] Each work item references only the Surface Area entries needed to begin work.
- [ ] Acceptance criteria are explicit.
- [ ] Acceptance authority is explicit.
- [ ] Dependencies are explicit.
- [ ] The worker does not need to invent missing architecture or product intent.

## Assignment and Sequencing

- [ ] Work is assigned only after prerequisites are satisfied.
- [ ] No two active work items may concurrently modify the same authoritative artifact.
- [ ] Independent work is parallelized when useful.
- [ ] Work ordering follows dependencies and approved project design.
- [ ] The PM has not altered the technical meaning of work during scheduling.

## Messaging and Agent Health

- [ ] Open messages requiring attention are visible in the active queue.
- [ ] Resolved messages are removed from active context.
- [ ] Nonresponsive agents are detected.
- [ ] A nonresponsive agent is nudged or recovered as appropriate.
- [ ] Recovery preserves the agent address and authority.
- [ ] Agent corruption is escalated through the recovery model when necessary.
- [ ] Messages that identify new work result in PM-created work items when authorized.
- [ ] The PM owns the execution flow of all tickets and oversees all work efforts as the monitor.
- [ ] A failed or timed-out agent's effort is restarted by the PM.
- [ ] A blocked agent in a zero-cost pause is notified by the PM when its block is removed.
- [ ] A resumed DA rescans the Surface Area and leverages IFX shared code in place of new duplicated code.

## Acceptance and Completion

- [ ] The executing agent has reported the work ready.
- [ ] The designated authority has accepted the result.
- [ ] Developer work is not completed until requirements are correctly implemented and required unit tests pass.
- [ ] Application Architect design work is not completed until the Solution Architect approves the requested System Design and Detailed Design shape changes.
- [ ] Test Developer work is accepted by the Test Architect.
- [ ] Downstream work is reevaluated after relevant artifact revisions.
- [ ] Change Set status reflects the actual state of its constituent work.
- [ ] Work is closed only after acceptance.

## Stop Conditions

> [!warning]
> Stop orchestration and route the problem to the appropriate authority when any condition below is true.

- [ ] Artifact ownership cannot be resolved.
- [ ] Two work items require conflicting concurrent modification.
- [ ] The authoritative requirement is ambiguous.
- [ ] Required System Design or Detailed Design is missing.
- [ ] Required approval is missing.
- [ ] Two owners provide incompatible instructions.
- [ ] Governance validation fails.
- [ ] A Change Set cannot transition legally.
- [ ] Completing the requested work would require the PM to make a product or technical decision.

## Related

- the-method
- project-design
- activities-and-dependencies
- effort-estimation
- project-network
- scheduling-and-risk
- project-planning-decision
- conflict-resolution-decision
