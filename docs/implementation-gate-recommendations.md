---
title: Governance Gate Guidance
address: governance/implementation-gate-recommendations
type: governance
owner: agent/pm
status: active
tags: [build-validation, governance, integrity]
aliases: [implementation-gate-recommendations]
version: 1.1.0
last_updated: 2026-11-27
---

# Governance Gate Guidance

Governance CI validates this repository's policy artifacts and tools. It does not build, execute, or write to application repositories.

## Required checks

The repository workflow builds Governance tools, runs the LSI validator tests, validates Markdown front matter and template JSON, and checks wikilinks. Each consuming repository owns its application build, test, security, and release checks.

For a Change Set, use [Logical Software Integrity](software-delivery-governance/validation/logical-software-integrity.md) to bind approved inputs, implementation, independent verification, syndromes, correction bounds, and checkpoints. A consumer CI pipeline must pin the Governance version, invoke the validator for its manifest, and bind passing results to its own protected checks.

## Ownership boundaries

- `vc.Governance` owns the process, role authority, artifact contracts, and policy validation.
- `vc.Agentic` owns reusable agent skills, prompts, and execution templates.
- `vc.Ifx` owns reusable runtime libraries, integration code, executable framework tests, and package delivery.

Cross-repository work uses the existing ownership and escalation policies. Governance does not assume a sibling checkout, product runtime, vendor executable, or application-specific file path.
