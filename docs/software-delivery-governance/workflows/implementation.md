---
title: Implementation
address: governance/workflows/implementation
type: governance
owner: agent/ceo
status: active
aliases: [implementation]
tags: [governance, implementation]
version: 1.1.0
last_updated: 2026-11-27
---

# Implementation

`PM assigns work -> Dev loads one work item -> follows references -> reads the Surface Area before building the implementation plan -> the implementation plan is reviewed and approved -> Dev inspects the existing implementation -> makes the minimal correct change, reusing existing shared code when it matches -> creates unit tests -> meets SA coverage requirements -> all unit tests pass -> ready for acceptance`

Creating code that duplicates existing code is a design flaw, not a completion: see [Clone Detection](clone-detection.md) and [IFX reuse escalation](ifx-reuse-escalation.md).
