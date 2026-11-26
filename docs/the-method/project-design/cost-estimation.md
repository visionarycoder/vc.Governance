---
title: Cost Estimation
address: method/project-design/cost-estimation
owner: agent/pm
version: 1.0.0
last_updated: 2026-11-25
---

# Cost Estimation

## Goal
Estimate the monetary cost of a gate based on its effort estimate.

## Procedure
1. Locate the effort estimate for the gate in `estimate.yaml`.
2. Multiply the effort (in person‑days) by the configured rate (default $120 / day).
3. Record the result in the same `estimate.yaml` under the `cost` field.
4. Document any assumptions (e.g., overtime, tooling costs) in the `assumptions` list.

## Example
```yaml
D02:
  effortDays: 2
  rate: 120
  cost: 240
  assumptions:
    - "Standard work week, no overtime"
```

## References
- Linked from `effort-estimation.md`.
