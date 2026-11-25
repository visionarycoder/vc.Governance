---
title: Modern .NET Guidance
address: standard/implementation/modern-dotnet
type: implementation-standard
owner: agent/sa
status: active
tags: [implementation, modern-dotnet-guidance, standards]
aliases: [modern-dotnet-guidance]
version: 1.0.0
last_updated: 2026-11-14
---

# Modern .NET Guidance

## Rules

- Target the approved supported .NET version for the application suite.
- Pin the SDK with `global.json` when build reproducibility requires it.
- Use SDK-style projects.
- Prefer built-in dependency injection, configuration, logging, hosting, and HTTP abstractions unless the approved design requires another mechanism.
- Enable nullable reference types and implicit usings according to repository policy.
- Use analyzers and centralized build properties.
- Use `IHttpClientFactory` or the approved equivalent for managed HTTP connection reuse.
- Use asynchronous APIs for I/O.
- Publish using explicit runtime and deployment settings.
- Verify trimming, native AOT, and single-file publishing only when the application intends to use those features.
