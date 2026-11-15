#!/usr/bin/env bash
# scripts/log-critique.sh – called by the post‑commit hook.
# Records timestamp, author, commit SHA and file SHA for any critique.md.

set -euo pipefail

REPO_ROOT=$(git rev-parse --show-toplevel)
LOG="$REPO_ROOT/audit/critique-log.jsonl"
mkdir -p "$(dirname "$LOG")"

FILE="$1"
if [[ -z "$FILE" ]] || [[ "$FILE" != *"critique.md" ]]; then
  echo "Usage: $0 <critique.md>"
  exit 1
fi

TIMESTAMP=$(date -u +"%Y-%m-%dT%H:%M:%SZ")
AUTHOR=$(git log -1 --pretty=format:%an)
COMMIT=$(git rev-parse HEAD)
SHA=$(git hash-object "$FILE")

echo "{\"timestamp\": \"$TIMESTAMP\", \"author\": \"$AUTHOR\", \"commit\": \"$COMMIT\", \"file\": \"$FILE\", \"sha\": \"$SHA\"}" >> "$LOG"

exit 0
