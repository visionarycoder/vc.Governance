# Governance Tools Repository

This repository contains the command‑line tools used by the **vc.Governance** platform.  The tools are organized as separate .NET projects and are referenced from a single solution file (`GovernanceTools.slnx`).

---

## Repository layout

```
tools/
├─ governance-validator/      # "GovernanceValidator" console app
│   ├─ GovernanceValidator.csproj
│   └─ Program.cs
├─ link-checker/             # "LinkChecker" console app
│   ├─ LinkChecker.csproj
│   └─ Program.cs
├─ GovernanceTools.slnx      # Solution file that aggregates the two projects
└─ TOOLS.md                  # (this file)
```

Each subdirectory name matches the project name (kebab‑case) and contains the standard .NET project layout (`bin/`, `obj/`, `*.csproj`, `Program.cs`).

---

## Adding a new tool

1. **Create a sub‑directory** named in kebab‑case that reflects the tool’s purpose, e.g. `my‑awesome‑tool`.
2. **Initialize a .NET console project** inside that folder:
   ```bash
   cd my-awesome-tool
   dotnet new console -n MyAwesomeTool
   ```
   This creates `MyAwesomeTool.csproj` and a basic `Program.cs`.
3. **Rename the project file** to match the folder name (optional but recommended):
   ```bash
   mv MyAwesomeTool.csproj my-awesome-tool.csproj
   ```
4. **Add any NuGet packages** the tool needs, e.g. `dotnet add package YamlDotNet`.
5. **Add the project to the solution** so it is built with the others:
   ```bash
   cd ..   # back to the tools root
   dotnet slnx add my-awesome-tool/my-awesome-tool.csproj
   ```
   The command updates `GovernanceTools.slnx` with a new `<Project Path="my-awesome-tool/my-awesome-tool.csproj" />` entry.
6. **Commit the new folder** and the updated `GovernanceTools.slnx`.

---

## Building all tools

From the `tools` root run:
```bash
dotnet build GovernanceTools.slnx -c Release
```
All projects defined in the solution are compiled and their binaries appear under each project's `bin/Release/net8.0/` folder.

---

## Running a tool

Each tool is a self‑contained console application.  After a successful build you can invoke it directly:
```bash
./governance-validator/bin/Release/net8.0/GovernanceValidator
./link-checker/bin/Release/net8.0/LinkChecker
```
(Use the appropriate path syntax for your shell – the repository uses forward slashes for consistency.)

---

## Why the split‑by‑project layout?

* **Isolation** – each tool has its own dependencies and build output, preventing version clashes.
* **Extensibility** – new tools can be added without modifying existing code.
* **Solution‑wide tooling** – the single `.slnx` file lets CI pipelines build, test, and package all tools together.

---

## FAQ

*Q*: Do I need to rename the namespace inside the source files?
*A*: It is recommended but not required.  Follow the pattern used in the existing projects (`RootNamespace` matches the project name).

*Q*: How do I reference a tool from another project?
*A*: Add a project reference (`dotnet add <other>.csproj reference <tool>/my‑tool.csproj`) or invoke the compiled binary directly.

---

**Maintainer tip** – keep `GovernanceTools.slnx` under version control; it is the single source of truth for which tools belong to the repository.
