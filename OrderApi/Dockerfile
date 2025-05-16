FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY OrderApi.csproj ./OrderApi/
RUN dotnet restore ./OrderApi/OrderApi.csproj
COPY . ./OrderApi/
WORKDIR /src/OrderApi
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "OrderApi.dll"]