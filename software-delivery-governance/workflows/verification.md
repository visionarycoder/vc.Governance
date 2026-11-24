---
title: Verification
address: governance/workflows/verification
type: governance
owner: agent/ceo
status: active
aliases: [verification]
tags: [governance, verification]
version: 1.1.0
last_updated: 2026-11-24
---

# Verification

`Approved requirements and design -> TA verification design -> SA conformance gate -> Test Dev implementation -> TA evidence acceptance`.

## Verification design and conformance review

The Test Architect is the sole author and owner of verification design. The TA derives black-box, integration, and regression criteria from approved requirements, contracts, and design while remaining independent of Application Architect work.

The TA submits a specific revision with its approved System Design baseline and relevant requirements and contracts. At the separate conformance gate, the Solution Architect records approval or rejection with findings. The SA does not draft, coauthor, or edit the verification design.

If rejected, the TA addresses the findings, records their resolution, and resubmits a new revision. The cycle repeats until a revision passes. The design remains pending throughout, and approval applies to the reviewed revision. Route required System Design changes through System Design governance and disputes through the [existing escalation paths](../authority/authority-and-escalation.md).

## Implementation and evidence acceptance

The Test Developer implements the approved verification design. The TA independently accepts the resulting test evidence. A production change does not automatically justify changing a regression test. Route failures by cause to the responsible implementation, component design, System Design, requirement, verification design, or test implementation owner.
