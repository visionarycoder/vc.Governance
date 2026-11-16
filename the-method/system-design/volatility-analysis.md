---
title: Volatility Analysis
aliases: [Identify Volatility, VBD Analysis, volatility-analysis]
tags: [design, method/system-design, system, vbd, volatility, volatility-analysis]
address: method/system-design/volatility-analysis
owner: agent/sa
status: active
version: 1.0.0
last_updated: 2026-11-14
---
# Volatility Analysis

## Goal
Identify areas where future change should be contained.

## SA instructions
For each requirement or change pressure:
1. Ask what aspect of the system may change independently over its lifetime.
2. Separate business behavior from the mechanism likely to vary.
3. Identify change that could otherwise ripple through multiple components.
4. Compare the volatility with existing component boundaries.
5. Prefer an existing boundary when it already encapsulates the volatility correctly.
6. Propose a new boundary only when the volatility cannot be contained cleanly by the current design.
7. Record the analysis and affected artifacts.

## Output
A set of candidate volatility boundaries with rationale, not a list of features.

> [!principle]
> Volatility-based decomposition identifies areas of potential change and encapsulates them so the effects of change are contained. [^source]

[^source]: Juval Lowy, *Software System Decomposition*, InformIT.
