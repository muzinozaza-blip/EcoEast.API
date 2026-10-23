# EcoEast — integrated web app + API

The EcoEast frontend is hosted by the ASP.NET Core 8 API from `wwwroot/index.html`; open the root URL to use the website and `/swagger` (Development only) for API docs.

## Run
1. Install the .NET 8 SDK.
2. Update `ConnectionStrings:DefaultConnection` in `appsettings.json` for your SQL Server database.
3. Run `dotnet restore`, then `dotnet run`.
4. Open the root URL shown in the terminal.

## Demo login
All seeded demo users use password `EcoEast123!`: `resident@ecoeast.demo`, `manager@ecoeast.demo`, `worker@ecoeast.demo`, `admin@ecoeast.demo`.

## Important limitations
- The UI and API now ship as one project and sign-in, resident registration, admin account creation and account disabling call the API.
- Demo authentication accounts are currently held in server memory and reset when the API process restarts. Passwords are demo-only plain text and must not be used for real users. Before production, replace this with ASP.NET Core Identity, password hashing, secure sessions/JWT, server-side role authorization and persistent user tables.
- Service request, report, recycling and schedule API controllers use SQL Server via EF Core; configure and validate the database schema before using those endpoints. The UI's operational records remain sample data until their forms are connected to the database API.
