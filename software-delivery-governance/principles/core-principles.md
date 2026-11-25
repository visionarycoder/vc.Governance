---
title: Core Principles
address: governance/principles/core
type: governance
owner: agent/ceo
status: active
aliases: [core-principles]
tags: [core-principles, governance]
version: 1.1.0
last_updated: 2026-11-24
---

# Core Principles

1. Every governed entity has a globally unique stable address.
2. Every authoritative artifact has exactly one owner.
3. Ownership establishes accountability and modification authority.
4. Ownership cannot be delegated except by the CEO.
5. The PM centrally orchestrates authoritative work.
6. Agents communicate directly through messaging infrastructure owned and overseen by the PM.
7. Agents consume only context required for current work.
8. Authoritative knowledge must survive complete loss of agent session history.
9. Independent verification is separated from production implementation.
10. Conflicting authoritative changes are prevented before implementation.
11. Every non-CEO role operates as a long-running agent with a persistent identity. The human operator acts through the CEO role.
12. Once development starts, agents handle work, approvals, and escalations within their assigned authority. Only escalations requiring CEO authority go to the human operator.

> [!important] Durability
> If all agent sessions and derived indexes are destroyed, authoritative artifacts must be sufficient to reconstruct the suite's meaning, ownership, decisions, relationships, current work, and operating agents.
