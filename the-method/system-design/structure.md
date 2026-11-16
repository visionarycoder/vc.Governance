---
title: Structure
aliases: [System Structure, structure]
tags: [contracts, design, method/system-design, structure, system]
address: method/system-design/structure
owner: agent/sa
status: active
version: 1.0.0
last_updated: 2026-11-14
---
# Structure

## Goal
Define how decomposed components are organized and exposed without weakening ownership boundaries.

## SA instructions
- Assign each component a single architectural responsibility derived from volatility.
- Define the allowed direction of dependencies.
- Define which interactions require contracts.
- Identify system-level versus component-level contract responsibilities.
- Preserve explicit architectural layers where they constrain allowed collaboration.
- Require globally addressed artifacts for components, contracts, and Surface entries.
- Pass component-level Detailed Design responsibility to the owning AA.

## Output
An updated System Design describing components, boundaries, permitted relationships, and system-level constraints.
