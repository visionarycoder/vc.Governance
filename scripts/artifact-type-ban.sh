#!/usr/bin/env bash
# scripts/artifact-type-ban.sh
# Blocks .json, .yaml, .yml, .toml files outside allowed governance or artifact locations.

set -euo pipefail

CHANGED=$(git diff --cached --name-only --diff-filter=AM)

if [[ -z "$CHANGED" ]]; then
  exit 0
fi

for file in $CHANGED; do
  case "$file" in
    *.json|*.yaml|*.yml|*.toml)
      if [[ "$file" == docs/* ]] || [[ "$file" == */artifacts/* ]]; then
        continue
      fi
      echo "❌ Disallowed artefact type: $file"
      "$(git rev-parse --show-toplevel)/scripts/blocked-action-logger.sh" "$file" "Disallowed artefact type"
      exit 1
      ;;
  esac
done

exit 0
