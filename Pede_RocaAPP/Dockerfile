# Estágio 1: Base
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:8000;
ENV ASPNETCORE_ENVIRONMENT=Development

# Estágio 2: Build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia apenas os arquivos .csproj para o cache de dependências
COPY ["Pede_RocaAPP.API/Pede_RocaAPP.API.csproj", "Pede_RocaAPP.API/"]
COPY ["Pede_RocaAPP.Infra.IoC/Pede_RocaAPP.Infra.IoC.csproj", "Pede_RocaAPP.Infra.IoC/"]
COPY ["Pede_RocaAPP.Application/Pede_RocaAPP.Application.csproj", "Pede_RocaAPP.Application/"]
COPY ["Pede_RocaAPP.Domain/Pede_RocaAPP.Domain.csproj", "Pede_RocaAPP.Domain/"]
COPY ["Pede_RocaAPP.Infra.Data/Pede_RocaAPP.Infra.Data.csproj", "Pede_RocaAPP.Infra.Data/"]

# Restaura as dependências
RUN dotnet restore "Pede_RocaAPP.API/Pede_RocaAPP.API.csproj"

# Copia o restante dos arquivos
COPY . .

# Define o diretório de trabalho e compila
WORKDIR "/src/Pede_RocaAPP.API"
RUN dotnet build "Pede_RocaAPP.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Estágio 3: Publish
FROM build AS publish
RUN dotnet publish "Pede_RocaAPP.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Estágio 4: Final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# Você pode querer adicionar um comando para limpar arquivos desnecessários aqui, se houver
ENTRYPOINT ["dotnet", "Pede_RocaAPP.API.dll"]
