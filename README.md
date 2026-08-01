# Employee Management Backend

ASP.NET Core Web API backend for the Employee Management application.

## What was built

- Organization CRUD
- EF Core Code First
- SQL Server in Docker
- Fluent API configuration
- Service layer
- Repository-free layered architecture
- REST endpoints for Angular integration

## Tech Stack

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Docker
- C#

## How the database was set up

SQL Server was run using Docker:

```bash
docker pull mcr.microsoft.com/mssql/server:2022-latest

docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=YourStrong@Pass123" -p 1433:1433 --name sqlserver2022 -d mcr.microsoft.com/mssql/server:2022-latest
