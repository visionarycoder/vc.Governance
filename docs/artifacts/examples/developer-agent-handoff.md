---
metadata-version: 1.0.0
title: Worked example of a developer agent handoff
description: Show how a Work Assignment and accepted Detailed Design supply a component change prompt.
document-type: reference
repository: vc.Governance
language: Standard Technical English
updated: 2026-11-11
version: # VERSION
1.0.0
last_updated: 2026-11-14
---

# Worked example of a developer agent handoff

This fictional example follows one change to the existing `QuoteManager` component. Its `ListQuotesAsync` operation currently returns up to 20 quotes. The requested change lets a caller request a smaller limit while preserving the default and result ordering.

The excerpts show selected fields from records in `example` mode. They omit the common envelope and full revision references. Names and revisions are fictional. Design acceptance and assignment are assumptions for the illustration. Use the complete revision-bound references and current decision evidence for operational work. [Artifact contracts](../README.md)

## Detailed Design

In the example, the Application Architect prepares `EX-DD-QUOTE` at `example-r2`. The Solution Architect accepts that revision with Test Architect input. The system design `EX-SD-QUOTE` at `example-r1` keeps `QuoteManager` responsible for quote-list orchestration through its existing approved dependencies. The service requirement `EX-SRS-QUOTE` at `example-r2` defines the optional limit. [Detailed Design template](../../templates/artifacts/detailed-design.md)

| Payload field | Fictional content |
| --- | --- |
| `component_id` | `QuoteManager` |
| `system_design` | Reference to `EX-SD-QUOTE` at `example-r1` |
| `requirements` | Reference to `EX-SRS-QUOTE` at `example-r2` |
| `contracts` | `IQuoteManager.ListQuotesAsync(ListQuotesRequest request, CancellationToken cancellationToken)` retains its signature and return type. Its `inputs` specify one new optional nullable integer `ListQuotesRequest.MaxResults`, serialized as `maxResults`. An omitted or null value uses 20. Values from 1 through 20 limit the number of returned quotes. Values outside that range use the existing invalid-request failure. The `outputs` retain the response shape and ordering. |
| `internal_design` | The existing `ListQuotesHandler` validates the limit and applies it to the ordered result. The service continues to delegate to that handler. |
| `dependency_constraints` | Preserve existing component dependencies and approved proxy routes. |
| `testability` | Exercise a request with the field absent, a null value, a limit of 5, and out-of-range values. Verify the unchanged ordering and invalid-request failure. Check that the existing serialized request without the field still produces the default behavior. |

## Work Assignment

In the example, the Project Manager issues `EX-WA-QUOTE` at `example-r3` for the construction activity `EX-ACT-QUOTE-LIMIT`. The paths below are relative to the fictional consuming repository. Each entry identifies a single editable file. [Work Assignment template](../../templates/artifacts/work-assignment.md)

| Payload field | Fictional content |
| --- | --- |
| `activity_kind` and `authorized_phase` | `construction` |
| `assigned_by`, `assigned_worker` and `component_id` | `example-pm` assigns `example-developer` as Implementation Developer for `QuoteManager`. |
| `requirements`, `system_design` and `detailed_design` | References to `EX-SRS-QUOTE` at `example-r2`, `EX-SD-QUOTE` at `example-r1`, and `EX-DD-QUOTE` at `example-r2`, respectively. |
| `design_review_decisions` and `selected_sdp` | References to the fictional acceptance of `EX-DD-QUOTE` at `example-r2` and the accepted project plan `EX-SDP-QUOTE` at `example-r1`. |
| `constraints` | Implement only the reviewed `ListQuotesRequest.MaxResults` extension for `ListQuotesAsync`. Preserve its signature, default, ordering, failure behavior and existing dependency routes. |
| `permitted_outputs` | `src/QuoteManager/Contracts/ListQuotesRequest.cs`, `src/QuoteManager/Handlers/ListQuotesHandler.cs`, and `tests/QuoteManager.Tests/ListQuotesHandlerTests.cs` are the permitted edit paths. |
| `completion_criteria` | Run the assigned white-box tests and report the changed paths, results and any remaining compatibility verification in the Implementation Submission. |

## Filled-in developer prompt

> You are the Implementation Developer assigned to `QuoteManager` by `EX-WA-QUOTE` at `example-r3`. Resolve the assignment and check the current construction prerequisites. Use `EX-SD-QUOTE` at `example-r1` for component context and `EX-DD-QUOTE` at `example-r2` for implementation. The assignment binds the service requirement, design acceptance and accepted project plan.
>
> Add the approved optional nullable integer `MaxResults` to `ListQuotesRequest` using the serialized name `maxResults`. Apply the limit in `ListQuotesHandler`. An omitted or null field uses 20. Accept values from 1 through 20 and use the existing invalid-request failure for other values. Preserve `IQuoteManager.ListQuotesAsync`, result ordering and existing dependency routes.
>
> Edit only `src/QuoteManager/Contracts/ListQuotesRequest.cs`, `src/QuoteManager/Handlers/ListQuotesHandler.cs`, and `tests/QuoteManager.Tests/ListQuotesHandlerTests.cs`. Inspect existing callers and serialization to assess compatibility. If the change requires a design refinement or another edit path, hold the affected work and route the design issue to the Application Architect or the scope issue to the Project Manager.
>
> Construct the implementation and white-box tests together. Cover absent and null limits, a limit of 5, out-of-range limits and preserved ordering. Submit changed paths, test results and any remaining compatibility checks for independent review.

The DTO edit is in scope because the accepted operation describes the extension and the assignment explicitly permits its file. If the same assignment omitted `ListQuotesRequest.cs`, the design would still describe the change, but the developer would need an updated assignment before editing that file. [Reusable developer agent prompt](../../templates/developer-agent-prompt.md)
