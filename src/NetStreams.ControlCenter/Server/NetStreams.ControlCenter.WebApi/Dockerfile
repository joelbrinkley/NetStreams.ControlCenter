#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Server/NetStreams.ControlCenter.WebApi/NetStreams.ControlCenter.WebApi.csproj", "Server/NetStreams.ControlCenter.WebApi/"]
RUN dotnet restore "Server/NetStreams.ControlCenter.WebApi/NetStreams.ControlCenter.WebApi.csproj"
COPY . .
WORKDIR "/src/Server/NetStreams.ControlCenter.WebApi"
RUN dotnet build "NetStreams.ControlCenter.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetStreams.ControlCenter.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetStreams.ControlCenter.WebApi.dll"]