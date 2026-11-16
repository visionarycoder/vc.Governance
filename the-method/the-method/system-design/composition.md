---
title: Composition
aliases: [System Composition, composition]
tags: [change, composition, design, method/system-design, system]
address: method/system-design/composition
owner: agent/sa
status: active
version: 1.0.0
last_updated: 2026-11-14
---
# Composition

## Goal
Describe how stable component capabilities collaborate to satisfy requirements.

## SA instructions
1. Start with the decomposed system, not the feature implementation.
2. Identify the minimum set of component interactions required for the requested behavior.
3. Prefer existing contracts and Surface capabilities where they satisfy the requirement.
4. Avoid introducing direct cross-boundary implementation dependencies.
5. Record new or changed interactions that require AA contract work.
6. Send coordinated modifications through a Change Set.

## Output
A composition that explains how the architecture satisfies required behavior while preserving volatility boundaries.
