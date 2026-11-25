---
title: Unit Testing Standards
address: standard/implementation/unit-testing
type: implementation-standard
owner: agent/sa
status: active
tags: [implementation, standards, unit-testing-standards]
aliases: [unit-testing-standards]
version: 1.0.0
last_updated: 2026-11-14
---

# Unit Testing Standards

## Ownership

The Developer creates and owns the unit tests for assigned production behavior. The Solution Architect defines coverage requirements.

## Rules

- Test externally observable behavior of the unit, including failure paths and boundary conditions.
- Keep tests deterministic, isolated, and repeatable.
- Do not depend on network, clock, filesystem, environment, or database state unless replaced by a controlled test boundary.
- Use descriptive test names that state condition and expected result.
- Prefer one behavioral reason for failure per test.
- Do not weaken tests merely to make a changed implementation pass.
- Generate coverage reports, but do not treat numeric coverage as proof of correctness.
- All affected unit tests must pass before Developer work is ready for acceptance.
