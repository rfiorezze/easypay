#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["com.easypay.be/com.easypay.be.api/com.easypay.be.api.csproj", "com.easypay.be/com.easypay.be.api/"]
COPY ["com.easypay.be/com.easypay.be.agents/com.easypay.be.agents.csproj", "com.easypay.be/com.easypay.be.agents/"]
COPY ["com.easypay.be/com.easypay.be.application/com.easypay.be.application.csproj", "com.easypay.be/com.easypay.be.application/"]
COPY ["com.easypay.be/com.easypay.be.domain/com.easypay.be.domain.csproj", "com.easypay.be/com.easypay.be.domain/"]
COPY ["com.easypay.be/com.easypay.be.infrastructure/com.easypay.be.infrastructure.csproj", "com.easypay.be/com.easypay.be.infrastructure/"]
RUN dotnet restore "com.easypay.be/com.easypay.be.api/com.easypay.be.api.csproj"
COPY . .
WORKDIR "/src/com.easypay.be/com.easypay.be.api"
RUN dotnet build "com.easypay.be.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "com.easypay.be.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "com.easypay.be.api.dll"]