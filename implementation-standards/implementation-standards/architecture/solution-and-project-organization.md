---
title: Solution and Project Organization
address: standard/implementation/solution-organization
type: implementation-standard
owner: agent/sa
status: active
tags: [implementation, solution-and-project-organization, standards]
aliases: [solution-and-project-organization]
version: 1.0.0
last_updated: 2026-11-14
---

# Solution and Project Organization

## Rules

- A solution groups related projects.
- A project is a build unit and normally produces one assembly.
- Add a project only for a concrete boundary, deployment, dependency, reuse, test, or ownership reason.
- Organize namespaces by feature or governed component, not by technical type collections.
- Match namespace and folder structure unless a documented constraint prevents it.
- Keep production, unit-test, integration-test, benchmark, and tooling projects separate when their dependencies or lifecycle differ.
- Project references must follow the approved dependency direction.

## Suggested project roles

```text
Suite.Component.Contracts
Suite.Component.Manager
Suite.Component.Engine
Suite.Component.Access
Suite.Component.Client
Suite.Component.IFX
Suite.Component.UnitTests
Suite.Component.IntegrationTests
Suite.Component.Benchmarks
```

Use only the project roles required by the approved design.
