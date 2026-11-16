---
title: Observability Standards
address: standard/implementation/observability
type: implementation-standard
owner: agent/sa
status: active
tags: [implementation, observability-standards, standards]
aliases: [observability-standards]
version: 1.0.0
last_updated: 2026-11-14
---

# Observability Standards

## Rules

- Emit structured logs with stable event names.
- Propagate correlation and trace context across approved boundaries.
- Define service-level health signals for hosted workloads.
- Distinguish operational events, audit events, and diagnostic detail.
- Use metrics for rates, latency, saturation, failures, and key business outcomes when required.
- Keep telemetry volumes bounded.
- Avoid sensitive data by default.
- Make failures diagnosable without attaching a debugger to production.
