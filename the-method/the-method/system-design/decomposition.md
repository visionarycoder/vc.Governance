---
title: Decomposition
aliases: [System Decomposition, VBD Decomposition, decomposition]
tags: [decomposition, design, method/system-design, system, vbd]
address: method/system-design/decomposition
owner: agent/sa
status: active
version: 1.0.0
last_updated: 2026-11-14
---
# Decomposition

## Goal
Turn validated volatility into stable component boundaries.

## SA instructions
1. Start from volatility-analysis, not from functional requirements grouped by feature.
2. Encapsulate each significant independent volatility behind a stable responsibility boundary.
3. Minimize reasons for a component to change.
4. Keep implementation knowledge behind the owning component boundary.
5. Identify required interactions without exposing internal implementation.
6. Use the existing composition whenever it already contains the new volatility.
7. Treat shared implementation extraction as an architectural decision, not a developer reuse decision.
8. Produce explicit component ownership and affected Application Architect addresses.

## Validation questions
- What volatility does this component encapsulate?
- What change can occur inside it without forcing unrelated components to change?
- Is this boundary based on volatility or merely on a feature/function name?
- Does the boundary create unnecessary coupling?
