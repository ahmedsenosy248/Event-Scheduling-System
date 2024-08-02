#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EventSchedulingSystem/EventSchedulingSystem.csproj", "EventSchedulingSystem/"]
COPY ["EventSchedulingSystem.Application/EventSchedulingSystem.Application.csproj", "EventSchedulingSystem.Application/"]
COPY ["EventSchedulingSystem.Domain/EventSchedulingSystem.Domain.csproj", "EventSchedulingSystem.Domain/"]
COPY ["EventSchedulingSystem.Infrastructure/EventSchedulingSystem.Infrastructure.csproj", "EventSchedulingSystem.Infrastructure/"]
RUN dotnet restore "./EventSchedulingSystem/EventSchedulingSystem.csproj"
COPY . .
WORKDIR "/src/EventSchedulingSystem"
RUN dotnet build "./EventSchedulingSystem.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EventSchedulingSystem.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventSchedulingSystem.dll"]

