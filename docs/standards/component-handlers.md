---
metadata-version: 1.0.0
title: Internal component handlers
description: Require internal handlers that keep implementation details out of component service classes.
document-type: implementation-constraint
repository: vc.Governance
language: Standard Technical English
updated: 2026-11-09
version: # VERSION
1.0.0
last_updated: 2026-11-14
---

# Internal component handlers

**Authority:** human-owner decision GOV-OD10 on 2026-11-09, recorded in the
[owner architecture policy](../governance/owner-architecture-policy.md).
**Classification:** mandatory owner implementation constraint within The Method.
The handler requirement is not attributed to Löwy or added to the source-derived
Method rule records.

## Scope and requirements

Every approved component uses internal handlers to hold implementation details
outside its service implementation class. This includes Manager, Engine and
ResourceAccess components. The accepted system design identifies components;
a class, folder or library does not become a component merely by its name.

| ID | Condition | Required action |
| --- | --- | --- |
| HANDLER-01 | Implementing an approved component | Delegate operation implementation from the service implementation class to internal handlers within that component. Keep the service class focused on its reviewed contract entrypoints and delegation. |
| HANDLER-02 | Assigning handler responsibilities | Keep each handler within the owning component's approved responsibility, volatility boundary and detailed design. Handlers do not create new system components or public service contracts. |
| HANDLER-03 | A service calls one of its internal handlers | Treat the call as an internal collaborator call. Do not require a component proxy solely for that call. |
| HANDLER-04 | A handler calls another component | Use the approved caller-facing contract and mandatory proxy chain. Do not call another component's handler or concrete service implementation directly. |
| HANDLER-05 | Delegating an operation | Preserve reviewed results, failures, cancellation, authorization and other applicable boundary policies. Delegation cannot bypass the approved entrypoint or proxy chain. |
| HANDLER-06 | Preparing detailed design and verification | Identify operation-to-handler mapping, handler responsibilities, dependencies, wiring, lifetimes and verification in the existing detailed-design fields. Retain required review before construction. |

The service class remains the implementation of the reviewed component contract.
Its handlers are component-private collaborators, not alternate caller-facing
endpoints. Preserve that logical privacy through the approved language and packaging
mechanisms. External callers cannot resolve or invoke handlers as a boundary bypass.

The component retains its Method role when behavior moves into a handler. A
Manager's handlers implement its orchestration responsibility. An Engine's handlers
implement its encapsulated decisions or algorithms. ResourceAccess handlers
implement access to approved resources. Moving code into a handler does not permit
new component interactions or functional decomposition of the system.

## Detailed-design choices

The Application Architect decides handler granularity and relationships inside the
accepted boundary. This policy does not require one handler per operation, CQRS,
a mediator library, a dispatcher, a separate handler project or a new transport.
Do not generate handlers from a list of business features as a substitute for
volatility-based system design. Reuse suitable existing collaborators and reusable
Ifx mechanisms instead of creating duplicate infrastructure.

Use the existing [detailed-design contract](../templates/artifacts/detailed-design.md):
record the mapping and implementation structure in `internal_design`, permitted
collaborators and component edges in `dependency_constraints`, and verification
in `testability`. Handler methods do not become extra public service operations.
Do not apply service-contract operation counts to internal handler methods as if
they were independent service contracts.

The Solution Architect reviews and accepts detailed design with Test Architect
input before handoff. The Project Manager assigns the work. A discovered refinement
returns to the Application Architect before construction proceeds under it.
The developer constructs the component and white-box test client together.
The [service lifecycle](../process/service-lifecycle.md) and existing acceptance
routes remain unchanged.

## Verification and adoption

Review the exact submitted revision for these outcomes:

1. Every approved component delegates implementation details to internal handlers.
2. Service entrypoints reach the intended handlers and preserve contract behavior.
3. Handlers remain inside the approved responsibility and dependency bounds.
4. Internal calls are not incorrectly treated as cross-component proxy calls.
5. Calls to other components traverse the approved contract and proxy chain.
6. Tests cover handler behavior and service delegation, including applicable failures,
   cancellation and boundary policies. Isolated handler tests do not replace
   contract, composition or integration verification.

Apply [change and approval validity](../governance/change-approval-validity.md) to
affected existing designs and evidence. Do not report prior submissions as conforming
without reassessment. The Solution Architect and Project Manager assess project
consequences before revised commitments use their existing acceptance route.

This document establishes the constraint, not executable enforcement. Reusable
generators, analyzers and tests belong in vc.Ifx under
[repository ownership](../implementation/repository-ownership.md). Component maps,
public contracts and reviewed internal designs determine scope; handler suffixes
alone cannot prove conformance. No sibling repository or application is changed
by this policy record.
