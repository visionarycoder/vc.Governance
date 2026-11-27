---
title: Architecture and VBD Boundaries
address: standard/implementation/architecture-vbd
type: implementation-standard
owner: agent/sa
status: active
tags: [architecture-and-vbd-boundaries, implementation, standards]
aliases: [architecture-and-vbd-boundaries]
version: 1.2.0
last_updated: 2026-11-27
---

# Architecture and VBD Boundaries

## Component types

- **Client** – consumes the suite; highest expected rate of change.
- **Manager** – orchestrates workflows for a domain.
- **Engine** – focused business or computational behavior, name-coupled to its handler types.
- **Access** – query and persistence patterns; lowest expected rate of change.
- **Contract** – defines the approved component boundaries.
- **IFX** – the suite-local software framework holding generalized, consolidated code so components avoid duplication.
- **Util** – cross-cutting concern handlers, named `Suite.Util.<Capability>`; see util-components.

## Call hierarchy (closed list)

The only permitted cross-component call patterns are:

| Caller | May call |
|--------|----------|
| Client | Manager |
| Manager | Engine, Access |
| Engine | Access |
| Any component | IFX, any Util |

- No other cross-component call patterns are allowed. A Client must never call an Engine or Access component directly.
- Engines must not call other Engines.
- Manager to Manager is permitted only indirectly, through the approved message bus. The calling manager acts as a **virtual client** of the called manager and may consume only its public contract.
- A Client may communicate with a Manager through the same approved message bus.
- Generic types remain opaque unless they cross a governed boundary.

## Internal structure

- Managers, Engines, and Access components implement their behavior using handler patterns internally.
- Dependency injection and lifecycle rules must preserve component boundaries.
- Adding or moving code into IFX is an architectural decision owned by the IFX Application Architect.

## Volatility ordering

The rate of change is highest in Clients and lowest in Access components: Client > Manager > Engine > Access. Boundaries exist to contain this volatility.

## Change rule

A Developer must not bypass a boundary to reuse convenient code. Escalate reuse or extraction needs to the owning Application Architect. Cross-component sharing requires an approved design and PM-orchestrated work.

When a DA researching existing code finds a possible match with code already in the suite, the [IFX reuse-escalation](../../../software-delivery-governance/workflows/ifx-reuse-escalation.md) workflow applies: the originating DA waits in a zero-cost pause until the IFX build and the source migration are complete, and the PM notifies it to resume.

## Stop conditions

Stop and message the owning Application Architect when:
- the work requires an unapproved dependency;
- a component must call through another component's internals;
- existing code cannot be reused without violating ownership;
- the implementation conflicts with the System Design or Detailed Design;
- the implementation conflicts with the code quality or coding standards.
