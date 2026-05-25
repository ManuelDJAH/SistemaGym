# ── Build stage ──────────────────────────────────────────────
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar archivos de proyecto para restaurar dependencias
COPY ["CapaWeb/CapaWeb.csproj",           "CapaWeb/"]
COPY ["CapaDatos/CapaDatos.csproj",       "CapaDatos/"]
COPY ["ClaseNegocio/ClaseNegocio.csproj", "ClaseNegocio/"]

RUN dotnet restore "CapaWeb/CapaWeb.csproj"

# Copiar solo las carpetas necesarias (excluir WinForms)
COPY CapaWeb/       CapaWeb/
COPY CapaDatos/     CapaDatos/
COPY ClaseNegocio/  ClaseNegocio/

# Publicar en modo Release
WORKDIR "/src/CapaWeb"
RUN dotnet publish "CapaWeb.csproj" -c Release -o /app/publish

# ── Runtime stage ─────────────────────────────────────────────
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

# Railway asigna el puerto via variable de entorno PORT
ENV ASPNETCORE_URLS=http://+:${PORT:-8080}
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "CapaWeb.dll"]

# ── Runtime stage ─────────────────────────────────────────────
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# ✅ Puerto fijo, Railway lo detecta solo
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production
ENTRYPOINT ["dotnet", "CapaWeb.dll"]
