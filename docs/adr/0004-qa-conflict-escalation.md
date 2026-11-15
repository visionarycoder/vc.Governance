---
metadata-version: 1.0.0
title: ADR 0004: QA conflict escalation
description: Record the owner's exception route for QA findings that implicate an escalation authority.
document-type: governance-policy
repository: vc.Governance
language: Standard Technical English
updated: 2026-11-11
version: # VERSION
1.0.0
last_updated: 2026-11-14
---

# ADR 0004: QA conflict escalation

## Status

Accepted as a record of the human owner's explicit decisions GOV-OD13 and
GOV-OD14, recorded on 2026-11-11. This ADR does not approve an individual QA
finding or deploy an enforcement mechanism.

## Context

The normal route has QA report to the Solution Architect (SA), with the SA
reviewing QA findings. That route does not resolve a finding that implicates
the SA or the SA's failure to provide a required response. The CEO and human
owner are also the same human actor under distinct authority capacities, so a
finding about the human owner's own conduct cannot be independently reviewed
by that person.

These are owner-selected organizational assignments, not rules attributed to
Löwy. The [approval matrix](../governance/decision-and-approval-matrix.md),
[owner decisions](../governance/owner-decisions-2026-11-11.md), and
[enforcement boundaries](../implementation/enforcement-boundaries.md) remain
controlling.

## Decision

1. QA continues to use the Solution Architect review route for ordinary
   findings.
2. If a finding implicates the Solution Architect, or the SA does not provide
   a required response, QA may escalate directly to the human owner in
   human-owner capacity without waiting for SA review. The human owner
   appoints a competent reviewer independent of the SA and decides the
   response. No global response deadline is created by this decision.
3. If a finding implicates the human owner / CEO, QA sends it directly to the
   human owner in human-owner capacity. The owner cannot act as the independent
   reviewer of their own conduct. The human owner appoints a competent
   independent reviewer and retains final decision authority. The reviewer
   supplies independent assessment; appointment does not transfer the
   decision right.
4. If no qualified independent reviewer is available for an
   owner-implicated finding, the affected work remains held and the finding
   remains unresolved. Unaffected authorized work may continue. Missing
   review evidence does not authorize the affected action.
5. These routes do not change QA's responsibility to document evidence and
   root-cause analysis, the SA's normal ownership, the applicable artifact
   reviews, or the authority required to approve a framework change or
   guideline departure.

The human owner selected these routes directly on 2026-11-11. This ADR records
that decision; it does not create a new leadership office or independent
authority above the human owner.

## Consequences

- QA has a direct route around an implicated or non-responsive SA without
  converting every QA finding into a human-owner escalation.
- The human owner remains the decision-maker for the escalated response but
  does not substitute their own judgment for the independent review when
  personally implicated.
- If an owner-implicated finding cannot receive qualified independent review,
  the affected scope remains blocked rather than receiving a success-shaped
  disposition.
- The route does not change Method constraints, permit self-approval, or
  establish technical enforcement.

## Alternatives

| Alternative | Disposition |
| --- | --- |
| Require every QA finding to pass through the SA, including findings about the SA | Not selected; it leaves the conflict unresolved. |
| Allow the human owner to serve as their own reviewer when implicated | Not selected; the owner explicitly cannot self-review. |
| Transfer final authority to the appointed reviewer | Not selected; the owner retains final decision authority. |
| Proceed when no qualified reviewer is available | Not selected for an owner-implicated finding; affected work remains held and the issue unresolved. |

## Related decisions and specifications

- [GOV-OD13–GOV-OD14](../governance/owner-decisions-2026-11-11.md): QA escalation and owner-conflict handling.
- [ADR 0001](0001-approval-process-structure.md): approval routes, role authority, and established escalation mechanics.
- [Roles and decisions](../governance/roles-and-decisions.md): QA's normal reporting line and role boundaries.
- [Decision and approval matrix](../governance/decision-and-approval-matrix.md): artifact-specific review and approval routes.
- [QA finding template](../templates/artifacts/qa-finding.md): required finding evidence.
- [Enforcement boundaries](../implementation/enforcement-boundaries.md): limits of documentation-only controls.

