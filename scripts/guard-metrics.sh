#!/usr/bin/env bash
# scripts/guard-metrics.sh
# Simple Prometheus‑style metrics exporter for guard scripts.
# Writes a file `metrics/guard.prom` that can be scraped.

set -euo pipefail

METRICS_DIR="$(git rev-parse --show-toplevel)/metrics"
mkdir -p "$METRICS_DIR"
METRICS_FILE="$METRICS_DIR/guard.prom"

# Reset file
: > "$METRICS_FILE"

# Count total guard executions (we increment each time this script runs)
if [[ -f "$METRICS_DIR/guard_counter.txt" ]]; then
  COUNTER=$(cat "$METRICS_DIR/guard_counter.txt")
else
  COUNTER=0
fi
COUNTER=$((COUNTER+1))
echo "$COUNTER" > "$METRICS_DIR/guard_counter.txt"

echo "# HELP guard_executions_total Number of guard script executions" >> "$METRICS_FILE"
echo "# TYPE guard_executions_total counter" >> "$METRICS_FILE"
echo "guard_executions_total $COUNTER" >> "$METRICS_FILE"

# Record last execution timestamp
NOW=$(date -u +%s)
echo "guard_last_timestamp_seconds $NOW" >> "$METRICS_FILE"

exit 0
