#!/usr/bin/env bash
# scripts/enforce-naming.sh
# Enforces <type>-<component>.md naming for files under vc.Governance.
# Run manually or as a pre‑commit check.

set -euo pipefail

REPO_ROOT=$(git rev-parse --show-toplevel)

# Find markdown files under the governance tree
FILES=$(git ls-files "*.md" | grep "^docs/" || true)

if [[ -z "$FILES" ]]; then
  exit 0
fi

REGEX='^[a-z]+-[a-z0-9]+\.md$'

for f in $FILES; do
  base=$(basename "$f")
  if ! [[ $base =~ $REGEX ]]; then
    echo "❌ Naming violation: $f (expected pattern <type>-<component>.md)"
    exit 1
  fi
done

exit 0
