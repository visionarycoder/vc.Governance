---
metadata-version: 1.0.0
title: Project alternatives and selected SDP template
description: Define the fields and approval route for project alternatives and selected sdp.
document-type: template
repository: vc.Governance
language: Standard Technical English
updated: 2026-11-11
version: # VERSION
1.0.0
last_updated: 2026-11-14
---

# Project alternatives and selected SDP template

**Artifact type:** `software-development-plan`. **Decision route:** GOV-A10.

Follow the [common artifact contract](../../artifacts/README.md) and [schema](../../artifacts/schemas/artifact.schema.json). Use the [fictional draft JSON](../../artifacts/examples/software-development-plan.json) as a structure example. It does not authorize work. Replace all example values and references before issuing an operational record.

## Required payload fields

| Field | Type or allowed values | Required content |
| --- | --- | --- | --- |
| `system_design` | object | Identify the exact approved system-design revision. Include repository, identity, revision, path, and byte hash. |
| `options` | array | Describe candidate project options, assumptions, networks, cost, and risk. |
| `selected_option_id` | string or null | Identify the management-selected option. Use null before selection. |
| `do_not_proceed_option` | string | Describe the option to cancel or decline the project. |
| `calendar_and_availability` | string | State the work calendar and actual resource availability assumptions. |
| `resource_basis` | string | State the resource estimates and costing assumptions. |
| `rate_baseline` | object | Reference the exact approved resource-rate version. Include repository, identity, revision, path, and byte hash. |
| `quality_activities` | array | List planned review, test, integration, regression, and prevention activities. |
| `phase_weight_basis` | string | State the method used to assign consistent phase weights. |
| `within_owner_bounds` | boolean | State whether the proposed option and commitments fit the exact human-owner-approved project envelope. |
| `management_decision` | array | Reference management acceptance of the selected option and commitments, including its authority basis. Each entry is an exact revision-bound reference. |

## Review and approval

Accountable owner: `solution-architect`. Approval route: CEO / Visionary within
the approved project envelope; Human owner for an out-of-envelope commitment.

Required review roles: `project-manager`, `product-owner`, `test-architect`, `qa`.

The Solution Architect designs the project. The human owner approves the
project-specific envelope before the CEO accepts the SDP. The CEO accepts only
within that envelope. The human owner decides out-of-envelope proposals in
human-owner capacity.

Before CEO acceptance, the human owner approves explicit project-specific limits
for applicable scope, cost, schedule, and resource commitments. Record the
envelope in a revision-bound `decision-record` on the exact SDP revision. Its
`accept-artifact` decision must identify the human owner as decider, and its
reason must limit approval to the envelope; it does not select the option or
accept commitments. The CEO's separate `select-project-option` decision
references the envelope decision as authority evidence and identifies the
capacity used. A boolean `within_owner_bounds` without this evidence is
insufficient. Missing, ambiguous, or exceeded limits block CEO acceptance and
require a human-owner-capacity decision. The owner may reject the proposal or
approve revised limits and commitments in a new revision-bound decision. No
global numeric caps apply.

Use the [decision matrix](../../governance/decision-and-approval-matrix.md) to resolve authority and independent review. An empty list in an example does not waive required operational evidence.
