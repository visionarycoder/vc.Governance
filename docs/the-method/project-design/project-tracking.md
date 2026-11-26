---
title: Project Tracking
address: method/project-design/project-tracking
owner: agent/pm
version: 1.0.0
last_updated: 2026-11-25
---

# Project Tracking

## Goal
Maintain a single source of truth for the status of every gate so agents and humans can see progress, blockers, and completion.

## Artifact
`tracking.csv` – columns:
```
gate,status,percentComplete,blockers
```
- `status` values: `todo`, `in‑progress`, `blocked`, `pass`, `fail`.
- `percentComplete` is an integer 0‑100.
- `blockers` is a semicolon‑separated list of gate names or issue IDs.

## Process
1. After each CI run, update the row for the gate that was just validated.
2. When a gate becomes `blocked`, list the blocking gate(s) in the `blockers` column.
3. When a gate reaches `pass`, set `percentComplete` to `100` and clear `blockers`.
4. The PM checklist must verify that the CSV is updated before marking the overall project as complete.

## Example
```
D02,pass,100,
D06,blocked,45,D02
D08,in-progress,30,
```

## References
- Linked from `scheduling-and-risk.md`.
