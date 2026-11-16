---
title: Package and Dependency Management
address: standard/implementation/packages
type: implementation-standard
owner: agent/sa
status: active
tags: [implementation, package-and-dependency-management, standards]
aliases: [package-and-dependency-management]
version: 1.0.0
last_updated: 2026-11-14
---

# Package and Dependency Management

## Rules

- Use approved package sources.
- Centralize shared package versions where the repository structure supports it.
- Commit lock or resolved dependency information when reproducibility requires it.
- Minimize direct dependencies.
- Do not add a package for functionality already available through an approved dependency without justification.
- Review license, support, security, transitive dependencies, and maintenance status before adoption.
- Remove unused dependencies.
- Update dependencies through governed work with verification evidence.
- Keep runtime and target-framework compatibility explicit.
