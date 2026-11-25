---
title: Governance Invariants
address: governance/principles/invariants
type: governance
owner: agent/ceo
status: active
aliases: [governance-invariants]
tags: [governance, governance-invariants]
version: 1.0.0
last_updated: 2026-11-14
---

# Governance Invariants

- **I-01** Every governed entity has a globally unique address.
- **I-02** Every authoritative artifact has exactly one owner.
- **I-03** Ownership lookup is deterministic.
- **I-04** Only the owner may modify an owned authoritative artifact, except through explicit CEO authority.
- **I-05** Ownership cannot normally be delegated.
- **I-06** Subagents do not acquire their parent's ownership authority.
- **I-07** Only the PM creates and assigns authoritative work.
- **I-08** Messages do not independently create modification authority.
- **I-09** Resolved messages leave active context but remain historically available.
- **I-10** The PM prevents concurrent conflicting authoritative modifications.
- **I-11** Conflicts escalate before conflicting implementation proceeds.
- **I-12** Historical revisions are immutable.
- **I-13** Renames do not destroy historical identity.
- **I-14** Aliases resolve historical names to canonical identities.
- **I-15** Significant decisions survive agent session destruction.
- **I-16** Session history is not authoritative application-suite state.
- **I-17** Derived indexes are rebuildable.
- **I-18** Agents may retrieve needed artifacts and evict irrelevant ones.
- **I-19** Failed governance validation prevents activation.
- **I-20** An agent retains its address through restart, rehydration, rebuild, and rebirth.
- **I-21** Requirements may normally be modified only by the PO.
- **I-22** System architecture is controlled by the SA.
- **I-23** Component architecture and contracts are controlled by the owning AA.
- **I-24** Production implementation operates within AA and SA constraints.
- **I-25** Unit tests are created by the Dev; coverage requirements are defined by the SA.
- **I-26** Independent verification is controlled by the TA and implemented by Test Devs.
- **I-27** AAs cannot control verification merely because their components are tested.
- **I-28** Passing verification does not replace PO product acceptance.
