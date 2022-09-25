#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["com.easypay.paymentapi/com.easypay.paymentapi.api/com.easypay.paymentapi.api.csproj", "com.easypay.paymentapi/com.easypay.paymentapi.api/"]
COPY ["com.easypay.paymentapi/com.easypay.paymentapi.agents/com.easypay.paymentapi.agents.csproj", "com.easypay.paymentapi/com.easypay.paymentapi.agents/"]
COPY ["com.easypay.paymentapi/com.easypay.paymentapi.application/com.easypay.paymentapi.application.csproj", "com.easypay.paymentapi/com.easypay.paymentapi.application/"]
COPY ["com.easypay.paymentapi/com.easypay.paymentapi.domain/com.easypay.paymentapi.domain.csproj", "com.easypay.paymentapi/com.easypay.paymentapi.domain/"]
COPY ["com.easypay.paymentapi/com.easypay.paymentapi.infrastructure/com.easypay.paymentapi.infrastructure.csproj", "com.easypay.paymentapi/com.easypay.paymentapi.infrastructure/"]
RUN dotnet restore "com.easypay.paymentapi/com.easypay.paymentapi.api/com.easypay.paymentapi.api.csproj"
COPY . .
WORKDIR "/src/com.easypay.paymentapi/com.easypay.paymentapi.api"
RUN dotnet build "com.easypay.paymentapi.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "com.easypay.paymentapi.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "com.easypay.paymentapi.api.dll"]