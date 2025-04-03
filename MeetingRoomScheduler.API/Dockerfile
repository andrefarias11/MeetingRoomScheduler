FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app


COPY MeetingRoomScheduler.API/*.csproj ./MeetingRoomScheduler.API/
COPY MeetingRoomScheduler.Application/*.csproj ./MeetingRoomScheduler.Application/
COPY MeetingRoomScheduler.Domain/*.csproj ./MeetingRoomScheduler.Domain/
COPY MeetingRoomScheduler.Infrastructure/*.csproj ./MeetingRoomScheduler.Infrastructure/

RUN dotnet restore MeetingRoomScheduler.API/MeetingRoomScheduler.API.csproj

COPY . .

RUN dotnet publish MeetingRoomScheduler.API/MeetingRoomScheduler.API.csproj -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /publish .

EXPOSE 80
EXPOSE 443

CMD ["dotnet", "MeetingRoomScheduler.API.dll"]
