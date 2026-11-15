#!/usr/bin/env bash
# check-governance-label.sh – used by GitHub Actions
# Fails the workflow if the PR does not have the required label.
# The GitHub Actions workflow already calls this via the step, but this
# script isolates the logic for reuse locally or in other CI systems.

set -euo pipefail

# Expect environment variable GITHUB_EVENT_PATH (GitHub provides this)
if [[ -z "${GITHUB_EVENT_PATH-}" ]]; then
  echo "GITHUB_EVENT_PATH not set – cannot inspect PR labels."
  exit 1
fi

LABELS=$(jq -r '.pull_request.labels[].name' "$GITHUB_EVENT_PATH" || true)
if echo "$LABELS" | grep -q "governance-edit"; then
  echo "✅ Governance edit label present."
  exit 0
else
  echo "❌ Missing required label 'governance-edit'."
  exit 1
fi
