---
title: Enterprise Technology Requirements
address: design/architecture/enterprise-technology-requirements
type: design
owner: agent/sa
status: active
tags: [enterprise-technology-requirements, architecture, design]
aliases: [enterprise-technology-requirements]
version: 1.0.0
last_updated: 2026-11-27
---

# Enterprise Technology Requirements

## Approved technology stack
| Category | Recommended implementation | Version range |
|----------|---------------------------|---------------|
| .NET runtime | .NET 11 (LTS) | 11.0.x |
| Observability | OpenTelemetry SDK | 1.9.0 – 1.12.x |
| Tracing exporter | OTLP over HTTP | 0.14.0 – latest |
| Logging | Microsoft.Extensions.Logging (built‑in) | 7.0.x – latest |
| Message bus | Azure Service Bus (Azure.Messaging.ServiceBus) | 7.x |
| Secrets management | Azure Key Vault | 4.x |
| Configuration | Microsoft.Extensions.Configuration (JSON, env vars) | 7.0.x |
| Data storage | SQLite (single‑file) | 3.x |
| Containerisation | Docker (Linux containers) | 24.x |

## Governance process for updates
1. **Propose** a new technology or version bump via a pull‑request that updates this file.
2. **Create an ADR** describing the rationale, impact analysis, and migration plan. Place the ADR in `docs/adr/`.
3. **Review** – the Architecture Review Board must approve the ADR before merge.
4. **Merge** – once approved, the change is merged and the version range is updated.
5. **Enforcement** – CI runs `dotnet list package --include-transitive` and fails if any project references a package outside the approved ranges.

*This document is the single source of truth for the enterprise‑wide technology baseline.*
