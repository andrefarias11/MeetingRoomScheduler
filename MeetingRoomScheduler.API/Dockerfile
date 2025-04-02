# Usar a imagem oficial do .NET 8/9 SDK para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar arquivos do projeto e restaurar dependências
COPY MeetingRoomScheduler.sln ./
COPY MeetingRoomScheduler.API/MeetingRoomScheduler.API.csproj MeetingRoomScheduler.API/
COPY MeetingRoomScheduler.Application/MeetingRoomScheduler.Application.csproj MeetingRoomScheduler.Application/ 
COPY MeetingRoomScheduler.Infrastructure/MeetingRoomScheduler.Infrastructure.csproj MeetingRoomScheduler.Infrastructure/
COPY MeetingRoomScheduler.Domain/MeetingRoomScheduler.Domain.csproj MeetingRoomScheduler.Domain/
RUN dotnet restore

# Copiar o código restante e fazer o build
COPY . .
WORKDIR /app/MeetingRoomScheduler.API
RUN dotnet publish -c Release -o /out

# Criar a imagem final baseada no ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out .

# Expor a porta da API
EXPOSE 5000
EXPOSE 5001

# Comando de inicialização da API
ENTRYPOINT ["dotnet", "MeetingRoomScheduler.API.dll"]
