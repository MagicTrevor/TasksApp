FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
RUN apk add --no-cache icu-libs
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as build
WORKDIR /build
COPY ["TasksAppApp.sln", "./"]
COPY ["src/TasksApp.Api/TasksApp.Api.csproj", "./src/TasksApp.Api/"]
COPY ["src/TasksApp.Domain/TasksApp.Domain.csproj", "./src/TasksApp.Domain/"]
COPY ["src/TasksApp.Data/TasksApp.Data.csproj", "./src/TasksApp.Data/"]
RUN dotnet restore
COPY . .
RUN dotnet build -c Release

FROM build AS publish
WORKDIR /build/src/TasksApp.Api
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT [ "dotnet", "TasksApp.Api.dll" ]