---
title: Implementation Standards
address: standard/implementation
type: implementation-standard
owner: agent/sa
status: active
tags: [implementation, implementation-standards, standards]
aliases: [implementation-standards]
version: 1.0.0
last_updated: 2026-11-14
---

# Implementation Standards

> [!abstract] Purpose
> These standards constrain implementation after the approved System Design and Detailed Design exist. They do not replace [[software-delivery-governance]] or [[the-method]].

## Standards hierarchy

```text
Governance
    ↓
The Method
    ↓
Implementation Standards
    ↓
Approved implementation
```

## Core rules

1. Follow the approved System Design and Detailed Design.
2. Respect component ownership and VBD boundaries.
3. Make the smallest complete change that satisfies the work item.
4. Do not introduce cross-component access outside approved contracts.
5. Create unit tests for changed behavior.
6. Treat warnings, analyzer findings, and failed tests as implementation defects unless explicitly approved.
7. Record exceptions as decision records.

## Index

### Architecture and organization
- [[architecture-and-vbd-boundaries]]
- [[solution-and-project-organization]]
- [[contracts-and-public-surface]]
- [[dependency-injection-and-lifetimes]]

### Code quality
- [[csharp-coding-standard]]
- [[api-and-library-design]]
- [[error-handling-and-diagnostics]]
- [[asynchronous-programming]]
- [[nullability-and-type-safety]]
- [[performance-and-resource-management]]

### Data, security, and operations
- [[data-access-standards]]
- [[security-standards]]
- [[configuration-and-secrets]]
- [[observability-standards]]
- [[serialization-and-compatibility]]

### Verification and delivery
- [[unit-testing-standards]]
- [[integration-and-black-box-test-support]]
- [[build-and-continuous-integration]]
- [[package-and-dependency-management]]
- [[documentation-standards]]
- [[definition-of-done]]

### Framework guidance
- [[modern-dotnet-guidance]]
- [[dotnet-framework-guidance]]
- [[aspdotnet-core-guidance]]

### Operational aids
- [[developer-implementation-checklist]]
- [[application-architect-review-checklist]]
- [[implementation-exception-record]]
- [[sources]]
