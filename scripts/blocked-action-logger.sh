#!/usr/bin/env bash
# scripts/blocked-action-logger.sh
# Called by guard scripts when they reject a work‑item.
# Appends a JSON line to logs/blocked-actions.log

set -euo pipefail

REPO_ROOT=$(git rev-parse --show-toplevel)
LOG="$REPO_ROOT/logs/blocked-actions.log"
mkdir -p "$(dirname "$LOG")"

TIMESTAMP=$(date -u +"%Y-%m-%dT%H:%M:%SZ")
WORK_ITEM="$1"
REASON="$2"
USER="${GIT_AUTHOR_NAME:-unknown}"

echo "{\"timestamp\": \"$TIMESTAMP\", \"user\": \"$USER\", \"work_item\": \"$WORK_ITEM\", \"reason\": \"$REASON\"}" >> "$LOG"

exit 0
