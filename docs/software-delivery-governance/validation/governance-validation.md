---
title: Governance Validation
address: governance/validation/rules
type: governance
owner: agent/ceo
status: active
aliases: [governance-validation]
tags: [governance, governance-validation]
version: 1.1.0
last_updated: 2026-11-27
---

# Governance Validation

Governance rules should be mechanically enforced where practical. Validate addresses, single ownership, ownership resolution, modification authority, artifact/work/revision states, aliases, ontology terms, relationships, reviews, approvals, Change Sets, work conflicts, and derived-index consistency.

Validation failures fail closed. The affected change cannot become Active. The PM routes the problem to the proper authority.

The governance validator also exposes the LSI gate: `dotnet run --project tools/governance-validator/GovernanceValidator.csproj -- --integrity <manifest.json>`. CI builds the tool solution, runs positive and negative LSI tests, validates Markdown/template JSON, and checks repository links on every push and pull request.
