---
title: Scheduling and Risk
aliases: [Project Scheduling, Project Risk, scheduling-and-risk]
tags: [design, method/project-design, orchestration, project, risk, scheduling, scheduling-and-risk]
address: method/project-design/scheduling-risk
owner: agent/pm
status: active
version: 1.0.0
last_updated: 2026-11-14
---
# Scheduling and Risk

## Goal
Sequence and monitor approved work while protecting architecture, ownership, and acceptance rules.

## PM instructions
- Use the project network to sequence work.
- Maximize safe parallelism across independent artifacts.
- Never schedule conflicting authoritative modifications concurrently.
- Track blocked work and route the blocking decision to the correct owner.
- Treat architectural, requirement, verification, and ownership disputes as escalation problems, not scheduling decisions.
- Re-evaluate downstream work after an upstream authoritative artifact changes revision.
- Create work items only after sufficient authority and context exist.

## Work-item rule
Each work item is one file and acts as the worker agent's primary context root.
