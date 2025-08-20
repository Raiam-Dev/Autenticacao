# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copia todos os arquivos do projeto e restaura
COPY *.csproj ./
COPY . ./
RUN dotnet restore

# Build da aplicação
RUN dotnet publish -c Release -o out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copia o resultado do build
COPY --from=build /app/out ./

# Porta que a API vai expor
EXPOSE 80

# Comando de entrada
ENTRYPOINT ["dotnet", "RNovaTech.dll"]
