---
title: Error Handling and Diagnostics
address: standard/implementation/error-handling
type: implementation-standard
owner: agent/sa
status: active
tags: [error-handling-and-diagnostics, implementation, standards]
aliases: [error-handling-and-diagnostics]
version: 1.0.0
last_updated: 2026-11-14
---

# Error Handling and Diagnostics

## Rules

- Use exceptions for exceptional failure, not normal control flow.
- Throw the most specific appropriate exception type.
- Provide actionable messages without exposing secrets.
- Preserve the original exception as the inner exception when translating failures.
- Do not catch `Exception` unless the boundary must prevent process escape and the failure is logged or handled.
- Do not swallow exceptions.
- Convert internal failures to contract-defined outcomes only at the correct boundary.
- Include correlation identifiers in operational diagnostics.
- Keep logs structured and machine-queryable.
- Do not log credentials, tokens, secrets, or unnecessary personal data.
