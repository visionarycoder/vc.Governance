---
title: Performance and Resource Management
address: standard/implementation/performance
type: implementation-standard
owner: agent/sa
status: active
tags: [implementation, performance-and-resource-management, standards]
aliases: [performance-and-resource-management]
version: 1.0.0
last_updated: 2026-11-14
---

# Performance and Resource Management

## Rules

- Correctness and maintainability precede speculative optimization.
- Measure before and after performance changes.
- Identify hot paths with representative workloads.
- Avoid avoidable allocation in verified hot paths.
- Page or stream large result sets.
- Pool expensive reusable resources through approved framework mechanisms.
- Reuse HTTP connection infrastructure rather than creating clients per request.
- Dispose unmanaged and owned disposable resources deterministically.
- Add benchmarks for performance-sensitive algorithms or components.
- Record material performance tradeoffs in a decision record.
