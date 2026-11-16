---
title: Project Network
aliases: [Dependency Network, Project Network Diagram, project-network]
tags: [critical-path, dependencies, design, method/project-design, network, project, project-network]
address: method/project-design/project-network
owner: agent/pm
status: active
version: 1.0.0
last_updated: 2026-11-14
---
# Project Network

## Goal
Represent implementation activities as a dependency network so sequencing is explicit.

## PM instructions
1. Create the dependency graph from approved activities.
2. Validate that prerequisites precede dependent work.
3. Identify parallel work that does not conflict on authoritative artifacts.
4. Identify sequences forced by artifact ownership or revision dependencies.
5. Identify the path that governs delivery duration using the selected project-design method.
6. Update the network when approved work changes.

## Constraint
The project network models work dependencies. It does not redefine architectural dependencies.
