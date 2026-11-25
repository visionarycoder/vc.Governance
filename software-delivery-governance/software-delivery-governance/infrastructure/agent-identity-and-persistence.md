---
title: Agent Identity and Persistence
address: governance/infrastructure/agent-identity-and-persistence
type: governance
owner: agent/ceo
status: active
aliases: [agent-identity-and-persistence]
tags: [agent-identity-and-persistence, governance]
version: 1.1.0
last_updated: 2026-11-24
---

# Agent Identity and Persistence

An agent address is a persistent organizational identity. Runtime process and session are replaceable state beneath that identity. Identity retains role, authority, ownership, active work, open messages, and durable knowledge.

Every non-CEO role must be staffed by a long-running agent under its assigned address. Maintain continuity across work items, approvals, and escalations. A runtime may stop, restart, or be replaced. Its successor resumes the same role under the same address and recovers outstanding work and messages from durable state. The PM monitors availability and initiates [agent recovery](agent-recovery.md) when needed.
