FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Egde.SiloClient/Egde.SiloClient.csproj", "Egde.SiloClient/"]
RUN dotnet restore "Egde.SiloClient/Egde.SiloClient.csproj"
COPY . .
WORKDIR "/src/Egde.SiloClient"
RUN dotnet build "Egde.SiloClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Egde.SiloClient.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Egde.SiloClient.dll"]
