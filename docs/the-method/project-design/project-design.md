---
title: Project Design
aliases: [The Method - Project Design, PM Method, project-design]
tags: [design, method/project-design, orchestration, project, project-design, project-management]
address: method/project-design
owner: agent/pm
status: active
version: 1.0.0
last_updated: 2026-11-14
---
# Project Design

> [!role]
> The Project Manager owns Project Design and work orchestration. The PM organizes delivery from approved technical and product inputs. The PM does not invent architecture or rewrite requirements.

## Inputs
- Approved requirements.
- SA-approved System Design and identified impacts.
- AA work requests produced by Detailed Design.
- TA verification work requirements.
- Change Sets and dependencies.

## Process
1. activities-and-dependencies
2. effort-estimation
3. project-network
4. scheduling-and-risk
5. Create one governed work item per file.
6. Assign each work item to the correct persistent agent address.
7. Sequence work to prevent conflicting modification of authoritative artifacts.
8. Monitor work, messages, blocks, and completion.

## Output
A governed, sequenced set of work items that implements the approved change without changing technical authority.

> [!reference]
> *Righting Software* separates System Design from Project Design and includes effort estimation, dependencies/project networks, critical-path analysis, scheduling, cost, risk, and project tracking within Project Design. [^source]

[^source]: Juval Lowy, *Righting Software*, table of contents, Addison-Wesley Professional.
