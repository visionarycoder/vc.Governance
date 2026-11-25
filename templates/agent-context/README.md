---
title: Agent Context Templates
address: governance/templates/agent-context
owner: agent/pm
version: 1.5.0
last_updated: 2026-11-24
---

# Agent Context Templates

Blank, non-normative starting shapes for an agent's durable context, as described in [durable context and rehydration](../../docs/software-delivery-governance/infrastructure/durable-context-and-rehydration.md).

These files are **templates only**. Real logs, manifests, and checkpoints are runtime state, stay outside this repository, and are stored per agent address (for example `state/agent/sa/`).

| File | Use |
|------|-----|
| `manifest.json` | Identity snapshot for a new agent address. A cache that can always be rebuilt from the log. |
| `event.jsonl` | One example event per type. Real logs are append-only, one JSON object per line. |
| `checkpoint.json` | Derived snapshot at a given event sequence. Disposable. |

## Event fields

| Field | Meaning |
|-------|---------|
| `seq` | Strictly increasing integer per address, starting at 1. |
| `ts` | UTC timestamp, ISO 8601. |
| `address` | Address of the log owner, for example `agent/sa`. |
| `type` | One of `identity`, `work-assigned`, `work-state`, `message-received`, `message-resolved`, `decision`, `artifact-revision`, `knowledge`, `checkpoint`, `recovery`. |
| `subject` | Address of the thing the event is about, or `null`. |
| `refs` | Addresses only, never file paths. |
| `payload` | Small type-specific data. Large content stays in artifacts and is referenced by address. |
| `prev` | Hash of the previous entry's canonical JSON (`sha256:...`). `null` for `seq` 1. |
| `actor` | Address that appended the entry. Only the owner, or the PM for `recovery`. |
| `runtime` | Identifier of the process or session that wrote the entry. |

## Rules

- Append only: never edit or delete entries.
- Use addresses, never storage paths.
- Compute `prev` over the canonical JSON of the preceding entry; a broken chain is a governance incident.
- The `sha256:...` values in these templates are placeholders.
