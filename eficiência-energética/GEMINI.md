# Project Context: eficiência-energética

## Overview
This project is an ASP.NET Core Web API application focused on **Energy Efficiency and Sustainability**. The goal is to develop a robust backend solution for monitoring and optimizing energy consumption, featuring automated alerts and IoT integration potential.

The project targets **.NET 10.0** and utilizes **Entity Framework Core** with **SQL Server**.

## Project Structure
- **Root:** Contains the project file (`.csproj`), entry point (`Program.cs`), and configuration (`appsettings.json`).
- **Controllers:** Contains API controllers (currently `WeatherForecastController.cs`).
- **Models:** Domain models (currently `WeatherForecast.cs`).
- **Properties:** Launch settings for development.

## Technical Requirements & Goals
Based on `O que fazer.txt`:
1.  **Theme:** Energy efficiency, monitoring, optimization, and IoT integration.
2.  **Endpoints:** At least 4 RESTful endpoints implementing complex business logic (beyond simple CRUD).
3.  **Architecture:**
    *   Strict adherence to **MVVM** (Model-View-ViewModel) pattern (interpreted as strict separation of Domain Models and DTOs/ViewModels).
    *   Pagination for list endpoints.
    *   Authentication and Authorization for critical endpoints.
4.  **Database:** SQL Server using Entity Framework Core with Migrations.
5.  **Testing:** xUnit tests required for controllers (at least validating 200 OK status).
6.  **Quality:** Advanced validation, exception handling, and security best practices.

## Key Files
- `eficiência-energética.csproj`: Defines dependencies (`Microsoft.EntityFrameworkCore.SqlServer`, `Microsoft.AspNetCore.OpenApi`) and target framework (`net10.0`).
- `Program.cs`: Application entry point and service configuration.
- `appsettings.json`: Configuration, including the `DefaultConnection` string for SQL Server LocalDB.
- `O que fazer.txt`: Detailed project requirements and instructions.

## Development & Usage

### Prerequisites
- .NET 10.0 SDK (or appropriate preview/RC version).
- SQL Server (LocalDB or compatible instance).

### Build & Run
```bash
# Restore dependencies
dotnet restore

# Build the project
dotnet build

# Run the project
dotnet run
```

### Database Migrations
```bash
# Add a new migration
dotnet ef migrations add <MigrationName>

# Update the database
dotnet ef database update
```

### Testing
```bash
# Run tests (xUnit)
# Note: Test project/files are currently missing and need to be created.
dotnet test
```

## Current Status
The project is currently in the initial scaffolding phase. The default "WeatherForecast" API is present. Implementation of the Energy Efficiency domain, database context, and specific endpoints has not yet begun.
