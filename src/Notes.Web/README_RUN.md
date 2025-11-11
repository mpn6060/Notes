# Running the NotesApp (local dev)

Requirements:
- .NET 8 SDK
- SQL Server LocalDB (Windows) or a SQL Server instance (update connection string in appsettings.json)

Steps:
1. Open a terminal in `src/Notes.Web`
2. Restore packages:
   dotnet restore
3. Create database + migrations (first time):
   dotnet tool install --global dotnet-ef --version 8.0.0
   dotnet ef migrations add InitialCreate --project ../Notes.Infrastructure --startup-project . --output-dir ../Notes.Infrastructure/Migrations
   dotnet ef database update --project ../Notes.Infrastructure --startup-project .
4. Run:
   dotnet run

Notes:
- The project is configured to use ASP.NET Core Identity; to get the Identity UI, the package `Microsoft.AspNetCore.Identity.UI` can be added and Identity pages scaffolded, or run the app and navigate to /Identity/Account/Login to have default endpoints.
