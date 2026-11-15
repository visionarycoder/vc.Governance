#!/usr/bin/env bash
# enforce-governance.sh
# Exit with error if any .md file outside allowed governance paths is added/modified.
# Allowed paths:
#   - E:/dev/v/vc.Governance/**
#   - any path that contains "/artifacts/" (approved artifact locations)
# Usage: run from repository root before commit (e.g. as a pre‑commit hook).

set -euo pipefail

# Find staged .md files (git diff --cached)
CHANGED=$(git diff --cached --name-only --diff-filter=AM | grep -E '\\.md$' || true)

if [[ -z "$CHANGED" ]]; then
  exit 0
fi

for file in $CHANGED; do
  # Convert Windows style to POSIX for comparison
  POSIX=$(cygpath -u "$file" 2>/dev/null || echo "$file")
  if [[ "$POSIX" == *"/vc.Governance"* ]] || [[ "$POSIX" == *"/artifacts/"* ]]; then
    continue
  fi
  echo "❌ Disallowed markdown file: $file"
  echo "   Only files under vc.Governance or approved artifact locations may be .md."
  exit 1
done

exit 0
