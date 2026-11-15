---
metadata-version: 1.0.0
title: Local Builder component-surface template
description: Inventory one component, its contracts, and every method in its defined scope.
document-type: template
repository: vc.Governance
language: Standard Technical English
updated: 2026-11-11
version: # VERSION
1.0.0
last_updated: 2026-11-14
---

# Local Builder component-surface template

Create one file per component under `.builder/application-surface/components/`. The responsible Application Architect owns the entry within the accepted system design. Keep descriptions brief and link to the exact design and source rather than copying their contents.

## Component identity

| Field | Value |
| --- | --- |
| Component ID | `<stable component ID>` |
| Name | `<component name>` |
| Responsibility | `<short description>` |
| Application Architect | `<identity>` |
| Detailed design | `<exact path and revision>` |
| Source location | `<repository-relative path>` |
| Inventory revision | `<immutable project revision>` |

## Contracts

List every public and internal contract within this component's agreed scope. Include DTOs and their role in the contract.

| Contract ID and name | Visibility | Direction/provider-consumer | DTOs | Short description | Design and source reference |
| --- | --- | --- | --- | --- | --- |
| `<contract-id/name>` | `<public/internal>` | `<provider -> consumer>` | `<DTO names or none>` | `<purpose>` | `<exact paths and revisions>` |

## Methods

List every declared method in the component's agreed scope, including public, internal, and private methods. Keep each description short. Include overloads as separate entries so agents can distinguish them.

| Method ID and signature | Visibility | Contract or implementation | Short description | Key inputs and result | Source path and design reference |
| --- | --- | --- | --- | --- | --- |
| `<stable method ID and full signature>` | `<public/internal/private>` | `<contract ID or implementation>` | `<responsibility and observable effect>` | `<important inputs/result>` | `<exact source path and design revision>` |

## Relationships and change record

- **Permitted component dependencies:** `<component IDs and approved proxy paths>`
- **Callers or consumers:** `<component/method IDs>`
- **Relevant invariants:** `<concise behavior or compatibility constraints>`
- **Last surface change:** `<date, linked work item, and summary>`
- **Pending discrepancy:** `<none or exact issue/message ID and owner>`

Update the inventory when an accepted design or implementation changes a method, contract, DTO, or component boundary. A developer may propose an inventory change in the assigned work item; the responsible architect resolves and records it. If this file conflicts with accepted design or source, stop the affected change and route the discrepancy to the responsible owner.
