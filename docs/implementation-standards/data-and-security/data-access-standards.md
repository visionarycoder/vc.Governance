---
title: Data Access Standards
address: standard/implementation/data-access
type: implementation-standard
owner: agent/sa
status: active
tags: [data-access-standards, implementation, standards]
aliases: [data-access-standards]
version: 1.0.0
last_updated: 2026-11-14
---

# Data Access Standards

## Rules

- Access components own persistence and external data-query behavior.
- Keep persistence models inside the owning boundary.
- Parameterize database commands.
- Use transactions only across the smallest required consistency boundary.
- Avoid hidden query execution and unbounded result materialization.
- Use asynchronous data APIs when available and appropriate.
- Define timeout, retry, and cancellation behavior.
- Do not expose provider-specific types through component contracts unless explicitly approved.
- Make schema and compatibility changes through governed Change Sets.
- Test queries against realistic data volume when performance matters.
