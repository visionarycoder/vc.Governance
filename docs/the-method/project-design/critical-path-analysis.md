---
title: Critical Path Analysis
address: method/project-design/critical-path-analysis
owner: agent/pm
version: 1.0.0
last_updated: 2026-11-25
---

# Critical Path Analysis

## Goal
Identify the longest‑duration sequence of dependent gates (the critical path) so scheduling can maximise parallelism while respecting authoritative boundaries.

## Procedure
1. Generate the project network graph `project-network.dot` (see `project-network.md`).
2. Run a DAG longest‑path algorithm (any tool that can read DOT) to produce a list of gates on the critical path.
3. Write the list to `critical-path.txt` – one gate name per line.
4. In `project-network.dot` mark each edge that belongs to the critical path with the attribute `critical=true`.
5. The validator will surface any missing `critical=true` flags as a warning.

## Example (partial DOT snippet)
```
"D02" -> "D06" [critical=true];
"D06" -> "D08" [critical=true];
```

## References
- Linked from `project-network.md`.
