---
metadata-version: 1.0.0
title: ADR 0007: Local message queue and agent polling
description: Record the owner-selected queue, virtual subscriptions, and work-request routing.
document-type: governance-policy
repository: vc.Governance
language: Standard Technical English
updated: 2026-11-11
version: # VERSION
1.0.0
last_updated: 2026-11-14
---

# ADR 0007: Local message queue and agent polling

## Status

Accepted as a record of the human owner's explicit decision GOV-OD17, recorded
on 2026-11-11. It specifies local coordination behavior. It does not select a
polling interval, agent runtime, message-delivery guarantee, or permission
model.

The shared-board storage and sender-written queue rows below are historical.
[ADR 0008](0008-immutable-message-publication.md), based on GOV-OD18,
supersedes those parts with immutable message files and a PM-only summary.
Long-running polling roles, exact addressing, and PM assignment routes remain.

## Context

The local Builder needs a message board that agents can use as a queue. The
human owner specified that the Solution Architect, Product Owner, and Project
Manager are long-running agents that poll the board. Each agent identifies its
messages by matching its stable address in the `To` column. A sender may also
request that the Project Manager create a work item for a particular agent
role.

The existing assignment boundary remains controlling: the Project Manager
assigns work, while agents may communicate directly. A queue message does not
replace a formal Work Assignment, alter a role's decision authority, or prove
that an agent read the message.

## Decision

1. Treat the project-local `messages.md` as a message queue. Every queue entry
   has a unique message ID, sender address, one exact recipient address in
   `To`, message kind, state, and link to its full message record.
2. Agents virtually subscribe by polling for queue entries whose `To` value
   exactly matches their stable project-scoped address. The Solution Architect,
   Product Owner, and Project Manager remain long-running pollers. Other active
   agents poll under their Builder instructions.
3. The sender creates the message record and queue entry. The Project Manager
   is accountable for queue maintenance, state reconciliation, and prompting
   recipients to poll and act. Preserve message history; do not remove a queue
   record when it is resolved.
4. When a sender requests work from another agent role, it addresses the
   message to the Project Manager's exact address, sets its kind to
   `work-item-request`, and identifies the requested role separately from `To`.
5. The Project Manager evaluates the request, creates or updates the work item,
   selects an appropriate agent of the requested role, and creates or
   rehydrates an agent of that role when no active agent can take the work.
   The Project Manager then issues the applicable formal assignment and adds a
   `work-assignment` queue message addressed to that agent, linking both the
   work item and assignment. The requested role does not itself assign or
   guarantee work.
6. Agents may still communicate directly with other agent addresses for
   questions, information, or role-bounded input. A direct message does not
   authorize work or bypass the Project Manager assignment channel.
7. Leave polling cadence, file-watching or polling implementation, runtime
   identity, permissions, and isolation unresolved. Do not claim that a
   Markdown queue supplies delivery, authentication, or access-control
   guarantees.

The [local agent Builder workflow](../process/local-agent-builder.md) and
[message templates](../templates/builder/messages.md) describe the queue
convention. This decision does not change the v1.0.0 core artifact schema or
existing lifecycle and approval routes.

## Consequences

- The `To` column gives each long-running agent a simple, stable subscription
  filter.
- The Project Manager is accountable for queue health and agent prompting,
  while senders can address messages directly.
- A work request identifies its intended worker role without confusing that
  role with the message recipient or with a formal assignment.
- An assigned agent discovers work by polling for an assignment notification
  addressed to its exact agent ID.
- Queue polling and state updates require a local operating convention. The
  Markdown record alone cannot prove delivery, acknowledgement, or identity.

## Alternatives

| Alternative | Disposition |
| --- | --- |
| Treat the board only as a static index | Not selected; the board is the queue polled by addressed agents. |
| Use the requested worker role as the `To` recipient | Not selected; `To` identifies one stable agent address. A work request for another role is addressed to the Project Manager and names the requested role separately. |
| Let a queue message assign work directly | Not selected; the Project Manager remains the formal assigner. |
| Select a runtime or polling interval in this record | Not selected; runtime and cadence require separate design. |

## Related decisions and specifications

- [GOV-OD17](../governance/owner-decisions-2026-11-11.md): queue, polling, and work-request routing decision.
- [GOV-OD16](../governance/owner-decisions-2026-11-11.md): local Builder records, stable agent addresses, and PM responsibilities.
- [Local agent Builder workflow](../process/local-agent-builder.md): operational procedure.
- [Message queue template](../templates/builder/messages.md): queue columns and polling rules.
- [Direct message template](../templates/builder/message-record.md): message fields and request routing.
- [Work-assignment contract](../templates/artifacts/work-assignment.md): formal assignment authority.
- [Open decisions](../governance/open-decisions.md): polling implementation and runtime enforcement remain open.
