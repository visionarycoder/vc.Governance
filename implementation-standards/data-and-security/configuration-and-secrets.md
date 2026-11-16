---
title: Configuration and Secrets
address: standard/implementation/configuration-secrets
type: implementation-standard
owner: agent/sa
status: active
tags: [configuration-and-secrets, implementation, standards]
aliases: [configuration-and-secrets]
version: 1.0.0
last_updated: 2026-11-14
---

# Configuration and Secrets

## Rules

- Separate configuration from code.
- Bind configuration to validated option types at startup.
- Fail startup when required configuration is missing or invalid.
- Use environment-appropriate secret stores.
- Never commit secrets, tokens, private keys, or production connection strings.
- Do not log secrets or complete sensitive configuration objects.
- Define ownership and rotation expectations for every secret.
- Keep environment-specific values out of shared source artifacts.
