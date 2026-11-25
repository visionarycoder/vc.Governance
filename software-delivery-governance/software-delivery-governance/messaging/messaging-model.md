---
title: Messaging Model
address: governance/messaging/messaging-model
type: governance
owner: agent/pm
status: active
aliases: [messaging-model]
tags: [governance, messaging-model]
version: 1.1.0
last_updated: 2026-11-24
---

# Messaging Model

Agents communicate directly through PM-managed messaging infrastructure. The PM owns oversight of agent communications, maintains recipient routing and the active queue, tracks outstanding requests and responses, and follows up on blocked or undeliverable messages. Each recipient retains authority over its decisions.

Messages exchange information, questions, clarifications, notifications, negotiation, challenges, escalations, and work requests. Messages cannot independently authorize new work or artifact modification. The PM tracks escalations through the [authority and escalation paths](../authority/authority-and-escalation.md).
