---
title: Component Call Hierarchy and Util Components
address: governance/decision-records/component-call-hierarchy-and-util-components
owner: agent/ceo
status: accepted
aliases: []
tags: [decision-record]
version: 1.3.0
last_updated: 2026-11-27
---

# Decision Record – Component Call Hierarchy and Util Components

## Context

The suite needs one unambiguous rule set for which component types may call which, where shared code lives, and how cross-cutting concerns are implemented.

## Decision

1. Closed call hierarchy: Client → Manager; Manager → Engine or Access; Engine → Access; any component → IFX or any Util. Manager → Manager only indirectly through the approved message bus, with the calling manager acting as a virtual client of the called manager's public contract. Clients may use the same message bus to reach Managers.
2. Volatility ordering: Client (highest) > Manager > Engine > Access (lowest).
3. Manager, Engine, and Access components use handler patterns internally.
4. IFX is the suite-local software framework holding generalized, consolidated code; adding or moving code into IFX is an architectural decision owned by the IFX Application Architect.
5. Util components (`Suite.Util.<Capability>`) handle cross-cutting concerns, contain no business-related content, may hide a complete VBD stack behind a single entry library, and each has exactly one durable Application Architect and one developer agent.
6. The IFX reuse-escalation workflow: a DA finding a possible match escalates to its AA (read-only review), the AA requests it from the IFX AA, the IFX AA defines the reusable code and the PM tickets the build to the IFX DA, the PM creates additional tickets for the source AA and DA to update the existing originating code to use the shared IFX code, and the PM removes the block and notifies the originating DA to continue.
7. The PM owns the execution flow of the tickets, oversees all work efforts as the monitor, and is responsible for how to restart the effort of any agent that fails to respond or times out.
8. A blocked DA is in a zero-cost pause, which is not an additional phase in the states of an agent; the DA does not notice its block being removed, and the PM notifies it to continue by rescanning the Surface Area and leveraging the IFX shared code in place of creating duplicated code.
9. A DA must read the Surface Area before it builds an implementation plan; the implementation plan must be reviewed and approved before the DA starts writing code. Clone detection reuses the same surface-area review guidance and compares written code for duplicates; a detected duplicate triggers the IFX reuse-escalation workflow.
10. The PM role is fulfilled by the coding harness running the process.

## Consequences

- architecture-and-vbd-boundaries, solution-and-project-organization, and util-components standards updated; solution-architect checklist extended.
- Existing code that violates the closed call hierarchy must be refactored into conformance (refactoring pattern to be defined separately).
- The IFX reuse-escalation workflow is defined in ifx-reuse-escalation; the PM role and checklist are extended with execution-flow ownership, effort restart, and unblock notification.
