# Manager Creation Rule

## Scope
All domain managers – **Analysis**, **Trading**, and **Research** – must be defined as a distinct *Contract* and *Service* pair.

## Implementation
- **Folder layout**:
  ```text
  src/component/manager/<Domain>/
    <Domain>.Contract/<Domain>.Contract.csproj
    <Domain>.Service/<Domain>.Service.csproj
  ```
- **Naming**:
  - Interface: `I<Domain>Manager` in `<Domain>.Contract`.
  - Service: `<Domain>Manager` in `<Domain>.Service`.
  - Namespace: `vc.Latimessis.Component.Manager.<Domain>.Service`.
- **Dependencies**:
  - Service projects must reference only their corresponding Contract project and domain‑specific dependencies.  No cross‑manager references.
- **Visibility**:
  - The public API exposed by the Service must be limited to the Manager contract; all platform‑specific DLL references (e.g., NinjaTrader) must be hidden inside the Service.

## Governance check
- CI must scan the solution and confirm that for each manager listed in the boundary‑map an `<Domain>.Contract` and `<Domain>.Service` exist.
- Status.md must contain a row for `M1 – Pass`, `M2 – Pass`, `M4 – Pass`.
- Code‑review checklist must include *"Verify Manager contracts exist"*.

## Rationale
This rule restores the original architectural intent, ensuring each manager is a separate, testable, and replaceable component.
