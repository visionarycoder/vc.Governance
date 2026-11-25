---
title: Architecture and VBD Boundaries
address: standard/implementation/architecture-vbd
type: implementation-standard
owner: agent/sa
status: active
tags: [architecture-and-vbd-boundaries, implementation, standards]
aliases: [architecture-and-vbd-boundaries]
version: 1.0.0
last_updated: 2026-11-14
---

# Architecture and VBD Boundaries

## Required structure

- Managers orchestrate workflows and communicate with other Managers through the approved message bus.
- Engines implement focused business or computational behavior and are name-coupled to their handler types.
- Engines must not call other Engines.
- Access components implement query and persistence patterns.
- Contracts define approved component boundaries.
- Ifx contains approved shared implementation only after architectural review.
- Generic types remain opaque unless they cross a governed boundary.
- Dependency injection and lifecycle rules must preserve component boundaries.

## Change rule

A Developer must not bypass a boundary to reuse convenient code. Escalate reuse or extraction needs to the owning Application Architect. Cross-component sharing requires an approved design and PM-orchestrated work.

## Stop conditions

Stop and message the owning Application Architect when:
- the work requires an unapproved dependency;
- a component must call through another component's internals;
- existing code cannot be reused without violating ownership;
- the implementation conflicts with the System Design or Detailed Design.
- the implementation conflicts with the code quality or coding standards.
