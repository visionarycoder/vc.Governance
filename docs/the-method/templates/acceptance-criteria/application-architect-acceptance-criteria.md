---
title: application-architect-acceptance-criteria
address: template/acceptance-criteria/application-architect
type: template
owner: agent/sa
authority: agent/sa
aliases: [application-architect-acceptance-criteria]
tags: [acceptance, application-architect-acceptance-criteria, criteria]
version: 1.1.0
last_updated: 2026-11-24
---

# Application Architect Acceptance Criteria

## Identity

- Work: `work/...`
- Application Architect: `agent/aa/...`
- Solution Architect: `agent/sa`
- Component:
- Change Set:

## Design Change

- [ ] The assigned Application Architect is the sole author and owner of the submitted Detailed Design.
- [ ] Requested change is reflected in the component Detailed Design.
- [ ] Requested System Design shape changes are identified.
- [ ] Component responsibilities remain within the SA-approved decomposition.
- [ ] Public contracts and Surface Area impacts are identified.
- [ ] Impact analysis is complete.
- [ ] Impacted Application Architects are identified and reviewed where required.
- [ ] Test Architect review is complete where verification is affected.
- [ ] Requirement-semantic changes were routed to the Product Owner.
- [ ] Breaking contract changes have SA approval.
- [ ] Required decision records exist.

## SA Conformance Gate

- [ ] The submission identifies the Detailed Design revision and approved System Design baseline.
- [ ] The Solution Architect reviews the submitted revision after design and records approval or rejection with findings.
- [ ] If rejected, the owning Application Architect addresses the findings and submits a new revision for SA review. Acceptance stays pending until a revision passes.
- [ ] Changes required to the approved System Design are resolved through System Design governance before the AA resubmits against the new baseline.
- [ ] The accepted revision has an explicit SA approval.

## Evidence

- System Design:
- Detailed Design:
- SA disposition and findings by submitted revision:
- AA resolution of prior findings:
- Contract(s):
- Impact analysis:
- Reviews:
- Decision(s):

## Acceptance

- Status: `pending | accepted | rejected`
- Accepted By: `agent/sa`
