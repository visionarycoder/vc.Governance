---
title: Developer Implementation Checklist
address: checklist/developer/implementation
type: implementation-standard
owner: agent/sa
status: active
tags: [developer-implementation-checklist, implementation, standards]
aliases: [developer-implementation-checklist]
version: 1.0.0
last_updated: 2026-11-14
---

# Developer Implementation Checklist

## Before implementation

- [ ] Load the assigned work-item file.
- [ ] Resolve the requirement, design, contract, and Surface Area addresses.
- [ ] Confirm artifact ownership.
- [ ] Inspect the existing implementation and relevant suite surface.
- [ ] Confirm that no parallel work modifies the same authoritative artifact.

## During implementation

- [ ] Make the smallest complete change.
- [ ] Preserve VBD and component boundaries.
- [ ] Use approved dependencies and framework targets.
- [ ] Add or update unit tests.
- [ ] Keep unrelated artifacts out of working context.
- [ ] Stop and message the AA when the design is insufficient or conflicting.

## Before ready-for-review

- [ ] Build succeeds.
- [ ] Analyzers and formatting checks pass.
- [ ] Unit tests pass.
- [ ] Coverage requirements are met.
- [ ] Documentation and Surface Area entries are current.
- [ ] Decisions and exceptions are recorded.
- [ ] No secret or sensitive data was introduced.
- [ ] The work item lists changed revisions.
