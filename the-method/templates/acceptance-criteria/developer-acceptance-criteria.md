---
address: template/acceptance-criteria/developer
type: template
owner: agent/aa
authority: agent/aa
aliases: [developer-acceptance-criteria]
tags: [acceptance, criteria, developer-acceptance-criteria]
version: 1.0.0
last_updated: 2026-11-14
---

# Developer Acceptance Criteria

## Identity

- Work: `work/...`
- Developer: `agent/dev/...`
- Application Architect: `agent/aa/...`
- Requirement(s):
- Detailed Design:
- Base Revision(s):

## Implementation

- [ ] Assigned requirements are correctly implemented.
- [ ] Implementation conforms to the approved Detailed Design and applicable System Design.
- [ ] Relevant existing implementation and Surface Area entries were reviewed.
- [ ] The implementation uses existing capabilities when permitted and appropriate.
- [ ] No component ownership boundary was bypassed.
- [ ] No unrelated behavior was changed.

## Unit Tests

- [ ] Unit tests required by the implementation are created by the Developer.
- [ ] SA-defined coverage requirements are satisfied.
- [ ] All associated unit tests pass.

## Artifacts

- [ ] Only artifacts the Developer is authorized to modify were changed.
- [ ] Required Surface Area changes were routed to the owner.
- [ ] Newly discovered cross-component work was routed through the AA and PM.

## Evidence

- Implementation:
- Unit tests:
- Test results:
- Coverage evidence:
- Related decisions:

## Acceptance

> [!important]
> The Developer reports the work ready. The proper authority accepts the result. The PM closes the work item.

- Status: `pending | accepted | rejected`
- Accepted By: `agent/...`
