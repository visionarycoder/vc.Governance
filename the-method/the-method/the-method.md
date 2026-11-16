---
title: The Method
aliases: [The Method Framework, Software Design Method, the-method]
tags: [agent-instructions, architecture, method, project-design, the-method, vbd]
address: method/the-method
owner: agent/sa
status: active
version: 1.0.0
last_updated: 2026-11-14
---
# The Method

> [!purpose]
> Define how agents exercise the authority established by [[software-delivery-governance-specification]]. Governance defines authority. The Method defines how approved authority performs analysis, design, and project planning.

## Framework

```text
Requirements
    ↓
[[system-design|System Design]]
    ↓
[[detailed-design|Detailed Design]]
    ↓
[[project-design|Project Design]]
    ↓
Governed Work Items
    ↓
Implementation and Verification
```

## Primary responsibilities

- The Solution Architect applies [[system-design|System Design]].
- Application Architects apply [[detailed-design|Detailed Design]] within SA-approved component boundaries.
- The Project Manager applies [[project-design|Project Design]] to organize and sequence implementation work.
- The Method never changes artifact ownership defined by governance.
- Method outputs are authoritative only after the approvals required by governance.

## Prime design directive

Decompose the system around volatility rather than feature/function grouping. Encapsulate likely areas of change behind stable boundaries. [^vbd]

## System Design sequence

1. [[requirements-analysis|Requirements Analysis]]
2. [[volatility-analysis|Volatility Analysis]]
3. [[decomposition|Decomposition]]
4. [[structure|Structure]]
5. [[composition|Composition]]
6. [[design-validation|Design Validation]]

## Project Design sequence

1. [[project-design|Project Design]]
2. [[activities-and-dependencies|Activities and Dependencies]]
3. [[effort-estimation|Effort Estimation]]
4. [[project-network|Project Network]]
5. [[scheduling-and-risk|Scheduling and Risk]]
6. PM creates and sequences governed work items.

## Related

- [[software-delivery-governance-specification]]
- [[ontology]]
- [[surface-area]]

[^vbd]: Juval Lowy, *Software System Decomposition*, InformIT, describes The Method's design directive as decomposition based on volatility.

## Decision Records

- [[decision-record-templates]]
