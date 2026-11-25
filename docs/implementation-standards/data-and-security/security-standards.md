---
title: Security Standards
address: standard/implementation/security
type: implementation-standard
owner: agent/sa
status: active
tags: [implementation, security-standards, standards]
aliases: [security-standards]
version: 1.0.0
last_updated: 2026-11-14
---

# Security Standards

## Required practices

- Apply least privilege to identities, files, processes, services, databases, and network access.
- Validate untrusted input at trust boundaries.
- Encode output for its target context.
- Use approved cryptographic and authentication libraries.
- Do not create custom cryptography.
- Do not load or execute code from unknown origins without an approved isolation boundary.
- Do not use BinaryFormatter or equivalent unsafe binary serialization.
- Do not use .NET Remoting for new implementation.
- Keep secrets outside source control and deployable artifacts.
- Patch supported runtimes and dependencies through governed work.
- Threat-model externally reachable or high-value capabilities.
- Record security exceptions and compensating controls as decisions.
