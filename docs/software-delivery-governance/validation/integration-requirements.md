---
title: LSI Integration Requirements
address: governance/validation/lsi-integration-requirements
type: governance
owner: agent/ceo
status: active
aliases: [lsi-integration-requirements]
tags: [governance, integration, integrity]
version: 1.0.0
last_updated: 2026-11-27
---

# LSI Integration Requirements

These are repository-specific follow-up contracts. This Governance change does not edit `vc.Agentic` or `vc.Ifx`.

| Repository | Required integration |
|---|---|
| `vc.Agentic` | Pin the Governance version and LSI schema for each agent run. Require role instructions to load the Change Set manifest, preserve exact artifact revisions/hashes, create bidirectional requirement links, emit structured syndromes, stop correction at its bound, and invalidate checkpoints after changed inputs. The PM pauses and reassigns stale work. Keep agents subordinate to existing ownership and escalation. |
| `vc.Agentic` | Require a distinct authenticated verifier identity. Preserve verifier, run ID, source revision, outcome, and immutable evidence reference. Agents cannot self-approve or promote local output to protected CI evidence. |
| `vc.Ifx` | Define reusable contracts and deterministic validator/test support only when justified across consumers. Keep mechanisms in VBD-owning projects and preserve dependency direction. Verify behavior in contract, composition, and integration tests where applicable. Do not add Governance dependencies to production libraries. |
| `vc.Ifx` | Publish reproducible build/test results keyed to exact requirement/design and source revisions, with stable artifact hashes and failure syndromes. Changed dependencies or inputs invalidate dependent evidence and checkpoints. |

## Acceptance evidence

- One approved consumer Change Set passes Governance LSI validation and protected repository CI.
- A second identity independently verifies a change; self-verification is rejected.
- Tests cover forward and reverse requirement traceability.
- Changing a protected input without invalidating its checkpoint is rejected; invalidation pauses work until PM reassignment and verification rerun.
- An open blocker prevents the verified gate. Correction at its attempt bound escalates and remains blocked.
- Governance, Agentic, and Ifx retain separate ownership. This document does not authorize edits in the latter two repositories.

The Governance validator checks structure and consistency. Each consuming repository must bind its evidence to its authenticated CI provider and protected required checks.
