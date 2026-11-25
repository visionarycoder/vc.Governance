---
title: CSharp Coding Standard
address: standard/implementation/csharp
type: implementation-standard
owner: agent/sa
status: active
tags: [csharp-coding-standard, implementation, standards]
aliases: [csharp-coding-standard]
version: 1.0.0
last_updated: 2026-11-14
---

# CSharp Coding Standard

## Language rules

- Use the project-approved C# language version.
- Prefer clear, direct code over clever compression.
- Use modern language features when they improve correctness or clarity and are supported by all targets.
- Enable nullable reference types for new projects unless a documented compatibility constraint prevents it.
- Prefer immutable state where practical.
- Use explicit access modifiers.
- Use language keywords such as `string` and `int` for built-in types.
- Use `var` only when the type is evident from the expression.
- Catch only exceptions that the current layer can handle meaningfully.
- Use analyzers and `.editorconfig` to enforce agreed formatting and diagnostics.

## Naming

- Names must describe business or mechanical behavior.
- Do not use underscore prefixes for identifiers.
- Use PascalCase for types, members, and constants.
- Use camelCase for parameters and local variables.
- Suffix asynchronous methods with `Async` unless the framework contract establishes another convention.
- Avoid abbreviations unless the term is defined in the local ontology.

## File organization

- Prefer one primary type per file.
- Keep files focused and navigable.
- Keep generated code clearly identified and out of manual-edit paths.
