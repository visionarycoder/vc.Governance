---
title: Risk Register
address: method/project-design/risk-register
owner: agent/pm
version: 1.0.0
last_updated: 2026-11-25
---

# Risk Register

## Goal
Capture, assess, and mitigate risks that could affect gate boundaries, cost, schedule, or quality.

## Artifact
`risk-register.csv` – columns:
```
riskId,description,gate,probability,impact,mitigation,owner,status
```
- `probability` and `impact` are values `low`, `medium`, `high`.
- `status` values: `open`, `mitigated`, `closed`.

## Process
1. When a volatility analysis reveals a volatile change driver, add a risk entry.
2. Prior to scheduling, ensure every `open` risk has a mitigation plan.
3. Update the `status` field as mitigation actions are completed.
4. The PM checklist must verify that no `open` risks remain for a gate before it is marked `pass`.

## Example
```
R001,Dependency on external API version, D02, high, high, "Add version‑pinning wrapper", team‑add‑ons, open
```

## References
- Linked from `scheduling-and-risk.md`.
