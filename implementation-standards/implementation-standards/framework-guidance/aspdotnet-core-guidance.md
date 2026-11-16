---
title: ASP.NET Core Guidance
address: standard/implementation/aspnet-core
type: implementation-standard
owner: agent/sa
status: active
tags: [aspdotnet-core-guidance, implementation, standards]
aliases: [aspdotnet-core-guidance]
version: 1.0.0
last_updated: 2026-11-14
---

# ASP.NET Core Guidance

## Rules

- Keep request handlers thin; route business behavior to owned components.
- Use asynchronous I/O throughout request paths.
- Do not use `.Result` or `.Wait()` on request paths.
- Do not store `HttpContext` for later use or access it from multiple threads.
- Do not capture request-scoped services in background work.
- Page, stream, or bound large responses.
- Use response compression and caching only with explicit correctness and security review.
- Validate model input and return contract-defined errors.
- Use the approved authentication and authorization middleware.
- Keep long-running work outside the request lifecycle through an approved durable mechanism.
- Pool HTTP connections through framework-supported factories.
- Measure hot paths before optimization.
