FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /
COPY ["Microservice.Infrastructure/Microservice.Infrastructure.csproj", "Microservice.Infrastructure/"]
COPY ["Microservice.API/Microservice.Api.csproj", "Microservice.Api/"]
RUN dotnet restore "Microservice.Infrastructure/Microservice.Infrastructure.csproj"
RUN dotnet restore "Microservice.Api/Microservice.Api.csproj"

COPY . .
WORKDIR "/Microservice.Infrastructure"
RUN dotnet build "Microservice.Infrastructure.csproj" -c Release -o /app/build
WORKDIR "/Microservice.Api"
RUN dotnet build "Microservice.Api.csproj" -c Release -o /app/build


FROM build AS publish
WORKDIR "/Microservice.Infrastructure"
RUN dotnet publish "Microservice.Infrastructure.csproj" -c Release -o /app/publish
WORKDIR "/Microservice.Api"
RUN dotnet publish "Microservice.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservice.Api.dll"]