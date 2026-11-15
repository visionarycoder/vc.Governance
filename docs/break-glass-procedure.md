# Break‑Glass Procedure for Governance Edits

When an urgent change to governance artefacts is required and the CI pipeline blocks the PR (e.g., missing `governance-edit` label), the CEO may invoke the break‑glass process:

1. **Create a PR** with the required changes.
2. **Add the label `break-glass`** to the PR.
3. The `governance‑edit‑guard` skill treats this label as an explicit override and allows the merge.
4. All break‑glass actions are recorded in `audit/break‑glass.log` (automatically by the CI step).
5. After the emergency change, a retrospective issue is opened (via the quarterly guard‑review workflow) to review why the break‑glass was needed.

Only the CEO (or a user with the `admin` role) may add the `break-glass` label.
