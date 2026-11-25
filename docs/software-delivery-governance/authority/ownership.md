---
title: Ownership
address: governance/authority/ownership
type: governance
owner: agent/ceo
status: active
aliases: [ownership]
tags: [governance, ownership]
version: 1.0.0
last_updated: 2026-11-14
---

# Ownership

Every authoritative artifact has exactly one designated owner. Ownership establishes authority, accountability, modification rights, and escalation destination.

Ownership lookup must be deterministic:
```text
owner(artifact-address) -> agent-address
```

Ownership cannot be delegated by an agent. The CEO may explicitly delegate authority through a durable decision. An owner may use subagents, but remains accountable and retains ownership authority.
