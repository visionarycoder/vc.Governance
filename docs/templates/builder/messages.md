---
metadata-version: 1.0.0
title: Local Builder message board template
description: Provide a Project Manager-only summary of the immutable message-file queue.
document-type: template
repository: vc.Governance
language: Standard Technical English
updated: 2026-11-11
version: # VERSION
1.0.0
last_updated: 2026-11-14
---

# Local Builder message board template

Copy this file to `.builder/messages.md` in the application project. Only the Project Manager writes this board. It is a rebuildable summary of the authoritative immutable files in `.builder/messages/`, not the queue's source of truth. Agents poll published files even when this summary is missing or stale. The Project Manager maintains the summary and prompts agents to check their messages.

## Project identity

| Field | Value |
| --- | --- |
| Project ID | `<stable-project-id>` |
| Queue maintainer | `<Project Manager agent address>` |
| Polling agents | `<Project Manager, Product Owner, Solution Architect, and other active agent addresses>` |
| Summary rebuilt at | `<date and time with timezone>` |

## Message queue summary

| Message ID | Created | From | To | Kind | Requested agent role | Work item | State | Subject or next action | Record |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| `<MSG-id>` | `<date and time>` | `<project-id/agent-id>` | `<project-id/agent-id>` | `<kind from the message template>` | `<role or none>` | `<WI-id or none>` | `<queued/acknowledged/resolved>` | `<short summary>` | `<relative message-record path>` |

## Board rules

- Each published message has one exact agent address in `To`. Use a separate message file for each recipient. Agents virtually subscribe by polling final `MSG-*.md` files for messages whose `To` matches their stable address.
- The Project Manager, Product Owner, and Solution Architect are long-running pollers. Other active agents poll according to their Builder instructions. Ignore `.tmp` files; do not rely on summary rows for complete discovery.
- Senders publish immutable files through the [publication contract](../../process/local-agent-builder.md#publication-and-concurrent-write-contract). They never write this board. The Project Manager serializes its updates and rebuilds the summary from published files.
- Recipients publish acknowledgements, responses, and resolutions as separate immutable messages linked by `Related message ID`. They never edit the original or this board. The Project Manager derives summary state from those records; acknowledgement means receipt, not completion.
- For an original request, derive `queued` when no linked receipt or outcome exists, `acknowledged` when receipt or a response exists without resolution, and `resolved` when an explicit resolution records disposition and evidence. Do not treat a response alone as completion. Linked records must reference an existing original ID and come from that original recipient; unresolved or conflicting links are reported to the PM, not accepted silently as state evidence.
- A request to create work is addressed to the Project Manager's exact address. Set `Kind` to `work-item-request` and identify the requested agent role in `Requested agent role`. The Project Manager checks the request, creates or updates the work item, and assigns it to an appropriate agent of that role.
- After issuing an assignment, the Project Manager publishes a `work-assignment` message addressed to the assigned agent. The message links the work item and formal Work Assignment; it notifies the agent but does not replace the assignment.
- A message addressed directly to another agent may ask a question, share evidence, or request role-bounded input. It does not assign work. Only a Project Manager-issued assignment creates assigned work.
- If a summary row conflicts with a published message, the Project Manager rebuilds it. If a message conflicts with authoritative work or governance records, hold the affected action and route the discrepancy to its owner.
