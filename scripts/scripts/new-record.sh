#!/usr/bin/env bash
# Simple wrapper to create a new markdown record from a template.
# Usage: new-record --template <folder> --title "Your Title"

set -e
TEMPLATE_DIR="$(dirname "$0")/../templates"
while [[ $# -gt 0 ]]; do
  case $1 in
    --template) TEMPLATE="$2"; shift 2;;
    --title) TITLE="$2"; shift 2;;
    *) echo "Unknown argument $1"; exit 1;;
  esac
done
if [[ -z "$TEMPLATE" || -z "$TITLE" ]]; then
  echo "Both --template and --title are required"
  exit 1
fi
TARGET_DIR="$(pwd)"
FILENAME=$(echo "$TITLE" | tr '[:upper:]' '[:lower:]' | tr -cd '[:alnum:]-' ).md
cp "$TEMPLATE_DIR/$TEMPLATE/template.md" "$TARGET_DIR/$FILENAME"
sed -i "s/{{title}}/$TITLE/g" "$TARGET_DIR/$FILENAME"
# Open in default editor (respect $EDITOR)
${EDITOR:-nano} "$TARGET_DIR/$FILENAME"
