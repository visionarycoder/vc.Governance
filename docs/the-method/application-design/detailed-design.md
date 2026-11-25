---
title: Detailed Design
aliases: [Application Design, AA Method, detailed-design]
tags: [application, application-architect, design, detailed-design, method/application-design]
address: method/application-design/detailed-design
owner: agent/aa
status: active
version: 1.1.0
last_updated: 2026-11-24
---
# Detailed Design

> [!role]
> The assigned Application Architect is the sole author and owner of the component's Detailed Design. The AA creates and revises it within the SA-approved System Design.

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
6. Obtain required input from impacted Application Architects and the Test Architect. The assigned AA makes all changes to the Detailed Design.
7. Submit a specific Detailed Design revision, its approved System Design baseline, impact analysis, and required review evidence to the SA.

## SA conformance gate

After submission, the Solution Architect checks the revision against the approved System Design. The SA records approval or rejection, with findings and the applicable constraints. The SA does not draft, coauthor, or edit the Detailed Design.

If the SA rejects the submission, the AA refines the design and resubmits a new revision. Record how the new revision addresses prior findings. Repeat the review until a revision passes. The design remains pending throughout the cycle, and approval applies to the revision reviewed.

If a finding requires changing the approved System Design, route it through System Design governance. The AA then revises against the approved baseline. Follow the [existing escalation paths](../../software-delivery-governance/authority/authority-and-escalation.md) for disputes.

## Completion
The AA's design activity produces the submitted revision. Acceptance follows SA approval at the separate conformance gate. The AA then sends approved implementation needs to the PM for work orchestration.
