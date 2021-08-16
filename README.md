# GUIDE

## Server

### Database

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


### Migrations

``
dotnet ef migrations add MIGRATION_NAME --project src/AccountsApi/AccountsApi.csproj --context AccountsDbContext
dotnet ef database update --project src/AccountsApi/AccountsApi.csproj --context AccountsDbContext


dotnet ef migrations add MIGRATION_NAME --project src/ContentApi/ContentApi.csproj --context ContentDbContext
dotnet ef database update --project src/ContentApi/ContentApi.csproj --context ContentDbContext

``


### GraphQL Server Template  

`` dotnet new -i HotChocolate.Templates.Server ``  
`` dotnet new graphql -n MyApi ``  

## Client

### Getting your GraphQL Schema for Relay  

`` https://www.npmjs.com/package/get-graphql-schema ``  
`` npm install -g get-graphql-schema ``  

`` cd client ``  
`` get-graphql-schema http://localhost:5702/graphql > schema/schema.graphql ``  
