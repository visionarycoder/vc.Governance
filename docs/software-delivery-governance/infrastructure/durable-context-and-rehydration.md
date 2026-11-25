---
title: Durable Context and Rehydration
address: governance/infrastructure/durable-context-and-rehydration
type: governance
owner: agent/ceo
status: active
aliases: [durable-context-and-rehydration]
tags: [context-management, durable-context, governance, rehydration]
version: 1.0.0
last_updated: 2026-11-24
---

# Durable Context and Rehydration

An agent's durable context is stored under its address so that any replacement runtime can be rehydrated by address and resume the same role. This document defines the governing contract. The schema and flow in the reference section are non-normative.

## Contract

1. **Authoritative state wins.** Approved artifacts, work items, queues, and decision records are the source of truth. Durable context and session history are hints and never override them.
2. **One log per address.** Every agent address has exactly one append-only event log. Entries are never edited or deleted. Resolved or superseded entries remain discoverable.
3. **Addressable.** Durable context is located by address through [address resolution](address-resolution.md). Agents never depend on storage paths. Entries reference other things by address only.
4. **Ownership of writes.** Only the owning agent appends to its log. The PM may additionally append `recovery` events. No other agent writes to it.
5. **Tamper evidence.** Each entry carries a hash of its predecessor. A broken chain is a governance incident and escalates to the PM, and recovery falls back to Rebuild.
6. **Retained outside the repository.** Event logs, manifests, and checkpoints are runtime state and are not committed to the governance repository. Governance artifacts remain in git. A checkpoint hash may be committed as a tamper anchor.
7. **Mechanism is implementation-defined.** Governance mandates the properties above, not a storage backend, format, or runtime. JSONL is the reference format.

## What must be durable

Identity and role, authority reference, governance version in force, active work, open messages, decisions made, artifact revisions authored or reviewed, durable knowledge, and recovery history.

## Checkpoints

A checkpoint is a derived, disposable summary of state at a given event sequence. It accelerates recovery and is never authoritative. Agents must take a checkpoint:

- at every work-item state change, approval, rejection, and escalation;
- before a planned restart or shutdown and when the PM initiates recovery.

Further cadence (for example every N events, or after a successful recovery) is a tuning decision of the implementation. Retain more than one recent checkpoint so a corrupt one falls back to its predecessor rather than forcing a Rebuild.

## Rehydration by address

1. **Resolve** the address to its store deterministically.
2. **Load P0** (identity and governance): read the manifest and the role definition at the recorded governance version. If governance has changed, load the new rules and note the delta.
3. **Verify** the hash chain from the latest checkpoint to the tail.
4. **Load P1** (current work): start from the latest valid checkpoint, replay later events, and fetch referenced artifacts at their current approved revisions.
5. **Reconcile** replayed state against authoritative artifacts and queues. Artifacts win. Append a `recovery` event recording any correction.
6. **Load P2 and P3 lazily** by address as needed, per [context management](context-management.md).
7. **Resume** under the same address. Append a `recovery` event with the level used and the new runtime, and notify the PM.

Recovery levels map to this flow as defined in [agent recovery](agent-recovery.md): Resume uses the manifest and log tail, Rehydrate performs all steps, Rebuild ignores the log and uses authoritative state only, and Rebirth additionally discards session history as untrusted.

## Reference schema (non-normative)

```text
state/
  agent/sa/
    manifest.json        # identity snapshot; a cache rebuilt from the log
    events.jsonl         # append-only event log
    checkpoints/
      000042.json        # derived snapshot at event seq 42
```

Event record, one JSON object per line:

```json
{
  "seq": 43,
  "ts": "2026-11-24T20:40:00Z",
  "address": "agent/sa",
  "type": "decision",
  "subject": "work/customer/create-017",
  "refs": ["contract/customer"],
  "payload": {},
  "prev": "sha256:...",
  "actor": "agent/sa",
  "runtime": "session-id"
}
```

Event types: `identity`, `work-assigned`, `work-state`, `message-received`, `message-resolved`, `decision`, `artifact-revision`, `knowledge`, `checkpoint`, `recovery`. Large content stays in artifacts and is referenced by address.

Manifest fields: `address`, `role`, `authority_ref`, `governance_version`, `last_seq`, `last_checkpoint`, `active_work`, `open_messages`, `status`.

## Related

- [Agent context templates](../../../templates/agent-context/README.md)
- [Agent identity and persistence](agent-identity-and-persistence.md)
- [Agent recovery](agent-recovery.md)
- [Context management](context-management.md)
- [Address resolution](address-resolution.md)
- [Global addressing](global-addressing.md)
