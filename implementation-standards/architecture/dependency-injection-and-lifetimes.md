---
title: Dependency Injection and Lifetimes
address: standard/implementation/dependency-injection
type: implementation-standard
owner: agent/sa
status: active
tags: [dependency-injection-and-lifetimes, implementation, standards]
aliases: [dependency-injection-and-lifetimes]
version: 1.0.0
last_updated: 2026-11-14
---

# Dependency Injection and Lifetimes

## Rules

- Register services at the composition root owned by the appropriate component or host.
- Constructor injection is the default.
- Do not use service location in business code.
- Select lifetimes deliberately and document non-obvious choices.
- Never capture a scoped service in a singleton.
- Dispose owned resources deterministically.
- Use factories when runtime creation is part of the approved design.
- Do not use dependency injection to hide forbidden component coupling.
- Validate the service graph during startup or build verification when supported.
