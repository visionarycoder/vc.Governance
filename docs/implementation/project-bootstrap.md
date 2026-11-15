---
metadata-version: 1.0.0
title: Project bootstrap and design conformance
description: Connect existing design, assignment, reuse, and integration obligations.
document-type: governance-policy
repository: vc.Governance
language: Standard Technical English
updated: 2026-11-09
version: # VERSION
1.0.0
last_updated: 2026-11-14
---

# Project bootstrap and design conformance

## Basis and responsibility

This workflow connects existing obligations. It does not change a Method rule,
approve an application design, or select a technology or execution platform.
Source items C-D-2, C-D-3, C-D-5, C-D-6 and C-SD-1.e govern decomposition,
composition, incremental construction, project design and use-case validation.
See the [design standard](../standards/design-standard.md). The owner-selected
[repository ownership](repository-ownership.md) and [enforcement boundaries](enforcement-boundaries.md)
govern reuse and protection. The Solution Architect owns system and project
design. CEO approval and all other decisions retain their existing
[approval routes](../governance/decision-and-approval-matrix.md).

## Prepare the project

1. The Product Owner and Solution Architect prepare the business and system
   inputs under [system and project design](../process/system-and-project-design.md).
   Record volatility boundaries and composition against every core use case.
2. The Solution Architect establishes the approved technology bounds and selected
   SDP through GATE-BASELINE and GATE-SDP. Do not require all detailed designs
   before project design. Keep unresolved decisions visible and hold dependent work.
3. The Application Architect prepares each assigned detailed design. Include a
   reuse assessment in its internal design and dependency constraints. Identify
   each existing mechanism examined, exact package/API version, suitability
   evidence and selected use. Explain any gap that requires new implementation.
   Keep reusable mechanisms in vc.Ifx and application behavior in the application.
4. The Solution Architect reviews and accepts detailed design with Test Architect
   input through the existing route. The Project Manager assigns bounded work.
   Bind requirements, system design, detailed design, SDP and instructions to
   exact revisions and hashes under the [artifact contracts](../artifacts/README.md).

The reuse assessment is content within existing artifact types. It creates no
additional approval role. A package catalog or skill description alone does not
prove suitability. The owner assigned closure of bootstrap and reuse gaps on
2026-11-09; this workflow implements that assignment within existing constraints.

## Construct and verify

The assigned developer inspects the actual reusable APIs and generates only the
accepted structure. Reuse valid existing artifacts. Preserve conflicting artifacts
and route design questions to the Application Architect before proceeding under
a refinement. Construct the component and white-box test client together.
Preserve concurrent test planning and detailed design under the
[service lifecycle](../process/service-lifecycle.md).

Independent integration compares the exact submission to its protected approved
inputs. A design-lock projection can support this comparison. It identifies the
expected projects, permitted dependencies, reusable packages and exact governing
file hashes. The design owner derives it from accepted designs; a worker-generated
snapshot cannot establish the expected design. The projection is an enforcement
mechanism and does not replace any artifact, review, decision or gate.

Structural verification checks project inventory, effective build dependencies,
contract compatibility, package versions, protected settings and proxy-chain
behavior. Semantic critique checks real volatility, behavior and contract cohesion.
Apply [lifecycle gates](../process/lifecycle-gates.md) and
[approval validity](../governance/change-approval-validity.md) to the current action.
Missing evidence blocks that action; a known failure fails it. Preserve unaffected
authorized work. Integration acceptance and successful plan-based verification
must refer to the same integrated context before phase completion.

## Delivery and remaining evidence

vc.Agentic owns reusable task guidance. vc.Ifx owns executable baseline checks and
their tests. The consuming application owns operational records and design locks.
No application stack or representative application design is selected here.

The execution platform must supply authenticated identities, restricted worker
credentials, protected records and independently controlled integration. Before
claiming enforcement, execute all seven scenarios in
[enforcement boundaries](enforcement-boundaries.md). Include an authorized design
change that invalidates affected evidence and then permits valid work to resume.
Record actual results, exact revisions and limits. Portable structural checks do
not establish platform protection or architectural acceptance.
