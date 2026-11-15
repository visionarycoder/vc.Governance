---
metadata-version: 1.0.0
title: Local Builder work item template
description: Describe a bounded work request and link it to required governance assignments.
document-type: template
repository: vc.Governance
language: Standard Technical English
updated: 2026-11-11
version: # VERSION
1.0.0
last_updated: 2026-11-14
---

# Local Builder work item template

Create one file per work item under `.builder/work-items/`, using a unique ID such as `WI-<project-key>-<sequence>`. The Project Manager owns creation, assignment, reassignment, status transitions, and closure. This ticket supports coordination; it does not replace a formal Work Assignment, accepted requirements, design, test plan, or decision.

## Work item

| Field | Value |
| --- | --- |
| Work item ID | `<unique ID>` |
| Title | `<specific outcome>` |
| Type | `<requirements/design/implementation/test/review/integration/fix/other>` |
| State | `<proposed/ready/assigned/in progress/blocked/submitted/in review/changes requested/accepted/closed/cancelled>` |
| Created by | `<Project Manager identity>` |
| Requested by | `<role and agent address, or stakeholder identity>` |
| Requested agent role | `<role requested, if the request came through a work-item-request message>` |
| Assigned to | `<one stable agent address or unassigned>` |
| Created at | `<date and time with timezone>` |
| Parent or related items | `<IDs or none>` |
| Dependencies | `<IDs and required outcomes, or none>` |
| Component | `<component ID or project-wide>` |

## Objective and scope

### Problem or need

`<Describe the observed problem or requested outcome.>`

### Desired outcome

`<Describe the result without prescribing an unapproved design.>`

### In scope

- `<Bounded behavior, files, artifacts, and outputs>`

### Out of scope

- `<Explicit exclusions>`

### Acceptance and completion evidence

- `<Observable acceptance criterion>`
- `<Required tests, review, or evidence and where it will be recorded>`

## Governing inputs

| Input | Exact path and revision | Why it applies |
| --- | --- | --- |
| Requirement | `<path and revision>` | `<behavior to implement>` |
| System design | `<path and revision>` | `<component boundaries and interactions>` |
| Detailed design | `<path and revision>` | `<component contracts and implementation design>` |
| Test plan | `<path and revision or not applicable>` | `<verification basis>` |
| Application surface | `<path and revision>` | `<existing component/contract/method lookup>` |
| Work Assignment | `<path and revision or pending/not required>` | `<PM authorization for this work>` |

For governed artifacts, identify the immutable artifact revision and required approval evidence. A path or current branch name alone does not establish approval. Resolve references under the project's artifact contract.

## Constraints and permitted outputs

- **Behavior to preserve:** `<existing behavior and compatibility requirements>`
- **Technical and authority boundaries:** `<applicable constraints>`
- **Permitted edit paths:** `<exact files or bounded directories>`
- **Permitted outputs:** `<code, tests, documents, reports>`
- **Required consultations:** `<owner to consult before an in-scope refinement>`

## Coordination

| Update | Date and time | Agent address | Summary and evidence |
| --- | --- | --- | --- |
| `<progress/blocker/submission/review>` | `<timestamp>` | `<address>` | `<concise update with links>` |

## Decision and closure evidence

- **Review or decision record:** `<exact path and revision, or pending>`
- **Verification evidence:** `<exact paths, revisions, command, and result>`
- **Authorized acceptance:** `<decider, capacity, action, and exact subject revision, or pending>`
- **Project Manager closure:** `<date and rationale, or pending>`

## State rules

The Project Manager changes the state after reviewing the linked evidence. Agents may request `blocked`, `submitted`, or another transition through an update, but do not assign or close their own work. `Accepted` and `closed` require the applicable authorized acceptance evidence; they are not synonyms for a completed code change. If a prerequisite is missing, keep the work blocked and identify the missing input.

When an agent needs work performed by another role, it may send a `work-item-request` message to the Project Manager's address and identify the requested agent role. The Project Manager creates or updates this work item, selects an appropriate agent address (creating or rehydrating an agent when no active agent of that role can take the work), and issues the required assignment before work begins. The Project Manager then queues a `work-assignment` notification to that agent with links to this work item and the formal assignment. The requested role is routing information, not an assignment or guarantee that the request will be approved.
