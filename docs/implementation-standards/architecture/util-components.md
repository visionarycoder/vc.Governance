---
title: Util Components
address: standard/implementation/util-components
type: implementation-standard
owner: agent/sa
status: active
tags: [util-components, implementation, standards]
aliases: [util-components, utilities]
version: 1.0.0
last_updated: 2026-11-25
---

# Util Components

## Definition

A Util is a component that handles cross-cutting concerns shared across the suite. Utilities are usually static helpers.

## Rules

- A Util must not contain business-related content.
- A Util is named `Suite.Util.<Capability>` (for example `Suite.Util.Json` or `Suite.Util.Clock`).
- A Util may hide a complete VBD stack (Manager, Engine, Access) behind a single entry library. The entry library is the only project other components may reference; the stack behind it is an implementation detail of the Util.
- Every component type may call IFX and any Util.

## Ownership

- Each Util has exactly one durable Application Architect and one developer agent.
- The developer agent is tightly coupled to its Util and does not implement work for other Util or component code.
- The Application Architect owns the Util's public surface and the decision of what belongs in it.

## Suggested project shape

```text
Suite.Util.<Capability>/                  # entry library (only visible project)
  <internal VBD stack, if any>            # hidden behind the entry library
Suite.Util.<Capability>.UnitTests
```
