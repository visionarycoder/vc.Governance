---
metadata-version: 1.0.0
title: Instructions for agents working on vc.Governance
description: Direct agents to preserve repository scope, source authority, and approval requirements.
document-type: agent-instructions
repository: vc.Governance
language: Standard Technical English
updated: 2026-11-11
version: # VERSION
1.0.0
last_updated: 2026-11-14
---

# Instructions for agents working on vc.Governance

## Authority

The human owner has adopted Appendix C of Juval Löwy's Righting Software as the governing design standard. Read [source authority](docs/governance/source-authority.md) and the complete [design standard map](docs/standards/design-standard.md) before changing framework rules or process definitions. Consult the corresponding book discussion when applying an item whose context matters.

The only adaptation authorized here is assigning work to agents under the human owner's role and decision hierarchy. Do not introduce an alternative design methodology, weaken source constraints for implementation convenience, or attribute an organizational or enforcement choice to Löwy without a supporting source.

Preserve the distinction between directives and guidelines. Directives cannot be waived. Guidelines require strong, unusual justification as described in Appendix C; a worker cannot approve its own departure. Escalate through the responsible design owner. A disagreement does not grant permission to proceed outside the approved design.

## Repository scope

This repository defines a reusable framework. Do not apply it to this repository as an application or modify the sibling vc.App.Latimessis project without a work assignment to do so. Do not choose an application stack before the CEO and Solution Architect establish the baseline.

The owner assigned reusable implementation mechanisms to the repository named vc.Ifx. Keep Method rules, required constraints, roles, and process here. Put production generators, analyzers, code fixes, proxies, interception infrastructure, build-time instrumentation, and their executable tests in vc.Ifx. See [repository ownership](docs/implementation/repository-ownership.md). Do not grow implementation-specific design work here beyond a traceable requirement and handoff.

Use [Righting Software](https://www.amazon.com/dp/0136524036) and the edition details in [sources and bibliography](docs/sources.md) for book references. The owner removed the reference directory. Do not restore source copies or claim access to missing text; obtain authorized access when a source-dependent question requires it. Use relative links to in-repository documents in repository documentation. Web resources remain permitted. Do not refer documentation readers to external filesystem paths. Keep temporary full-text extractions and rendered research pages outside the repository. Cite printed page numbers, headings, and item identifiers. Repository paraphrases are navigation aids; the source governs if wording differs.

## Changes and verification

For each change to a rule, identify the source item, the responsible decision owner, and whether the change is a source correction, an organizational assignment, or an enforcement mechanism. Do not promote an unresolved choice to an adopted rule.

Keep ownership of system and project design with one accountable Solution Architect. Application Architects perform delegated detailed design within that system design. The Project Manager assigns work and tracks execution; the architect remains accountable for project design.

Do not report that a book was fully read when only excerpts were reviewed. Update the source review record when additional material has actually been examined. Extraction is not equivalent to reading or verifying diagrams and equations.

These instructions communicate authority. They do not themselves provide tamper resistance. Do not claim technical enforcement until separately controlled permissions and integration checks have been implemented and verified. Platform selection and a current PM assignment are prerequisites to implementation; the governance handoff does not authorize deployment or sibling-repository changes.

The [Standard Technical English rules](docs/standards/rules.ste.md) and [JSON records](docs/standards/rules.json) are source-derived aids. Read their context and exception policies. Do not rewrite a rule, test, or approval requirement to make your own implementation pass. Their presence does not establish technical protection.

## Current technical guidance

For technical implementation, follow the [Microsoft technical standard](docs/standards/microsoft-technical-standard.md) and [technical rule records](docs/standards/technical-rules.json). Use current official Microsoft guidance within the approved technology baseline. The owner prohibits underscore naming prefixes: use unprefixed fields, including static fields. Preserve original third-party source references. Workers cannot alter SDK selection, analyzers, build settings, or suppressions to make their own work pass. Current implementation guidance does not change Method boundaries.

## Owner component design

Apply the [owner architecture policy](docs/governance/owner-architecture-policy.md), including [internal component handlers](docs/standards/component-handlers.md). Every approved component delegates implementation details from its service implementation class to internal handlers. Handlers remain within the component's reviewed responsibility and do not bypass cross-component proxy requirements. This is an owner-selected constraint, not a rule attributed to Löwy.

## Component proxy boundary

Follow the [mandatory proxy policy](docs/patterns/component-proxies.md) and [proxy rule records](docs/standards/proxy-rules.json). All calls between approved components require a DI-capable proxy. Without service-level separation, use a generated typed proxy. Do not implement reflection-based proxies. Dapr service invocation is accepted but not mandated. Internal collaborator calls are excluded. Workers cannot bypass the chain or change its governing inputs.

## Decision and artifact contracts

Use the [decision matrix](docs/governance/decision-and-approval-matrix.md), [owner decisions (2026-11-07)](docs/governance/owner-decisions-2026-11-07.md) and [owner decisions (2026-11-11)](docs/governance/owner-decisions-2026-11-11.md), and [artifact contracts](docs/artifacts/README.md) for authorship, review, and approval. Solution Architect decisions obtain CEO approval. Application/Test Architects can adjust instructions within upstream bounds. Every guideline departure requires human-owner approval; directives remain non-waivable. Example records never authorize work. Schema-valid role claims do not authenticate an actor or grant permissions.

The CEO and human owner are the same human actor under distinct authority
capacities; there is no CEO agent. Escalations reach this human. The decision
record must identify the capacity authorizing the action, and identity overlap
does not satisfy independent critique. QA may escalate directly to the human
owner when a finding implicates the Solution Architect or the SA does not
provide a required response. If the owner is implicated, QA sends the finding
directly to the owner in human-owner capacity; the owner cannot self-review,
appoints an independent reviewer, and retains final authority. If no
qualified reviewer is available, hold affected work and record an
owner-implicated finding as unresolved.

## Lifecycle actions and acceptance

Apply gates to the requested action and current context. A known failed criterion fails the action. Missing or unverified evidence blocks it. A previous pass does not establish current authority after a relevant change. Noncoding activities use their project-designed criteria; do not force every activity through the service lifecycle.

The CEO approves Solution Architect-owned system requirements, system design, technology baseline, and project-design decisions. The selected SDP requires management acceptance before main construction. The Project Manager assigns work; gate passage alone does not assign a worker. Preserve the reviewed service-requirements split into concurrent test planning and bounded exploration/detailed design.

Detailed designs and contracts require Solution Architect review and acceptance, with Test Architect input, before handoff. Full construction requires the reviewed requirements and detailed design, accepted SDP, and current PM assignment. The developer constructs the component and its white-box test client together. Every discovered design refinement goes to the Application Architect before construction proceeds under it.

The Application Architect accepts implementation after successful critique by the Application Architect and an independent Test Agent. The Test Architect approves service/system test plans and verification reports after their required reviews. The Solution Architect separately accepts technical integration. Integration phase completion requires integration acceptance and successful plan-based verification of the same integrated context. The PM records binary phase completion; commits, effort, and tokens do not establish completion. Milestone acceptance includes its required project tests and Product Owner acceptance. No lifecycle gate independently authorizes deployment or live operation.

When changes affect scope, resources, dependencies, schedule, or cost, the Solution Architect and PM assess project consequences. Before CEO acceptance of an SDP, the human owner approves explicit project-specific limits for applicable scope, cost, schedule, and resources; there are no global numeric caps. The CEO accepts revised commitments only within those exact limits. Missing, ambiguous, or exceeded limits block CEO acceptance. The human owner decides out-of-envelope proposals in human-owner capacity and records any revised limits and commitments before affected work resumes. Apply the existing change and resume rules before resuming affected work.

## Governance documentation and current applicability

Use the [table of contents](docs/toc.md) and [topic index](docs/index.md) for current documentation. Apply [lifecycle gates](docs/process/lifecycle-gates.md) and [change/approval validity](docs/governance/change-approval-validity.md) to the requested context. Preserve unaffected authorized work and the parallel STP/design paths. Unresolved source conflicts go directly to the human owner. Leadership disputes escalate after three completed unresolved rounds; each round requires the Solution Architect, Product Owner, and Project Manager positions on the same dispute and a summary of remaining disagreement. Failed reviews and test retries are correction loops, not discussion rounds. Do not restore owner-removed technical source copies merely to satisfy a stale reference; mark historical provenance and keep active links truthful.

For project-local agent coordination, apply the [local agent Builder workflow](docs/process/local-agent-builder.md) and its [Markdown templates](docs/templates/builder/README.md). Senders publish separate immutable message files; acknowledgements and responses are separate linked files. Only the Project Manager writes the rebuildable board summary, prompts agents, and remains the formal assignment owner. The Solution Architect, Product Owner, and Project Manager are long-running pollers; agents discover published files whose `To` value matches their exact address, even when the summary is stale. Direct messages do not create assignments. Atomic publication requires a separately verified helper; these documents do not provide runtime identity or permission enforcement.

## Repository-local documentation skills

The [local skill catalog](.agents/README.md) describes the skills in `.agents/skills/`. Select the skill that matches the requested documentation task and read its `SKILL.md` before applying it.

| Skill | Use for | Instructions |
| --- | --- | --- |
| `document-agentic-workflows` | Lifecycle, gate, feedback, and handoff documentation | [SKILL.md](.agents/skills/document-agentic-workflows/SKILL.md) |
| `document-governance-artifacts` | Artifact contracts, templates, field descriptions, and fictional examples | [SKILL.md](.agents/skills/document-governance-artifacts/SKILL.md) |
| `record-governance-decisions` | ADRs and decision documentation that distinguish adopted decisions from proposals | [SKILL.md](.agents/skills/record-governance-decisions/SKILL.md) |
| `review-agentic-workflow-docs` | Review of Method fidelity, approval boundaries, artifact consistency, and handoffs | [SKILL.md](.agents/skills/review-agentic-workflow-docs/SKILL.md) |

Invoke a skill by name, such as `$document-agentic-workflows`, when the client supports repository-local skill discovery. If discovery is unavailable, read the linked instructions directly. Do not claim global installation or automatic discovery without evidence.

Skills reference the governing specifications. They do not grant role authority, authenticate approvals, establish independent critique, enforce worker isolation, or authorize sibling-repository changes. Keep governing rules in their existing specifications instead of duplicating them in skill instructions.

Skill entrypoints use the supported two-field skill metadata profile. Other Markdown uses the seven-field repository document profile. All Markdown remains subject to repository validation. Run `python tools/validate_markdown.py` after documentation changes. Run `python -m unittest discover -s tests -p test_markdown_validation.py` when changing validation code. Review source fidelity and authority separately from automated checks.

## Markdown authoring

Follow the [metadata and Standard Technical English contract](docs/standards/markdown-authoring.md). Update frontmatter when editing a document. Keep exact role names, directive/guideline classifications, rule identifiers, formulas, and source conditions. Run `python tools/validate_markdown.py` after Markdown changes. A passed writing check does not establish semantic correctness or approval.
