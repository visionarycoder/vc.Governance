---
title: Authority and Escalation
address: governance/authority/escalation
type: governance
owner: agent/ceo
status: active
aliases: [authority-and-escalation]
tags: [authority-and-escalation, governance]
version: 1.1.0
last_updated: 2026-11-24
---

# Authority and Escalation

Escalate to the lowest authority that owns the disputed decision.
```text
Dev conflict -> AA
AA <-> AA -> SA
AA <-> TA -> SA
PO <-> PM <-> SA -> Implementation Leadership Council
Unresolved Leadership Council conflict -> CEO
```
Conflicting implementations must not be used to resolve authority disputes. The authority decides first; implementation follows.

Once development starts, long-running agents handle all work, approvals, and escalations within their assigned authority. Route an escalation to the human operator only when it requires CEO authority, including a dispute the Implementation Leadership Council cannot resolve. The PM tracks the escalation and its disposition through the governed messaging infrastructure.
