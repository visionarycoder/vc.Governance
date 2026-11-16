---
title: .NET Framework Guidance
address: standard/implementation/dotnet-framework
type: implementation-standard
owner: agent/sa
status: active
tags: [dotnet-framework-guidance, implementation, standards]
aliases: [dotnet-framework-guidance]
version: 1.0.0
last_updated: 2026-11-14
---

# .NET Framework Guidance

## Applicability

Use .NET Framework only where an approved dependency, hosting model, operating environment, or migration constraint requires it.

## Rules

- Use the newest approved and supported .NET Framework target compatible with the environment.
- Prefer SDK-style projects when migration and tooling constraints permit.
- Isolate framework-only APIs behind owned boundaries.
- Do not introduce .NET Remoting, BinaryFormatter, Code Access Security, or partial-trust designs.
- Prefer modern HTTP, serialization, dependency injection, and logging libraries that support the selected target.
- Avoid adding new dependencies on obsolete technologies when a compatible supported alternative exists.
- Add characterization tests before changing legacy behavior.
- Record migration constraints and modernization seams in the design.
- Keep shared libraries compatible with all declared consumers; multi-target only when the cost is justified.

## Migration rule

Modernization must preserve contract behavior or use an approved Change Set for intentional behavior change.
