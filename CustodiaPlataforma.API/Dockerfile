#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CustodiaPlataforma.API/CustodiaPlataforma.API.csproj", "CustodiaPlataforma.API/"]
COPY ["CustodiaPlataforma.Service/CustodiaPlataforma.Service.csproj", "CustodiaPlataforma.Service/"]
COPY ["CustodiaPlataforma.Infra/CustodiaPlataforma.Infra.csproj", "CustodiaPlataforma.Infra/"]
COPY ["CustodiaPlataforma.DTO/CustodiaPlataforma.DTO.csproj", "CustodiaPlataforma.DTO/"]
RUN dotnet restore "CustodiaPlataforma.API/CustodiaPlataforma.API.csproj"
COPY . .
WORKDIR "/src/CustodiaPlataforma.API"
RUN dotnet build "CustodiaPlataforma.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CustodiaPlataforma.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustodiaPlataforma.API.dll"]