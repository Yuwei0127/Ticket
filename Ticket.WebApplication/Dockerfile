FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Ticket.WebApplication/Ticket.WebApplication.csproj", "Ticket.WebApplication/"]
COPY ["Ticket.Common/Ticket.Common.csproj", "Ticket.Common/"]
COPY ["Ticket.Service/Ticket.Service.csproj", "Ticket.Service/"]
RUN dotnet restore "Ticket.WebApplication/Ticket.WebApplication.csproj"
COPY . .
WORKDIR "/src/Ticket.WebApplication"
RUN dotnet build "Ticket.WebApplication.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Ticket.WebApplication.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ticket.WebApplication.dll"]
