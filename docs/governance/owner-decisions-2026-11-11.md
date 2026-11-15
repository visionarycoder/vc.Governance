---
metadata-version: 1.0.0
title: Owner decisions: authority, escalation, and enforcement handoff
description: Record the human owner's authority, QA escalation, enforcement handoff, and local Builder coordination decisions.
document-type: owner-decision
repository: vc.Governance
language: Standard Technical English
updated: 2026-11-11
version: # VERSION
1.0.0
last_updated: 2026-11-14
---

# Owner decisions: authority, escalation, and enforcement handoff

These are organizational assignments from the human owner. They do not change
the adopted Method, source-derived responsibilities, or existing artifact
approval routes.

| ID | Owner decision | Consequence |
| --- | --- | --- |
| GOV-OD11 | The CEO and human owner are the same human actor, acting under distinct authority capacities. The CEO is not an agent. Escalations reach this human. | Route and record a decision under the capacity that owns the requested action. The shared identity does not satisfy an independent-critic requirement or merge the capacities. |
| GOV-OD12 | The human owner approves explicit, project-specific commitment limits before the CEO accepts that project's SDP. There are no global numeric caps. | The CEO may accept the SDP and revised commitments only within the exact approved project envelope. Missing or ambiguous limits block CEO acceptance and escalate to the human owner. The human owner decides any out-of-envelope proposal in human-owner capacity; an accepted revision requires a new exact, recorded envelope decision. |
| GOV-OD13 | When a QA finding implicates the Solution Architect, or the SA does not provide a required response, QA may escalate directly to the human owner in human-owner capacity. | The human owner appoints a competent independent reviewer and decides the response. The normal QA-to-SA route remains in force for other findings. |
| GOV-OD14 | When a finding implicates the human owner / CEO, QA sends it directly to the human owner in human-owner capacity; the owner cannot review their own conduct. | The human owner appoints an independent reviewer and retains final decision authority. If no qualified reviewer is available, hold affected work and record the finding as unresolved. |
| GOV-OD15 | Close the enforcement gap at governance level by preserving an explicit implementation handoff; do not select a platform or claim runtime enforcement. | Runtime work remains open until the platform and target scope are selected and a work assignment is issued. Do not modify the owning implementation repository or platform resources without that assignment. |
| GOV-OD16 | Local project Builder coordination uses Markdown records and stable, project-scoped agent addresses. The Project Manager maintains the message board, creates and rehydrates agents, issues work assignments, and prompts agents to check the board. Agents may message each other directly; messages do not assign work or change authority. | Use the [local agent Builder workflow](../process/local-agent-builder.md) and [templates](../templates/builder/README.md). The Project Manager remains the sole formal assignment channel. This selects local coordination records, not an execution runtime, authentication, permissions, or worker isolation. |
| GOV-OD17 | The message board is a local queue. The Solution Architect, Product Owner, and Project Manager are long-running agents that poll it; agents virtually subscribe by matching `To` to their unique project address. A request for work from another agent role is addressed to the Project Manager and names the requested role. | The Project Manager maintains queue health, reconciles message states, and nudges agents. On a work request, the Project Manager creates or updates the work item, chooses an appropriate agent of the requested role, issues the assignment, and queues a linked assignment notification to that agent. Polling cadence and runtime implementation remain open. |
| GOV-OD18 | Mitigate concurrent writes with one immutable file per message, same-filesystem atomic publication without overwrite, and separate linked acknowledgement and response files. Only the Project Manager writes the rebuildable board summary. Agents poll published message files by exact `To`. | Supersedes GOV-OD17's shared-board queue storage and sender-written rows, not its polling roles, addressing, or assignment routes. Published files are authoritative. Helper implementation and verification remain a separate handoff; this does not establish full fault tolerance. |

For GOV-OD12, the project envelope states applicable scope, cost, schedule, and
resource limits. The Solution Architect and Project Manager still assess project
consequences before changed commitments are presented for acceptance. A human
owner decision outside the envelope remains subject to the Method, adopted
framework, and non-waivable directives.

The human owner stated: "The CEO is one owner/entity. When topic are escalated
they come to me. There is no CEO agent." The human owner also selected
project-specific limits approved before SDP acceptance, with no global caps.

For GOV-OD13–GOV-OD14, the human owner selected: "Direct to human owner; owner
appoints an independent reviewer and decides response" and "I retain final
authority, appoint an independent reviewer, and cannot self-review; if no
qualified reviewer is available, hold affected work and record the issue as
unresolved." Reviewer appointment does not transfer final decision authority.

For GOV-OD15, the human owner selected: "Close at governance level; preserve an
explicit handoff and leave deployment open pending platform selection and
assignment." This does not claim that runtime enforcement is deployed or
authorize a platform change.

For GOV-OD16, the human owner requested "everything to happen locally," unique
agent addresses for direct communication, and that "the project manager is
responsible for maintaining the message board and nudging the agents to look at
the message board to do work." Direct messages remain distinct from formal
work assignment. Local Markdown does not establish identity, permissions,
isolation, or executable agent orchestration.

For GOV-OD17, the human owner directed that the Solution Architect, Product
Owner, and Project Manager "should be long running agents that poll the message
board" and that agents "virtually subscribe" to messages addressed to them.
The owner also specified that a message may ask the Project Manager to create
a work item for a requested agent type. This defines the coordination contract;
it does not choose a polling interval or runtime.

For GOV-OD18, the human owner accepted the proposed concurrent-write mitigation
with "OK. Implement this idea." The accepted idea separates immutable message
publication from PM-only summary updates and keeps acknowledgements and
responses in separate files. See [ADR 0008](../adr/0008-immutable-message-publication.md).

