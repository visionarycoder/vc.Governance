---
title: Serialization and Compatibility
address: standard/implementation/serialization
type: implementation-standard
owner: agent/sa
status: active
tags: [implementation, serialization-and-compatibility, standards]
aliases: [serialization-and-compatibility]
version: 1.0.0
last_updated: 2026-11-14
---

# Serialization and Compatibility

## Rules

- Treat serialized formats as contracts.
- Specify property naming, null handling, required members, version behavior, and unknown-member handling.
- Prefer explicit DTOs at boundaries.
- Do not serialize internal domain or persistence types directly across governed boundaries.
- Avoid unsafe polymorphic deserialization.
- Preserve backward compatibility when required by the contract.
- Add compatibility tests for durable or externally consumed formats.
