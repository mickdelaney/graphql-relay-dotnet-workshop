dotnet ef database update --project src/AccountsApi/AccountsApi.csproj --context AccountsDbContext --connection "host=localhost;port=5705;database=workshop;username=workshop;password=workshop;keepalive=60;"

dotnet ef database update --project src/ContentApi/ContentApi.csproj --context ContentDbContext --connection "host=localhost;port=5705;database=workshop;username=workshop;password=workshop;keepalive=60;"