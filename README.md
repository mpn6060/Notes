
# Notes — ASP.NET Core 8 Notes App

This repository contains a small Notes application organized into separate projects following a simple clean-architecture split:

- `src/Notes.Domain` — domain entities and value objects
- `src/Notes.Application` — application services and DTOs
- `src/Notes.Infrastructure` — EF Core persistence (LocalDB / SQL Server)
- `src/Notes.Web` — ASP.NET Core MVC web UI

Root solution
---------------

A single solution file at the repository root, `Notes.sln`, now contains all projects. Open `Notes.sln` in Visual Studio or VS Code (with the C# extension) to load the whole application at once.

If you previously opened `src/Notes.Web/Notes.Web.sln`, note the nested solution was renamed to `src/Notes.Web/Notes.Web.sln.bak` to avoid confusion — the `.bak` file is a backup and can be restored if desired.

Quick start (developer)
-----------------------

From a developer command prompt or PowerShell in the repository root, build the solution:

```powershell
dotnet build Notes.sln -c Debug
```

To run the web project directly:

```powershell
dotnet run --project src\Notes.Web\Notes.Web.csproj
```

For more runtime details specific to the ASP.NET Core app (connection strings, LocalDB notes, etc.) see `src/Notes.Web/README_RUN.md`.



