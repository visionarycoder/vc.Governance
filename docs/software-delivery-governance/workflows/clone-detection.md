---
title: Clone Detection
address: governance/workflows/clone-detection
type: governance
owner: agent/ceo
status: active
aliases: [clone-detection]
tags: [clone-detection, governance, ifx]
version: 1.0.0
last_updated: 2026-11-27
---

# Clone Detection

Clone detection reuses the same guidance as surface-area review: review what exists before creating anything.

- The DA reads the Surface Area before it builds an implementation plan.
- The implementation plan is reviewed and approved before the DA starts writing code.
- Clone detection compares the written code against existing suite code, like Visual Studio Code Clone Detection, to find duplicates.
- A detected duplicate or possible match triggers the [IFX reuse-escalation workflow](ifx-reuse-escalation.md).
- Resumed work leverages the shared code that the Surface Area now references instead of reimplementing it.

Clone detection and surface-area review are overlapping ideas under one rule: do not create what already exists.
