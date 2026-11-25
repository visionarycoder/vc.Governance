---
title: build-validation-decision
address: decision/build-validation
owner: agent/pm
version: 1.1.0
last_updated: 2026-11-25
---

# Build Validation Decision

> This decision record captures the outcome of the automated build and validation step for a governed add‑on gate.

## Decision
The build of the add‑on project succeeded (or failed) and the validator produced the following results.

## Context
The add‑on project for gate **${gate}** was compiled, the validator script ran, and the log file was written to `docs/instructions/probe/${gate}-probe-log.txt`.

## Inputs
- Git commit hash: `${commit}`
- Build log: `${build_log}`
- Validator output: `${validator_output}`

## Alternatives Considered
- Manual build and test
- Skipping validation

## Rationale
Automated validation reduces human error and ensures consistent gating.

## Impact
- The gate is marked **Pass** only if the validator exits with code 0 and the log file contains no PII.
- Failure results in a **Fail** decision and triggers a review.

## Volatility Analysis
- Identify change drivers and affected artifacts for the gate.
- Record the rationale for the component boundary based on volatility.
- Include the analysis JSON reference `docs/volatility/volatility-analysis-${gate}.json`.

## Required Changes
- Add or update the CI workflow to invoke the validator.
- Update status.md accordingly.

## Provenance
- Requested by: `agent/pm`
- Produced by: `agent/pm`
- Approved by: `agent/pm`

## Supersedes
- None

## Related
- `decision/build-validation-decision`
- `decision/verification-decision`
