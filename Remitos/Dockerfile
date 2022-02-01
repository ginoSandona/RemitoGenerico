FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Remitos/Remitos.csproj", "Remitos/"]
RUN dotnet restore "Remitos/Remitos.csproj"
COPY . .
WORKDIR "/src/Remitos"
RUN dotnet build "Remitos.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Remitos.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Remitos.dll"]
