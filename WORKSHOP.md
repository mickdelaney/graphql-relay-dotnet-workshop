# Database

## 
```bash
dotnet tool update --global dotnet-ef
```

## Setup Schema & Auth

```sql

CREATE ROLE workshop WITH
    SUPERUSER
    CREATEDB
    CREATEROLE
    INHERIT
    LOGIN
    NOREPLICATION
    NOBYPASSRLS
    CONNECTION LIMIT UNLIMITED;

CREATE DATABASE workshop OWNER workshop;

```

## Migrations

```bash

dotnet ef migrations add MIGRATION_NAME --project src/AccountsApi/AccountsApi.csproj --context AccountsDbContext
dotnet ef database update --project src/AccountsApi/AccountsApi.csproj --context AccountsDbContext --connection "host=elevate.postgres.local;port=5705;database=workshop;username=workshop;password=workshop;keepalive=60;"

dotnet ef migrations add MIGRATION_NAME --project src/ContentApi/ContentApi.csproj --context ContentDbContext
dotnet ef database update --project src/ContentApi/ContentApi.csproj --context ContentDbContext --connection "host=elevate.postgres.local;port=5705;database=workshop;username=workshop;password=workshop;keepalive=60;"

```
