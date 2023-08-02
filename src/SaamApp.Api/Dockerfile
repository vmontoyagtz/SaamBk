#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
# From solution root:
# docker build -t front-desk --progress=plain --no-cache -f .\SaamApp\src\SaamApp.Api\Dockerfile .
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
FROM mcr.microsoft.com/dotnet/sdk:5.0.201-buster-slim AS build
WORKDIR /app
# run this from repository root
COPY ./ ./ 
#RUN ls -lha .
RUN echo 'Building SaamApp container'
WORKDIR /app/SaamApp/src/SaamApp.Api
#RUN ls -lha .
RUN dotnet restore
RUN dotnet build "SaamApp.Api.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "SaamApp.Api.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SaamApp.Api.dll"]
