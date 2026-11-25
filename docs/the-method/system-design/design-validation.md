---
title: Design Validation
aliases: [Validate System Design, design-validation]
tags: [architecture, design, design-validation, method/system-design, system, validation]
address: method/system-design/design-validation
owner: agent/sa
status: active
version: 1.0.0
last_updated: 2026-11-14
---
# Design Validation

## Goal
Challenge the proposed design before implementation work is created.

## Validate
- Every component boundary has a stated volatility rationale.
- The design satisfies the approved requirements without rewriting them.
- Changed responsibilities have deterministic owners.
- Cross-component interactions are explicit.
- Contract impacts are identified.
- Test Architect impact is identified.
- Existing Surface entries were considered before adding capability.
- The design minimizes ripple effects from anticipated change.
- Required Change Sets and decision records exist.

## Completion
When the SA approves the requested changes to the shape of the System Design, the PM may use the approved design as input to Project Design.
