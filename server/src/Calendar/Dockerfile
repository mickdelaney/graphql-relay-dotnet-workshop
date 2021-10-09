FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Calendar/Calendar.csproj", "Calendar/"]
RUN dotnet restore "src/Calendar/Calendar.csproj"
COPY . .
WORKDIR "/src/Calendar"
RUN dotnet build "Calendar.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Calendar.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Calendar.dll"]
