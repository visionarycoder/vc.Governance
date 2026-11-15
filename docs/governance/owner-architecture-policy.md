---
metadata-version: 1.0.0
title: Owner architecture policy
description: Index owner-selected architecture constraints separately from the adopted Method.
document-type: owner-decision
repository: vc.Governance
language: Standard Technical English
updated: 2026-11-09
version: # VERSION
1.0.0
last_updated: 2026-11-14
---

# Owner architecture policy

The human owner defines implementation constraints within the adopted Method.
These constraints are not additional statements attributed to Juval Löwy.
The [source authority](source-authority.md) and [design standard](../standards/design-standard.md)
continue to govern decomposition, permitted interactions and design responsibility.

## Adopted constraints

| Constraint | Authority | Controlling specification |
| --- | --- | --- |
| Use current Microsoft technical guidance within the approved baseline; prohibit underscore naming prefixes | Human-owner decision on 2026-11-07 | [Technical standard](../standards/microsoft-technical-standard.md) |
| Require DI-capable proxies between components; generate typed local proxies and prohibit reflection-based proxy dispatch | Human-owner decision on 2026-11-07 | [Component proxies](../patterns/component-proxies.md) |
| Use internal handlers in every component to move implementation details out of the service implementation class | GOV-OD10, human-owner instruction on 2026-11-09 | [Component handlers](../standards/component-handlers.md) |

This index does not duplicate the controlling rules or select an application stack.
Future preferences must state whether they are mandatory constraints, preferred
defaults or proposals. An unresolved preference is not an adopted requirement.

## GOV-OD10: Internal component handlers

**Status:** adopted owner implementation constraint, recorded on 2026-11-09.

The human owner instructed: "I want handlers inside of every component to offload
the implementation details from the service implementation class."

The [handler specification](../standards/component-handlers.md) defines the boundary
and review implications. [ADR 0002](../adr/0002-internal-component-handlers.md)
records the rationale and trade-offs. This decision does not approve any particular
application design, implementation, artifact revision or departure from The Method.

## Responsibility and change

The human owner controls changes to these owner-selected constraints. The Solution
Architect preserves the system design and reviews delegated detailed design.
The Application Architect selects handler responsibilities and structure inside
each accepted component. Existing [decision routes](decision-and-approval-matrix.md)
remain unchanged. Workers cannot omit a mandatory constraint for convenience.
Project adoption and affected prior evidence follow
[change and approval validity](change-approval-validity.md); this record does not
assign a worker or authorize an unreviewed migration.
