---
title: API and Library Design
address: standard/implementation/api-library
type: implementation-standard
owner: agent/sa
status: active
tags: [api-and-library-design, implementation, standards]
aliases: [api-and-library-design]
version: 1.0.0
last_updated: 2026-11-14
---

# API and Library Design

## Rules

- Design APIs for the consumer, not for internal convenience.
- Keep public surfaces small and cohesive.
- Validate arguments at the boundary.
- Use established .NET naming and exception conventions.
- Avoid public mutable fields.
- Use interfaces where a boundary or substitution requirement exists, not automatically for every type.
- Avoid boolean parameters when they obscure behavior; prefer a precise option type, Enumerables or separate operation.
- Preserve binary and source compatibility when required by the contract.
- Expose asynchronous APIs for naturally asynchronous I/O.
- Accept `CancellationToken` for cancellable operations and pass it through.
- Do not return internal mutable collections directly.
- Document thread-safety guarantees.
