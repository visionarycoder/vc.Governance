---
metadata-version: 1.0.0
title: Local Builder application-surface index template
description: Index project components and link to their complete contract and method inventories.
document-type: template
repository: vc.Governance
language: Standard Technical English
updated: 2026-11-11
version: # VERSION
1.0.0
last_updated: 2026-11-14
---

# Local Builder application-surface index template

Copy this file to `.builder/application-surface/README.md`. The inventory helps agents discover existing design and implementation. It does not replace accepted requirements, detailed designs, contracts, source code, or approval evidence.

## Inventory identity

| Field | Value |
| --- | --- |
| Project ID | `<stable project ID>` |
| Inventory revision | `<immutable project revision>` |
| Maintained by | `<Solution Architect>` |
| Last reconciled | `<date and time with timezone>` |

## Components

| Component ID | Name | Short responsibility | Component surface | Accepted detailed design |
| --- | --- | --- | --- | --- |
| `<component-id>` | `<name>` | `<one-sentence purpose>` | `<relative path to component surface file>` | `<path and exact revision>` |

## Inventory rules

- Include every approved component in the project scope. Give each component a stable ID and a component-surface file.
- Each component file lists every contract and method in the agreed application scope and provides a short description and exact source/design references.
- The responsible Application Architect maintains its component entry. The Solution Architect maintains the project index and resolves cross-component or system-boundary questions.
- Before proposing a new component, contract, or method, check this inventory and its linked design. If an entry is absent, stale, or contradictory, report the discrepancy rather than assuming the element does not exist or is authorized.
- Update the relevant entry when an accepted design or implementation changes the application surface. Keep implementation details in source and design detail in the accepted design; do not duplicate them here.
- Identify each inventory revision. The current branch or this index alone does not establish the approval state of a linked design or contract.
