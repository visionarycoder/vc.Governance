---
metadata-version: 1.0.0
title: ADR 0005: Enforcement handoff and deployment boundary
description: Record the governance-only resolution and remaining platform-specific enforcement work.
document-type: governance-policy
repository: vc.Governance
language: Standard Technical English
updated: 2026-11-11
version: # VERSION
1.0.0
last_updated: 2026-11-14
---

# ADR 0005: Enforcement handoff and deployment boundary

## Status

Accepted as a record of the human owner's explicit decision GOV-OD15, recorded
on 2026-11-11. It does not select a platform, issue a project assignment, or
claim that runtime controls have been deployed.

## Context

The [enforcement boundaries](../implementation/enforcement-boundaries.md)
already specify required protections and verification scenarios, and state
that these protections have not been deployed or tested. Repository ownership
assigns reusable mechanisms to vc.Ifx and permission provisioning to a
selected execution platform. No platform, target resources, or external
permissions were inspected for this decision.

## Decision

1. Close this review issue at governance level by preserving an explicit
   implementation handoff and acceptance basis. Keep runtime implementation,
   deployment, and verified enforcement open.
2. Do not select an execution platform or alter platform permissions through
   this record. Do not modify vc.Ifx or another owning repository without an
   explicit work assignment.
3. Before implementation, the human owner and Solution Architect select the
   target platform and scope. Apply existing authority routes for detailed
   design, Test Architect verification planning, and Project Manager work
   assignment. Reusable mechanisms belong in vc.Ifx; permission provisioning
   belongs to the selected execution platform.
4. Do not claim enforcement until controls are deployed and the required
   [verification scenarios](../implementation/enforcement-boundaries.md) pass
   against the actual identities, tools, resources, and integration
   configuration. Bind verification evidence to the tested revisions and
   environment, and resolve blocking findings before acceptance.
5. This handoff and its verification criteria do not authorize deployment or
   live operation. Use the applicable project and operational approval route
   for those actions.

The human owner selected this governance-only resolution directly on
2026-11-11. It preserves current repository ownership and does not resolve the
open platform, identity, permission, or deployment choices.

## Consequences

- The governance requirements and acceptance scenarios remain available to
  the owning implementation and platform teams.
- Platform-specific design, identity provisioning, implementation, and
  operational verification require a separate approved scope and assignment.
- The repository continues to state truthfully that enforcement is not
  deployed or tested; documentation alone is not technical protection.
- No application or platform is authorized for deployment by this decision.

## Alternatives

| Alternative | Disposition |
| --- | --- |
| Choose a platform or permission model without the responsible design and owner decisions | Not selected; no platform or target resource was identified or inspected. |
| Treat documentation or JSON conformance criteria as deployed enforcement | Not selected; neither authenticates identities nor controls permissions. |
| Modify vc.Ifx or platform resources without an assignment | Not selected; repository and platform ownership remain in force. |

## Related decisions and specifications

- [GOV-OD15](../governance/owner-decisions-2026-11-11.md): governance-only handoff and open deployment status.
- [Enforcement boundaries](../implementation/enforcement-boundaries.md): required controls, verification scenarios, and current state.
- [Framework and implementation ownership](../implementation/repository-ownership.md): repository and platform responsibility.
- [Open decisions](../governance/open-decisions.md): unresolved platform and execution choices.
- [Lifecycle gates](../process/lifecycle-gates.md): lifecycle passage does not authorize deployment or live operation.
