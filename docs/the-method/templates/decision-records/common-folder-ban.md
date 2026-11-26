---
title: Ban "common" folder
address: governance/bans/common-folder
owner: agent/pm
version: 1.0.0
last_updated: 2026-11-25
---

# Prohibited repository folder

**Folder name:** `common`

## Rationale
* The *Volatility‑Based Decomposition* method (Juval Lowy) requires that every artefact belonging to the governed system be placed in a *gate‑specific* component folder under `tools/Dsuite/AddOns/<Gate>`.
* A top‑level `common` directory is a *shared‑utility* location that falls outside any gate. It creates an implicit shared library, which Lowy explicitly discourages because it bypasses the gate‑boundary verification and makes the solution non‑portable.
* Agents that automatically copy or reference files from a `common` folder will generate hidden dependencies that the validator cannot detect, leading to build‑gate failures.

## Policy
* **Do not create** a `common` folder in any future version of the repository.
* If a team feels a utility is needed, place it **inside the appropriate gate folder** so it is versioned, validated, and portable with that gate.
* Existing code that currently references `common/*` must be refactored to reference the concrete gate component.

## Enforcement
* The governance validator will fail if it discovers a top‑level directory named `common`.
* The solution‑architect checklist must contain the item:
  - `[ ] Verify that no `common` folder exists in the repository root.`

## Exceptions
* None. Any deviation must be approved by the **Governance Council** and recorded as a separate decision record.
