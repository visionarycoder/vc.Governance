---
title: Asynchronous Programming
address: standard/implementation/async
type: implementation-standard
owner: agent/sa
status: active
tags: [asynchronous-programming, implementation, standards]
aliases: [asynchronous-programming]
version: 1.0.0
last_updated: 2026-11-14
---

# Asynchronous Programming

## Rules

- Use asynchronous APIs for I/O-bound work.
- Avoid `.Wait()`, `.Result`, and synchronous blocking over asynchronous operations.
- Do not wrap naturally asynchronous I/O in `Task.Run`.
- Propagate cancellation through call chains.
- Do not use `async void` except for required event handlers.
- Await tasks or explicitly document and observe background task ownership.
- Keep shared mutable state out of concurrent execution paths.
- Do not access request-scoped state after the request has completed.
- Measure hot paths before introducing concurrency or low-level optimization.
