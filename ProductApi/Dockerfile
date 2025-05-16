FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ProductApi.csproj ./ProductApi/
RUN dotnet restore ./ProductApi/ProductApi.csproj
COPY . ./ProductApi/
WORKDIR /src/ProductApi
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ProductApi.dll"]