---
title: solution-architect-checklist
address: checklist/solution-architect
artifact-type: checklist
owner: agent/sa
aliases: [solution-architect-checklist]
tags: [checklist, solution-architect-checklist]
status: active
version: 1.1.0
last_updated: 2026-11-25
---

# Solution Architect Checklist

> [!purpose]
> Execution gates for the Solution Architect when applying the-method and producing or changing system-design.

## Requirements Analysis

- [ ] Applicable requirements are identified.
- [ ] Requirement ambiguity is routed to the Product Owner.
- [ ] Requirement interpretations that affect future work are recorded as decision records.
- [ ] Business intent is preserved without introducing unapproved requirements.

## Volatility Analysis

- [ ] Potential areas of change are identified.
- [ ] Volatility is distinguished from ordinary implementation variability.
- [ ] Volatility findings are documented before decomposition.
- [ ] The decomposition isolates expected change where practical.

## System Decomposition

- [ ] System responsibilities are identified.
- [ ] Component boundaries follow the approved decomposition.
- [ ] Manager, Engine, Access, Contracts, IFX, and Util boundaries follow application-suite architecture rules where applicable.
- [ ] Cross-component calls follow the closed call hierarchy (Client → Manager; Manager → Engine/Access; Engine → Access; Manager ↔ Manager only via the message bus with the caller as a virtual client).
- [ ] Manager, Engine, and Access components use handler patterns internally.
- [ ] Util components are named `Suite.Util.<Capability>`, contain no business-related content, and have a durable Application Architect and developer agent.
- [ ] Cross-component coupling is minimized.
- [ ] Shared implementation is treated as an architectural decision.
- [ ] Components do not duplicate responsibilities without an explicit decision.

## System Design

- [ ] system-design is updated.
- [ ] Component responsibilities are documented.
- [ ] Component interactions are documented.
- [ ] Required contracts are identified.
- [ ] Surface Area impacts are identified.
- [ ] Quality attributes are addressed.
- [ ] Development and code-quality constraints are defined.
- [ ] Unit-test coverage requirements are defined.

## Impact Analysis

- [ ] Changed artifacts are identified by global address.
- [ ] Impacted contracts are identified.
- [ ] Impacted Surface Area entries are identified.
- [ ] Impacted Application Architects are identified.
- [ ] Test Architect impact is identified.
- [ ] Downstream dependencies are identified.
- [ ] Required Change Sets are identified or created through the governed process.

## Review and Approval

- [ ] Required Application Architect reviews are complete.
- [ ] Test Architect review is complete when verification is affected.
- [ ] Product Owner is involved when requirement meaning or observable product behavior changes.
- [ ] Architectural decisions are persisted as decision records.
- [ ] Contract breaking changes have explicit SA approval.
- [ ] The proposed design is internally consistent.

## Ready for Project Design

- [ ] The design is sufficiently defined for the Project Manager to derive activities.
- [ ] Work boundaries can be identified without the PM inventing architecture.
- [ ] Dependencies relevant to sequencing are documented.
- [ ] Known risks and constraints are documented.
- [ ] Ownership of affected authoritative artifacts is deterministic.

## Stop Conditions

> [!warning]
> Stop and escalate instead of inventing an answer when any condition below is true.

- [ ] Requirement meaning is unresolved.
- [ ] Required artifact ownership cannot be resolved.
- [ ] Two authorities claim conflicting ownership.
- [ ] A proposed design violates an approved requirement.
- [ ] A cross-component conflict cannot be resolved by the affected Application Architects.
- [ ] Verification and implementation authorities disagree and the conflict cannot be resolved directly.
- [ ] Service classes expose **generic** async methods (e.g., `FindAsync<T>`). 
- [ ] For each generic method, a **handler interface** (`IHandler<Req,Res<T>>`) is defined. 
- [ ] All concrete handlers are **registered** in the DI container and listed in a governance artefact (`handler-registry.yaml`).
- [ ] The validator is configured to ensure **no missing handler** for any generic method used in the service.
- [ ] Documentation of the mapping (`T` → `*Handler`) is included in the system-design diagram.
- [ ] A required CEO or Product Owner decision is missing.

## Related

- the-method
- system-design
- requirements-analysis
- volatility-analysis
- decomposition
- structure
- composition
- design-validation
- architecture-decision
- cross-component-decision
- contract-change-decision
