---
metadata-version: 1.0.0
title: Component detailed design and contracts template
description: Define the fields and approval route for component detailed design and contracts.
document-type: template
repository: vc.Governance
language: Standard Technical English
updated: 2026-11-11
version: # VERSION
1.0.0
last_updated: 2026-11-14
---

# Component detailed design and contracts template

**Artifact type:** `detailed-design`. **Decision route:** GOV-A07.

Follow the [common artifact contract](../../artifacts/README.md) and [schema](../../artifacts/schemas/artifact.schema.json). Use the [fictional draft JSON](../../artifacts/examples/detailed-design.json) as a structure example. It does not authorize work. Replace all example values and references before issuing an operational record.

## Required payload fields

| Field | Type or allowed values | Required content |
| --- | --- | --- | --- |
| `component_id` | string | Identify the component governed by the artifact. Use null only when the contract permits a non-component scope. |
| `system_design` | object | Identify the exact approved system-design revision. Include repository, identity, revision, path, and byte hash. |
| `requirements` | array | List the exact requirement revisions that govern the work. Each entry is an exact revision-bound reference. |
| `contracts` | array | Define approved service facets, operations, inputs, outputs, and failures. |
| `internal_design` | string | Describe implementation structure inside the approved component boundary. |
| `dependency_constraints` | array | State permitted dependencies and prohibited boundary bypasses. |
| `testability` | string | Explain how the design permits the required verification. |
| `open_questions` | array | List unresolved design questions and the work they affect. |

## DTO changes in a developer handoff

For an approved extension to a service-boundary DTO, describe it in the affected operation's `inputs` or `outputs` entries under `contracts`. Identify the DTO, field and type, meaning, required or optional status, behavior when absent, and applicable validation, serialization and compatibility expectations. State the interface and operation signatures to preserve. Describe internal DTO changes in `internal_design`. Record how to verify the behavior in `testability`.

The [Work Assignment](work-assignment.md) identifies which reviewed changes are in scope and which paths the developer may edit. The [Developer agent prompt](../developer-agent-prompt.md) consumes both records.

## Review and approval

Accountable owner: `application-architect`. Approval route: `solution-architect`.

Required review roles: `solution-architect`, `test-architect`.

Application Architect owns detail; Solution Architect reviews before handoff.

Use the [decision matrix](../../governance/decision-and-approval-matrix.md) to resolve authority and independent review. An empty list in an example does not waive required operational evidence.
