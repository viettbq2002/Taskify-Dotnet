#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Taskify.WebAPI/Taskify.WebAPI.csproj", "Taskify.WebAPI/"]
COPY ["Taskify.Application/Taskify.Application.csproj", "Taskify.Application/"]
COPY ["Taskify.Persistence/Taskify.Persistence.csproj", "Taskify.Persistence/"]
COPY ["Taskify.Domain/Taskify.Domain.csproj", "Taskify.Domain/"]
RUN dotnet restore "./Taskify.WebAPI/Taskify.WebAPI.csproj"
COPY . .
WORKDIR "/src/Taskify.WebAPI"
RUN dotnet build "./Taskify.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Taskify.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Taskify.WebAPI.dll"]