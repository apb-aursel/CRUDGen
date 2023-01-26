#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
RUN dotnet dev-certs https
WORKDIR /src
COPY ["Api/CRUDGen.csproj", "Api/"]
RUN dotnet restore "Api/CRUDGen.csproj"
COPY . .
WORKDIR "/src/Api"
RUN dotnet build "CRUDGen.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CRUDGen.csproj" -c Release -o /app/publish /p:UseAppHost=false

HEALTHCHECK --interval=10s --timeout=3s --start-period=10s --retries=10 \
  CMD /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $${SA_PASSWORD} -Q "SELECT 1" -b -o /dev/null

FROM base AS final
WORKDIR /app
COPY --from=publish /root/.dotnet/corefx/cryptography/x509stores/my/* /root/.dotnet/corefx/cryptography/x509stores/my/
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CRUDGen.dll"]