# GUIDE

## Server

### GraphQL Server Template  

`` dotnet new -i HotChocolate.Templates.Server ``  
`` dotnet new graphql -n MyApi ``  

## Client

### Getting your GraphQL Schema for Relay  

`` https://www.npmjs.com/package/get-graphql-schema ``  
`` npm install -g get-graphql-schema ``  

`` cd client ``  
`` get-graphql-schema http://localhost:5702/graphql > schema/schema.graphql ``  
