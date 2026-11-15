---
metadata-version: 1.0.0
title: Roles and decisions
description: Assign design, business, project, review, and escalation responsibilities.
document-type: governance-policy
repository: vc.Governance
language: Standard Technical English
updated: 2026-11-11
version: # VERSION
1.0.0
last_updated: 2026-11-14
---

# Roles and decisions

## Accountability

The human owner defines the organization and reserves authority over the governing framework. The Method supplies the design responsibilities. Application-suite leadership is a core team, not a committee that divides or votes away accountability for architecture.

RS Chapter 7, pp. 147-150 and 194 requires one accountable architect, supported by a project manager and product manager. Application Architects implement the delegated detailed-design arrangement in Chapter 14, pp. 376-377. The owner's title Product Owner maps to the source's product-manager function.

Book source: [Righting Software](https://www.amazon.com/dp/0136524036). See [system and project design](../process/system-and-project-design.md) for the source-derived activities assigned to these roles.

| Role | Accountable work | Boundary |
| --- | --- | --- |
| Human owner | Governing framework and delegation of authority | Sole owner of amendments to the governing framework; has adopted Appendix C |
| CEO / Visionary | Suite direction, strategic priorities, and unresolved leadership conflicts | Decides within the governing framework; establishes implementation boundaries with the Solution Architect |
| Solution Architect | System design, technology choices, technical requirements, and project design | Single accountable owner of the whole system design; works with Product Owner on system design and Project Manager on project design; reviews delegated detailed designs |
| Product Owner | Business requirements, customer representation, priorities, and business acceptance | Resolves customer requirement conflicts; does not prescribe unauthorized architecture or assign developer work |
| Project Manager | Execution of the selected project design, assignments, scheduling, tracking, status, and organizational coordination | Assigns actual workers and requests status; does not replace the architect as project designer |
| Application Architect | Detailed component design, contracts, developer approach review, and technical code review | Works within Solution Architect boundaries; consults the Solution Architect for changes to those boundaries |
| Test Architect | Design of testing for the system and detailed designs, test requirements, and direction of test development | Cannot redefine business requirements, component contracts, architecture, or higher-level standards to make tests pass |
| QA | Defect prevention, process quality, standards, procedures, root-cause analysis, and process metrics | Reports to the Solution Architect by default; uses the human-owner escalation route when a finding implicates the SA or the SA does not provide a required response |
| Implementation Developer | Construction of an assigned component and its white-box test client | Has implementation discretion only within approved requirements, component boundaries, contracts, and detailed design |
| Test Developer | Implementation of the Test Architect's requirements, test harnesses, and test automation | Cannot weaken test requirements or acceptance expectations to fit observed implementation behavior |
| Test Agent | Execution of assigned verification and independent critique in code review | Reports defects and evidence; does not approve changes to higher-level requirements or designs |

Test Developer and Test Agent describe work responsibilities; whether separate worker instances perform them is an execution decision. QA, test engineering, and test execution remain distinct functions. RS pp. 207-209 and 380-382 distinguishes them; the owner's Test Architect and QA reporting arrangement is an organizational assignment.

For a finding that implicates the Solution Architect, or when the SA does not
provide a required response, QA may go directly to the human owner in
human-owner capacity. If the finding implicates the human owner / CEO, QA also
sends it directly to the owner in human-owner capacity. The owner appoints a
competent independent reviewer and decides the response; the owner cannot
review their own conduct. When no qualified reviewer is available for an
owner-implicated finding, hold affected work and record the finding as
unresolved. See [GOV-OD13–GOV-OD14](owner-decisions-2026-11-11.md).

The CEO and human owner are the same human actor under the owner's
[GOV-OD11 decision](owner-decisions-2026-11-11.md). They exercise distinct
authority capacities; the CEO is not an agent. Escalations reach this human,
and records identify the capacity authorizing the decision. This identity
overlap does not create independent critique or change any role's authority.

## Leadership collaboration

The triumvirate is Solution Architect, Product Owner, and Project Manager. All three remain involved throughout delivery. The Solution Architect owns system and project design, while receiving the necessary business and execution input. The Project Manager manages delivery against the resulting plan. This preserves RS pp. 149-150 and 194.

The CEO and Solution Architect establish the suite's implementation boundaries before implementation assignments. No language, runtime, persistence technology, transport, hosting platform, or framework is preselected here. Technology serves the architecture and project needs. It does not define the decomposition. See RS pp. 59 and 142-143.

Application Architects do not partition ownership of the system architecture. They undertake delegated detailed design, with Solution Architect review before handoff. A single accountable architect retains the whole-system view and the interactions between components. See RS pp. 148-149 and 376-377.

Supporting architects, apprentices, reviewers, and specialists do not create competing ownership of the system design. The examples use a senior architect with an apprentice (pp. 95 and 335), and p. 369 describes bounded specialist help at the front end. The staffing guideline is not a ban on architectural assistance.

## Decision routing

| Discovery or proposed change | First responsible decider | Additional involvement |
| --- | --- | --- |
| Implementation choice fully inside the approved detailed design | Assigned developer | Normal review still applies |
| Refinement to a detailed design or service contract | Application Architect who owns it | Preserve the Solution Architect's design review before handoff; escalate changes to higher-level bounds rather than transferring their ownership |
| Change to component boundaries, architectural interactions, or technology baseline | Solution Architect | CEO and leadership when established suite bounds or commitments are affected |
| Clarification or change to required business behavior | Product Owner | Solution Architect assesses design implications; Project Manager assesses execution implications |
| Change to test design, harness requirements, or test expectations | Test Architect | Application Architect or Solution Architect if the issue reveals a design or requirements change |
| Schedule, resource, dependency, or cost consequences | Project Manager and Solution Architect | Architect redesigns the project; management chooses changed commitments |
| Process-quality finding | QA, reporting to Solution Architect | Responsible role for the affected design, process, or standard |
| Change to the governing framework | Human owner | Leadership supplies rationale and source analysis |

The owner requires any detailed-design change to be escalated. Chapter 14, p. 376 likewise requires the construction worker to consult the service's designer about even a trivial refinement. The developer proposes a change; it cannot authorize that change by implementing it first.

## Conflict resolution

The owner requires at most three discussion rounds before an unresolved leadership conflict goes to the CEO. Each round should identify the disputed decision, applicable source constraint, proposed options, and remaining disagreement. The round count is an organizational rule, not a claim about Appendix C.

Role-level disagreements first reach the appropriate decision owner. Cross-domain conflicts reach the leadership trio. If the trio cannot resolve the conflict within three rounds, it escalates to the CEO. Escalation is not permission to violate the standard, self-approve a departure, or proceed with the disputed change.

The owner has defined a completed round: all three leadership members record positions on the same dispute, followed by a summary of the remaining disagreement. After three completed unresolved rounds, escalate to the CEO. The CEO is the same human actor as the human owner, so escalation reaches that person; use the authority capacity assigned to the disputed decision. The [decision matrix](decision-and-approval-matrix.md) and [conflict record template](../templates/artifacts/conflict-record.md) define the mechanics. Failed-review retries are not discussion rounds.

## Work assignment and review

Only the Project Manager assigns work activities or asks developers for project status, following RS p. 149. Architect mentoring, technical questions, design reviews, and test feedback remain part of the work. They do not create a second assignment channel.

For local Builder coordination, the Project Manager maintains the message board,
creates and rehydrates agents, and prompts agents to check the board. Agents may
message one another directly using stable project-scoped addresses. A message
does not assign or transfer work. If it requires work from another agent, the
Project Manager records the work and issues the applicable assignment. These
conventions are recorded in [GOV-OD16](owner-decisions-2026-11-11.md) and
described in the [local agent Builder workflow](../process/local-agent-builder.md).
The Solution Architect, Product Owner, and Project Manager are long-running
agents that poll the queue for messages addressed to their exact agent IDs.
Requests for a new work item go to the Project Manager's address and identify
the requested agent role, as recorded in [GOV-OD17](owner-decisions-2026-11-11.md).
Under [GOV-OD18](owner-decisions-2026-11-11.md), agents poll immutable published
message files, not just board rows. Only the Project Manager writes the
rebuildable board summary. Acknowledgements and responses are separate linked
message files; no recipient edits the original.

The leading architect approves technical work. The Application Architect is a critic in code review, and a Test Agent is an additional independent critic, as directed by the owner. The Product Owner retains business acceptance; the Project Manager tracks completion against phase exits and the selected project design.

Implementation and Test Developers cannot approve their own deliverables or change the source of truth against which they are assessed. Application/Test Architects may revise agent instructions within supplied bounds; they cannot change upstream guidelines. The Solution Architect obtains CEO approval for its own decisions. Preserve independent critique and required detailed-design review; see the [owner decisions](owner-decisions-2026-11-07.md). The technical enforcement of these rights is addressed separately in [enforcement boundaries](../implementation/enforcement-boundaries.md).

The Solution Architect includes all coding and noncoding quality activities in project design. Test engineering remains required work, even when an example explores the consequences of removing that resource. The Test Architect and Test Developers fulfill the assigned test-engineering responsibilities; neither a developer's unit tests nor a Test Agent's review alone replaces the system test plan, harness, regression testing, or real-service integration (pp. 25-26, 208, 272 and 380-382).

For agent workers, use [token based costing](../process/token-costing.md). Token budgets are constraints on resources, not approval to remove required design, review, integration, or testing work.

## Artifact-level authority

Use the [decision and approval matrix](decision-and-approval-matrix.md) and [artifact contracts](../artifacts/README.md) for exact authorship, review, and sign-off routes. The Test Architect approves service/system test plans and verification reports after required review. The Solution Architect approves technical integration acceptance. Before CEO acceptance of an SDP, the human owner approves explicit project-specific commitment limits. The CEO accepts only within those limits; missing or ambiguous limits block acceptance. Every guideline departure requires human-owner approval; directives remain non-waivable.
