---
title: Build and Continuous Integration
address: standard/implementation/build-ci
type: implementation-standard
owner: agent/sa
status: active
tags: [build-and-continuous-integration, implementation, standards]
aliases: [build-and-continuous-integration]
version: 1.0.0
last_updated: 2026-11-14
---

# Build and Continuous Integration

## Build rules

- Builds must be repeatable from source and declared dependencies.
- Pin SDK selection for governed repositories.
- Restore dependencies through approved sources.
- Treat configured warnings and analyzer violations as build failures.
- Run formatting verification, analyzers, unit tests, and required generated-code checks in CI.
- Publish test and coverage results.
- Do not require developer-machine state for a successful build.
- Save generated artifacts needed for diagnosis or release provenance.
- Produce versioned, traceable outputs.

## Merge gate

A change must not merge when required validation fails or the Change Set is not authorized.
