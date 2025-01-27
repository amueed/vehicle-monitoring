# Base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy the .csproj file and restore dependencies
COPY ["VehicleMonitoring.Api/VehicleMonitoring.Api.csproj", "VehicleMonitoring.Api/"]
RUN dotnet restore "VehicleMonitoring.Api/VehicleMonitoring.Api.csproj"

# Copy the rest of the source code
COPY . .
WORKDIR "/src/VehicleMonitoring.Api"

# Build the project
RUN dotnet build "VehicleMonitoring.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "VehicleMonitoring.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VehicleMonitoring.Api.dll"]
