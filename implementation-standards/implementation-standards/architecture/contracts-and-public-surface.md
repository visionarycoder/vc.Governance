---
title: Contracts and Public Surface
address: standard/implementation/contracts
type: implementation-standard
owner: agent/sa
status: active
tags: [contracts-and-public-surface, implementation, standards]
aliases: [contracts-and-public-surface]
version: 1.0.0
last_updated: 2026-11-14
---

# Contracts and Public Surface

## Rules

- The owning Application Architect controls each component contract.
- Public members must exist for a defined consumer need.
- Prefer compatible extension over breaking replacement.
- Breaking changes require impact analysis, Test Architect review, and Solution Architect approval.
- Keep contracts independent from internal implementation details.
- Do not leak persistence models, framework-specific runtime objects, or internal exceptions across boundaries.
- Document behavior, invariants, failure modes, version expectations, and compatibility constraints.
- Update the Surface Area when a public capability changes.

## Review questions

- Is the contract the smallest stable surface that satisfies the requirement?
- Does it preserve ownership boundaries?
- Can internal implementation change without breaking consumers?
- Are nullability, cancellation, error, and version semantics explicit?
