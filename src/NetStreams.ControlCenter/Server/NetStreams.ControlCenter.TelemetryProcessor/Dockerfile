#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["NetStreams.ControlCenter/NetStreams.ControlCenter.TelemetryProcessor.csproj", "NetStreams.ControlCenter/"]
RUN dotnet restore "NetStreams.ControlCenter/NetStreams.ControlCenter.TelemetryProcessor.csproj"
COPY . .
WORKDIR "/src/NetStreams.ControlCenter"
RUN dotnet build "NetStreams.ControlCenter.TelemetryProcessor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetStreams.ControlCenter.TelemetryProcessor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetStreams.ControlCenter.TelemetryProcessor.dll"]