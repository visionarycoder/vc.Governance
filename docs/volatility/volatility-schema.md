---
title: Volatility Schema
address: volatility/schema
owner: agent/pm
version: 1.0.0
last_updated: 2026-11-25
---

# Volatility Schema

The validator expects each volatility report to conform to the following JSON schema:
```json
{
  "type": "object",
  "required": ["gate", "changeDrivers", "affectedArtifacts", "rationale"],
  "properties": {
    "gate": {"type": "string"},
    "changeDrivers": {"type": "array", "items": {"type": "string"}},
    "affectedArtifacts": {"type": "array", "items": {"type": "string"}},
    "rationale": {"type": "string"},
    "boundaryViolations": {
      "type": "array",
      "items": {"type": "object", "required": ["gate", "reason"], "properties": {"gate": {"type": "string"}, "reason": {"type": "string"}}
    }
  }
}
```
Any file that does not include the required properties will cause the validator to fail.

## Usage
- Place each gate’s report in `docs/volatility/volatility-analysis-<gate>.json`.
- The validator reads all files matching `volatility-analysis-*.json` and validates them against this schema.

## References
- Linked from `volatility-analysis.md`.
