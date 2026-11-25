---
title: Nullability and Type Safety
address: standard/implementation/nullability
type: implementation-standard
owner: agent/sa
status: active
tags: [implementation, nullability-and-type-safety, standards]
aliases: [nullability-and-type-safety]
version: 1.0.0
last_updated: 2026-11-14
---

# Nullability and Type Safety

## Rules

- Enable nullable analysis for new code.
- Treat nullable warnings as defects unless an explicit exception exists.
- Model optional values deliberately.
- Do not use the null-forgiving operator to silence uncertainty without proof.
- Validate external input at the boundary.
- Prefer domain types over primitive values when invalid combinations are otherwise easy to create.
- Use enums only for closed sets with stable semantics.
- Use generics as opaque implementation details unless the type crosses a governed boundary.
