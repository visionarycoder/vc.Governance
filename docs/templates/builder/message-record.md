---
metadata-version: 1.0.0
title: Local Builder direct message template
description: Record a direct, addressable message between project agents.
document-type: template
repository: vc.Governance
language: Standard Technical English
updated: 2026-11-11
version: # VERSION
1.0.0
last_updated: 2026-11-14
---

# Local Builder direct message template

Publish one immutable Markdown file per message under `.builder/messages/`, using a unique filename such as `MSG-<message-id>.md`. Follow the [atomic-publication contract](../../process/local-agent-builder.md#publication-and-concurrent-write-contract): write a uniquely named `.tmp` file, validate and close it, then rename it on the same filesystem without overwriting a destination. Published files are the authoritative queue. The Project Manager summarizes them on `.builder/messages.md`; senders do not edit the board. A message is communication, not a work assignment, approval, or decision.

## Message

| Field | Value |
| --- | --- |
| Message ID | `<unique message ID>` |
| Created | `<date and time with timezone>` |
| From | `<project-id/agent-id>` |
| To | `<project-id/agent-id>` |
| Related message ID | `<original message ID for acknowledgement/response/resolution, otherwise none>` |
| Related work item | `<WI-id or none>` |
| Message kind | `<question/information/work-item-request/work-assignment/blocker/review-feedback/acknowledgement/response/resolution>` |
| Requested agent role | `<role to assign for a work-item request, otherwise none>` |
| Response requested by | `<date and time, or none>` |

### Subject

`<Short subject>`

### Message

`<One clear request, question, update, or finding. Link the exact files and revisions needed to understand it.>`

### Requested response or action

`<State what the recipient should reply with. To request a new work item, address the message to the Project Manager and identify the requested agent role. The Project Manager decides whether and how to create and assign the work.>`

### Outcome or evidence

`<For an acknowledgement, state receipt only. For a response, supply the requested information. For a resolution, state the disposition and link its evidence. Use none for an initial request without outcome evidence.>`

## Use

- Use the recipient's exact stable project address. Do not infer identity or authority from an address or role label.
- For a request to create work for another agent, set `To` to the Project Manager's address and identify the requested agent role. The message's `To` is the queue recipient; the requested role is the intended worker type.
- For an assignment notification, set `To` to the assigned agent's exact address and link both the work item and the formal Work Assignment.
- Link relevant work items, requirements, designs, code revisions, or tests. Do not copy a large document into the message.
- A recipient may answer directly within its role. A request to change scope, requirements, contracts, test expectations, assignments, or approvals follows the existing owner and decision routes.
- If the message asks for work, the Project Manager creates or updates a work item, verifies prerequisites, and issues the applicable assignment.
- Publish acknowledgements, responses, and resolutions as new files with new IDs, addressed to the original sender and referencing its original message ID. Never add a response or status to an already published file.
- Do not automatically acknowledge acknowledgements. Receipt is not completion; a response is not a resolution unless a separate resolution message records the disposition and evidence.
- Preserve published messages unchanged. Corrections are new linked messages. Queue status is derived in the PM-maintained summary, not stored as mutable state in the original.
