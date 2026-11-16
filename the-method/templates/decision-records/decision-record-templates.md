---
address: templates/decision-records
type: index
title: Decision Record Templates
aliases: [decision-record-templates]
tags: [decision, decision-record-templates, record]
owner: agent/sa
status: active
version: 1.0.0
last_updated: 2026-11-14
---

# Decision Record Templates

These templates record durable decisions under the authority model defined by the software delivery governance specification.

> [!IMPORTANT]
> A template never grants authority. The designated owner and governance hierarchy determine who may make and approve a decision.

## Templates

- [[decision-record]]
- [[architecture-decision]]
- [[component-design-decision]]
- [[requirement-interpretation-decision]]
- [[cross-component-decision]]
- [[contract-change-decision]]
- [[verification-decision]]
- [[project-planning-decision]]
- [[conflict-resolution-decision]]
- [[ceo-override-decision]]

## Rules

- Significant decisions that affect another agent, authoritative artifact, implementation constraint, or future work must be durable.
- Use the most specific template that matches the decision.
- Record globally addressed inputs and affected artifacts.
- Record superseded decisions instead of rewriting history.
- Resolve ownership and authority before approval.
