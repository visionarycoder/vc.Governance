---
metadata-version: 1.0.0
title: ADR 0008: Immutable message publication
description: Record the owner-approved mitigation for concurrent message-board writes.
document-type: governance-policy
repository: vc.Governance
language: Standard Technical English
updated: 2026-11-11
version: # VERSION
1.0.0
last_updated: 2026-11-14
---

# ADR 0008: Immutable message publication

## Status

Accepted record of GOV-OD18. The human owner approved this mitigation on
2026-11-11 with "OK. Implement this idea."

This supersedes ADR 0007's shared-board storage and sender-written queue rows.
It preserves long-running pollers, exact recipient addresses, PM work
assignment, and existing approval routes. It does not authorize sibling
repository implementation or claim a verified runtime.

## Context

Concurrent senders updating one Markdown board can overwrite one another.
Publishing a separate message file and a board row also creates a failure
window: a crash between writes leaves a message that board-only readers
cannot discover.

## Decision

1. Make published immutable message files the authoritative queue.
2. Publish each complete message from a uniquely named temporary file through
   a same-filesystem atomic rename that refuses to overwrite a destination.
   Readers ignore temporary files.
3. Poll published files by exact `To` address, independently of the board.
4. Give acknowledgements, responses, and resolutions their own immutable files
   and IDs, linked to the original message. Never modify published originals.
5. Make the Project Manager the sole board-summary writer. Rebuild that summary
   from published messages and linked outcome records. Serialize its updates
   and atomically replace the summary.
6. Keep executable helpers and verification in their separately assigned
   implementation scope. Record the [helper contract and failure cases](../process/local-agent-builder.md#helper-handoff-and-verification)
   here; do not claim that instructions supply atomicity or power-loss durability.

These are owner-selected coordination and implementation requirements, not a
source correction or a new Method rule. The Solution Architect owns technical
design, the Test Architect owns verification planning, and the Project Manager
assigns implementation under existing authority routes.

## Consequences

- Independent senders no longer need to edit shared board rows.
- Missing summary updates do not hide published messages from polling agents.
- Receipt and completion can be recorded without mutating another agent's file.
- This mitigates concurrent-write loss only when the helper and filesystem
  satisfy the publication contract. Retry effects, stale workers, PM recovery,
  and power-loss durability remain separate reliability work.
- No core artifact schema or lifecycle gate is changed.

## Alternatives

| Alternative | Disposition |
| --- | --- |
| Shared board with multiple writers | Replaced; no serialized update mechanism was established. |
| Lock the board for every sender | Not selected; independent message files avoid a shared sender-write path. |
| PM-only board as authoritative queue | Not selected; message discovery would depend on PM availability and indexing. |
| Treat Markdown or C# Channels as durable publication | Not selected; neither establishes the required filesystem publication guarantees by itself. |

## Related records

- [GOV-OD18](../governance/owner-decisions-2026-11-11.md): explicit owner decision.
- [ADR 0007](0007-local-message-queue-and-agent-polling.md): retained historical queue decision.
- [Local agent Builder workflow](../process/local-agent-builder.md): current publication contract.
- [Builder templates](../templates/builder/README.md): immutable records and PM-only summary.
- [Repository ownership](../implementation/repository-ownership.md): separate executable implementation scope.
