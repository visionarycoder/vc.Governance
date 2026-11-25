---
title: acceptance-criteria
address: template/acceptance-criteria/general
type: template
owner: agent/pm
aliases: [acceptance-criteria]
tags: [acceptance, acceptance-criteria, criteria]
version: 1.0.1
last_updated: 2026-11-25
---

# Acceptance Criteria

## Identity

- Work: `work/...`
- Change Set: `change/...`
- Assigned Agent: `agent/...`
- Acceptance Authority: `agent/...`
- Base Revision(s):

## Required Outcome

State the required outcome in observable terms.

## Authoritative Inputs

- Requirement: `requirement/...`
- Design: `design/...`
- Contract: `contract/...`
- Surface: `surface/...`
- Decision: `decision/...`

## Acceptance Criteria

- [ ] Required outcome is present.
- [ ] Implementation conforms to the referenced authoritative artifacts.
- [ ] No unauthorized authoritative artifact was modified.
- [ ] Volatility analysis shows no uncaptured change‑driver crossing component boundaries.
- [ ] Log file contains no un‑redacted PII.
- [ ] Required documentation and Surface Area entries are current.
- [ ] Required decision records exist.
- [ ] Required review is complete.
- [ ] Acceptance authority approves the result.

## Evidence

For each criterion, reference the artifact, test, result, or decision that proves it.

- Criterion:
  - Evidence:

## Exceptions

No exception is implied by this template. Record an approved exception as a governed decision.

## Acceptance

- Status: `pending | accepted | rejected`
- Accepted By: `agent/...`
- Decision: `decision/...`
- Notes:
