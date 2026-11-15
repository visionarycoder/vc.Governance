---
metadata-version: 1.0.0
title: ADR 0003: CEO and human-owner authority
description: Record the owner's clarification of role identity and project-specific commitment limits.
document-type: governance-policy
repository: vc.Governance
language: Standard Technical English
updated: 2026-11-11
version: # VERSION
1.0.0
last_updated: 2026-11-14
---

# ADR 0003: CEO and human-owner authority

## Status

Accepted as a record of the human owner's explicit decisions GOV-OD11 and
GOV-OD12, recorded on 2026-11-11. This ADR does not approve an application SDP
or any particular project commitment.

## Context

The governance documents assign decisions to both the CEO and the human owner.
They identify the CEO as the suite decision-maker and the human owner as the
authority over the framework and delegation. The owner clarified that these
roles are held by the same human actor, that escalations reach this person, and
that there is no CEO agent.

Existing governance also permits CEO acceptance of an SDP and changed
commitments only within human-owner bounds. The repository did not define how
those bounds are established or verified for a project. The [approval
matrix](../governance/decision-and-approval-matrix.md), [owner
decisions](../governance/owner-decisions-2026-11-11.md), [lifecycle
gates](../process/lifecycle-gates.md), and [approval-validity
policy](../governance/change-approval-validity.md) remain controlling.

## Decision

1. The CEO and human owner are the same human actor, exercising distinct
   decision capacities. The CEO role is not an agent. An escalation to either
   capacity reaches this human; the record must identify the capacity that
   authorizes the action.
2. The shared identity does not merge authority, create a second independent
   reviewer, or satisfy any required independent-critique condition. All
   existing approval routes and non-waivable Method constraints remain in
   force.
3. Before CEO acceptance of a project's SDP, the human owner approves explicit
   limits for that project. The limits cover the applicable scope, cost,
   schedule, and resource commitments. There are no global numeric caps.
4. The owner-approved limits and their project scope must be revision-bound
   evidence available to the CEO's decision. CEO acceptance is permitted only
   when the proposed SDP or changed commitment is within those limits. Missing,
   ambiguous, or exceeded limits block CEO acceptance and route the decision to
   the human owner. In human-owner capacity, the owner may reject the proposal
   or approve revised limits and commitments through a new exact decision.
5. The Solution Architect and Project Manager continue to assess project
   consequences. A commitment decision does not replace design accountability,
   project redesign, required artifact review, or the applicable lifecycle
   gate.

The human owner made these decisions directly on 2026-11-11. This ADR records
them; it does not infer a delegation from a role title or schema-valid claim.

## Consequences

- The approval route identifies authority capacity even when one person holds
  both capacities.
- Each project must establish its own owner-approved commitment envelope before
  the CEO accepts its SDP. The human owner defines applicable limits; this ADR
  does not invent project values.
- An out-of-envelope proposal remains blocked until the human owner decides it.
  An approval must bind the revised envelope and commitments; it does not
  silently extend the previous limits.
- A CEO decision cannot rely on a boolean claim that an action is within bounds
  without revision-bound evidence of the applicable limits.
- No separate CEO agent or autonomous CEO identity may be assumed.
- Independent critics must remain distinct from the author and from one another
  where the applicable review requires independence.
- The decision structure does not itself authenticate identities or enforce
  permissions. See [enforcement boundaries](../implementation/enforcement-boundaries.md).

## Alternatives

| Alternative | Disposition |
| --- | --- |
| Treat CEO and human owner as interchangeable authority labels | Not selected; the owner assigned distinct authority capacities even though one human holds both. |
| Treat the CEO as an agent or separate actor | Not selected; the owner states there is no CEO agent and escalations reach the owner. |
| Use one global numeric limit for every project | Not selected; the owner chose project-specific limits and no global caps. |
| Allow CEO acceptance when limits are absent or unclear | Not selected; missing or ambiguous limits block acceptance and escalate. |

## Related decisions and specifications

- [GOV-OD11 and GOV-OD12](../governance/owner-decisions-2026-11-11.md): role identity and project commitment bounds.
- [ADR 0001](0001-approval-process-structure.md): approval routes, role authority, and escalation mechanics.
- [Roles and decisions](../governance/roles-and-decisions.md): role responsibilities.
- [Decision and approval matrix](../governance/decision-and-approval-matrix.md): artifact-specific authority.
- [Project alternatives and selected SDP](../templates/artifacts/software-development-plan.md): SDP acceptance evidence.
- [Change and approval validity](../governance/change-approval-validity.md): current-context evidence and change reassessment.
- [Lifecycle gates](../process/lifecycle-gates.md): SDP and resume prerequisites.

