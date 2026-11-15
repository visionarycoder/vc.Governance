---
metadata-version: 1.0.0
title: Local agent Builder workflow
description: Define local Markdown coordination for project agents without replacing governance gates.
document-type: process
repository: vc.Governance
language: Standard Technical English
updated: 2026-11-11
version: # VERSION
1.0.0
last_updated: 2026-11-14
---

# Local agent Builder workflow

This process defines a local, Markdown-based coordination convention for project agent Builders. It records the human owner's GOV-OD16 through GOV-OD18 decisions. It does not replace the [service lifecycle](service-lifecycle.md), the [work-assignment contract](../templates/artifacts/work-assignment.md), or any required review, approval, or acceptance route.

## Scope and authority

Use the [Builder templates](../templates/builder/README.md) in the application project's own repository. The files provide a local board, agent directory, work-item records, direct messages, an application-surface inventory, and fix requests.

The Project Manager owns work transitions and is the sole writer of the message board summary. The Project Manager creates and rehydrates agents, issues formal work assignments, and nudges agents to check the queue. The Solution Architect, Product Owner, and Project Manager are long-running agents that poll published message files, not just the summary. Every active agent virtually subscribes by matching the message's `To` value to its stable address. A message, agent profile, or work-item status does not authenticate an agent, grant permissions, or replace a required governance artifact.

Each agent has a stable, project-scoped address. Agents may send messages directly to another address. Direct communication does not assign work, change requirements or design, approve a decision, or transfer ownership. To request work from another agent role, an agent sends a `work-item-request` message to the Project Manager's address and identifies the requested role. The Project Manager creates or updates the work item, selects an appropriate agent, and issues the applicable formal assignment.

This file-based convention selects neither an orchestration runtime nor a permission model. Local Markdown records do not enforce worker isolation, identity, or access control. See [enforcement boundaries](../implementation/enforcement-boundaries.md) and [open decisions](../governance/open-decisions.md).

## Project-local file layout

Copy and adapt the templates to the application project. Keep the records in that project's local Builder context.

```text
.builder/
  README.md
  messages.md
  messages/
    MSG-<message-id>.md
  agents/
    <agent-id>/
      profile.md
  work-items/
    WI-<work-id>.md
  fixes/
    FIX-<fix-id>.md
  application-surface/
    README.md
    components/
      <component-id>.md
```

Use the [message board template](../templates/builder/messages.md) as `.builder/messages.md`. The authoritative queue is the collection of published, immutable message files under `.builder/messages/`. Each sender publishes its own message file with one exact `To` address. Only the Project Manager writes the board summary, rebuilding it from those files. A missing or stale summary does not prevent message discovery.

Use one immutable `agent-id` per logical agent in a project. Do not reuse a retired address for a different agent. The address identifies the logical agent across sessions, not a particular process or authenticated person.

## Start-to-finish coordination

1. The Product Owner defines business requirements and acceptance criteria in the owned project documents, then informs the Project Manager that work is ready to route.
2. The Project Manager checks prerequisites and creates a work item from the [work-item template](../templates/builder/work-item.md). For lifecycle work that requires a formal assignment, the work item links the current Project Manager-issued [Work Assignment](../templates/artifacts/work-assignment.md).
3. The Project Manager assigns the work to one agent address. The Project Manager creates a profile for a new agent or rehydrates the existing logical agent from its profile and referenced durable context. The Project Manager adds a `work-assignment` message to the queue with `To` set to that address and links to the work item and formal assignment. The notification does not replace the assignment.
4. The Solution Architect, Product Owner, and Project Manager remain long-running agents and poll published message files. Each filters messages whose `To` value equals its exact address. Other active agents poll according to their Builder instructions. The recipient publishes separate acknowledgement, response, or resolution messages referencing the original message ID. The Project Manager monitors unacknowledged messages and nudges recipients when action is due.
5. Agents may contact one another directly using stable addresses for questions, information, or role-bounded input. When an agent needs work performed by another role, it addresses a `work-item-request` to the Project Manager and specifies the requested agent role. The Project Manager creates the work item and issues the assignment; the message itself does not assign work.
6. Before proposing a new component, contract, or method, the assigned agent checks the current [application surface](../templates/builder/application-surface.md) and component entries. A missing, stale, or contradictory entry is reported to the responsible architect; the agent does not infer that a new component or contract is authorized.
7. For a change to previously written code, the requester identifies the exact code revision and creates a [fix request](../templates/builder/fix-request.md). The Project Manager scopes and assigns it. The worker preserves behavior outside the accepted fix and follows the normal design, test, review, and acceptance routes.
8. The assigned worker submits the required output and evidence. The authorized owner performs the required review or acceptance. The Project Manager updates the board and closes the work item only after the required evidence is recorded. A ticket status cannot substitute for an authorized decision or phase exit.

## Board and status ownership

Published message files are the local queue. The board is a rebuildable view of that queue. The Project Manager is accountable for its maintenance and is its sole writer. The Project Manager:

- keeps each summary row linked to its published message and any related work item;
- derives queued, acknowledged, and resolved states from original messages and their linked acknowledgement or resolution messages;
- monitors for unacknowledged messages and prompts the addressed agent to poll and act;
- creates and updates work items for accepted work requests, selects an agent whose role matches the requested role or work-item needs, and issues formal assignments;
- adds an assignment-notification message addressed to the exact assigned agent address after issuing the formal assignment;
- checks summarized requests against authoritative work items and governance records without rewriting published messages.

Recipients never edit original messages or board rows. An acknowledgement records receipt, not completion. A response supplies information; only an explicit resolution with outcome evidence resolves the original request. Do not acknowledge acknowledgements automatically. Preserve every published file as history. Agents do not reassign work or mark a work item accepted or closed. The Project Manager records work-item transitions after checking the evidence and applicable authority route. If the summary conflicts with a message file, rebuild it. If a message conflicts with a work item or approval record, hold the affected action and route the conflict to its owner.

## Publication and concurrent-write contract

1. The publisher allocates a unique message ID and exclusively creates a uniquely named temporary file in the queue directory. Temporary filenames end in `.tmp`, not `.md`.
2. The publisher writes the complete message, validates its required fields, and closes the file before publication.
3. The publisher renames the temporary file to `MSG-<message-id>.md` on the same filesystem using an atomic, no-overwrite operation. Never copy across filesystems or replace an existing destination to publish a message.
4. Readers enumerate only final `MSG-*.md` files and ignore temporary files. They read message headers to filter exact `To` addresses. No sender edits a published message.
5. A destination collision or publication failure is reported explicitly. Preserve the existing destination. If the publication result is uncertain, compare the existing destination with the intended ID and exact bytes before reporting success or attempting another publication.
6. The Project Manager serializes summary updates through one active writer and publishes a complete replacement summary through a same-filesystem atomic replacement. Readers may observe the previous complete summary; message discovery still uses the authoritative files.

Use the [message template](../templates/builder/message-record.md) for acknowledgements, responses, and resolutions too. Give each a new message ID and the original ID in `Related message ID`. Address it to the original sender. The Project Manager can derive summary state by scanning these linked records even when the original sender is another agent.

These are implementation requirements, not guarantees supplied by Markdown or an instruction to edit filesystem permissions. Atomic visibility is not a guarantee of persistence after power loss. A filesystem and helper must be verified before claiming the publication contract is implemented.

## Helper handoff and verification

Reusable publication and summary-update helpers belong in vc.Ifx under the [repository ownership policy](../implementation/repository-ownership.md). The responsible Solution Architect owns technical design; the Test Architect owns verification planning; the Project Manager issues implementation work. This document does not authorize changes in that repository or select C# Channels, a runtime, or a storage platform.

Before adopting a helper, verify these cases against the selected local filesystem:

- Concurrent senders publish distinct IDs; every completed publication is discoverable and no file is overwritten.
- Readers polling during publication observe either no final file or one complete, validated message, never partial content.
- A crash before rename leaves only an ignored temporary file. A crash after rename leaves a discoverable final message even without a board update.
- A duplicate destination is rejected without changing its bytes. An uncertain result is checked against the intended record instead of silently overwriting or duplicating it.
- Concurrent acknowledgement and response publications leave the original message unchanged and can be reconciled into the summary.
- With the PM stopped or the board missing, agents still discover published messages. The PM can rebuild the board from originals and linked records.
- A failed summary replacement preserves a complete readable summary and surfaces the failure.

No helper or runtime has been implemented or verified here. Retry policy, duplicate processing effects, stale-worker protection, PM recovery, and power-loss durability remain separate reliability work. Do not describe this concurrent-write mitigation as full fault tolerance.

## Ownership of the application surface

The Solution Architect maintains the component-level application-surface index. The responsible Application Architect maintains the entry for each component, including its contracts and methods, within the accepted system design. Each entry points to the applicable requirements, reviewed detailed design, and source paths. Keep descriptions short; the inventory is a discovery aid, not a replacement for the source or accepted design.

Record every component, contract, and method in the project's agreed scope. Update the inventory when an accepted design or implementation changes that surface. The developer reports additions or discrepancies in the work item; the responsible architect resolves and updates the inventory. If the inventory conflicts with an accepted design or current source, do not treat the inventory as approval to change either one.

## Escalation

Route a business meaning or acceptance conflict to the Product Owner. Route a component design, contract, or method-boundary issue to the Application Architect, and escalate issues beyond that architect's bounds to the Solution Architect. Route test-design or verification issues to the Test Architect. Route assignment, scheduling, resource, and coordination issues to the Project Manager and the responsible design owner as applicable. Preserve the existing escalation and approval routes; a message or board flag does not decide the issue.
