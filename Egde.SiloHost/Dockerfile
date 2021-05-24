FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Egde.SiloHost/Egde.SiloHost.csproj", "Egde.SiloHost/"]
RUN dotnet restore "Egde.SiloHost/Egde.SiloHost.csproj"
COPY . .
WORKDIR "/src/Egde.SiloHost"
RUN dotnet build "Egde.SiloHost.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Egde.SiloHost.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Egde.SiloHost.dll"]
