---
title: Application Architect Review Checklist
address: checklist/application-architect/implementation-review
type: implementation-standard
owner: agent/sa
status: active
tags: [application-architect-review-checklist, implementation, standards]
aliases: [application-architect-review-checklist]
version: 1.0.0
last_updated: 2026-11-14
---

# Application Architect Review Checklist

## Design compliance

- [ ] The implementation satisfies the assigned requirement.
- [ ] The component Detailed Design is respected.
- [ ] Contracts and public surface are correct.
- [ ] Component ownership boundaries remain intact.
- [ ] No unauthorized dependency was introduced.
- [ ] Shared code was not extracted without approval.

## Quality

- [ ] Code is clear, focused, and correctly named.
- [ ] Error, cancellation, nullability, and compatibility behavior are explicit.
- [ ] Developer unit tests cover changed behavior.
- [ ] SA coverage requirements are met.
- [ ] Operational diagnostics are adequate.
- [ ] Security and data handling conform to standards.

## Governance

- [ ] Changed artifacts have the correct owner.
- [ ] Required Change Set and decision records exist.
- [ ] Surface Area and documentation are updated.
- [ ] Any design-shape change has SA approval.
