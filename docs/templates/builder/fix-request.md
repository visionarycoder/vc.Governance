---
metadata-version: 1.0.0
title: Local Builder fix request template
description: Bound a repair or refactor of existing code to a known revision and verification criteria.
document-type: template
repository: vc.Governance
language: Standard Technical English
updated: 2026-11-11
version: # VERSION
1.0.0
last_updated: 2026-11-14
---

# Local Builder fix request template

Create one file per repair or refactor under `.builder/fixes/`, using a unique ID such as `FIX-<project-key>-<sequence>`. A fix request describes the change; the Project Manager creates or links its work item and issues any required assignment.

## Fix request

| Field | Value |
| --- | --- |
| Fix ID | `<unique ID>` |
| Title | `<specific repair or refactor>` |
| State | `<proposed/ready/assigned/in progress/blocked/submitted/in review/accepted/closed>` |
| Requested by | `<role and agent address>` |
| Work item | `<WI-id or pending>` |
| Target component | `<component ID>` |
| Target code revision | `<immutable commit or artifact revision>` |
| Related finding/message | `<exact IDs and paths, or none>` |

## Requested change

- **Observed defect or refactoring need:** `<evidence and impact>`
- **Current behavior:** `<behavior at the target revision>`
- **Required behavior or structure:** `<bounded outcome>`
- **Reason for change:** `<why this work is needed now>`
- **Permitted paths:** `<exact paths>`
- **Excluded paths:** `<paths or areas not in scope>`

## Preserve and verify

- **Behavior that must remain unchanged:** `<observable behavior>`
- **Contracts and callers to preserve:** `<contract/method IDs and dependent callers>`
- **Required tests:** `<focused tests and regression scope>`
- **Completion evidence:** `<test results, review, and relevant before/after details>`
- **Application-surface update:** `<component entry and methods to update, or no change with rationale>`

## Design and assignment checks

Before implementation, the Project Manager links the current formal assignment when required and verifies that the accepted requirements and detailed design cover the requested change. The worker consults the responsible Application Architect before proceeding under any design refinement. A change to business behavior goes to the Product Owner; a change beyond component bounds goes to the Solution Architect; a test-design change goes to the Test Architect.

Do not broaden a fix into unrelated cleanup or behavior change. If the evidence requires broader scope, stop the affected work and ask the Project Manager to route the change to its owner. A fix request, its ticket, and a passing test do not by themselves authorize a design or requirement change.
