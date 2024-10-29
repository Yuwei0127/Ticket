# CI
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BuildConfiguration=Debug
WORKDIR /src
COPY . Ticket/
RUN dotnet restore "Ticket/Ticket.sln"
RUN dotnet publish "Ticket/Ticket.sln" --no-restore -c $BuildConfiguration -o /app/publish

# CD
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
EXPOSE 80
EXPOSE 443
RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf
RUN sed -i 's/MinProtocol = TLSv1.2/MinProtocol = TLSv1/g' /etc/ssl/openssl.cnf
RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /usr/lib/ssl/openssl.cnf
RUN sed -i 's/MinProtocol = TLSv1.2/MinProtocol = TLSv1/g' /usr/lib/ssl/openssl.cnf
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Ticket.dll"]
