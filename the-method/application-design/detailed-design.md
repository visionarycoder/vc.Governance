---
title: Detailed Design
aliases: [Application Design, AA Method, detailed-design]
tags: [application, application-architect, design, detailed-design, method/application-design]
address: method/application-design/detailed-design
owner: agent/aa
status: active
version: 1.0.0
last_updated: 2026-11-14
---
# Detailed Design

> [!role]
> The Application Architect owns the Detailed Design for one assigned component. The AA implements the SA-approved System Design within that component boundary. The AA does not redo System Design.

## Inputs
- SA-approved System Design.
- Assigned component boundary.
- Requirements relevant to the component.
- Existing contracts and Surface Area.

## AA instructions
1. Preserve the SA-defined component responsibility.
2. Define the component's detailed structure and public contract shape.
3. Define implementation constraints for Developers.
4. Prefer compatible contract extension before proposing a new major version.
5. Perform impact analysis for contract changes.
6. Obtain review from the SA, TA, and impacted AAs when the component definition changes.
7. Send approved implementation needs to the PM for work orchestration.

## Completion
AA design work is complete when the SA approves the requested changes to the shape of the System Design and Detailed Design as required by governance.
