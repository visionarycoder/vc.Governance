---
metadata-version: 1.0.0
title: ADR 0002: Internal component handlers
description: Record the owner's decision to delegate component implementation details to internal handlers.
document-type: governance-policy
repository: vc.Governance
language: Standard Technical English
updated: 2026-11-09
version: # VERSION
1.0.0
last_updated: 2026-11-14
---

# ADR 0002: Internal component handlers

## Status

Accepted as a record of the human owner's explicit instruction on 2026-11-09,
[GOV-OD10](../governance/owner-architecture-policy.md). This records an owner
implementation constraint. It does not issue operational artifact approval.

## Context

The human owner wants handlers inside every component to remove implementation
details from the service implementation class. The system must retain its accepted
volatility boundaries and reviewed service contracts while using that internal
structure. Source review remains separately recorded. This decision does not
claim a new source review or change the source-derived item map.

The governing [design standard](../standards/design-standard.md) maps C-D-2 and
C-D-3 to volatility-based decomposition and behavioral composition, Appendix C,
printed p. 426 of [Righting Software](https://www.amazon.com/dp/0136524036).
Those existing constraints remain in force. They are not evidence that Löwy
mandates this particular handler arrangement.

## Decision

Adopt [internal component handlers](../standards/component-handlers.md) as the
controlling specification. Every approved component delegates implementation
details from its service implementation class to handlers within its boundary.
The component retains its Manager, Engine or ResourceAccess responsibility.

Handlers are internal collaborators. Calls to them are excluded from the
component-proxy requirement by PROXY-08. Handler calls to another component remain
subject to the full [proxy policy](../patterns/component-proxies.md) and accepted
system interaction graph. A handler is not an alternate public endpoint.

The Application Architect determines internal granularity through reviewed detailed
design. No mediator library, one-handler-per-operation rule or application stack
is selected. Existing assignment, review and acceptance responsibilities remain.

## Consequences

- Service classes retain contract entrypoints and delegation while handlers hold
  implementation details and can be exercised through the white-box test client.
- Detailed designs must identify handler responsibilities, dependencies and wiring.
- Handler tests supplement service-contract, proxy composition and integration tests.
- Additional collaborators increase wiring and navigation work. Keep that structure
  proportionate without omitting the owner's mandatory handler requirement.
- Affected accepted designs require applicability reassessment before changed work
  proceeds. This record does not approve an automatic application migration.

## Alternatives

| Alternative | Disposition |
| --- | --- |
| Keep operation implementation details in service classes | Does not satisfy the owner's explicit instruction |
| Make every handler a separate system component | Confuses internal detailed design with volatility-based system decomposition |
| Require a handler framework or one handler per operation | Adds a choice the owner did not make; retain detailed-design discretion |

These alternatives explain trade-offs. They do not claim an earlier deliberation
or confer approval on a particular implementation.

## Related decisions

- [Owner architecture policy](../governance/owner-architecture-policy.md): decision basis and authority.
- [ADR 0001](0001-approval-process-structure.md): unchanged review and approval boundaries.
- [Source authority](../governance/source-authority.md): distinction between Method and owner constraints.
- [Change and approval validity](../governance/change-approval-validity.md): affected revision reassessment.
