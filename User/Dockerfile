FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
RUN mkdir -p /https
COPY . .

# Generate and export HTTPS certificate
RUN dotnet dev-certs https -ep /https/aspnetapp.pfx -p password

RUN dotnet restore
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

# Configure environment variables
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:80;https://+:443
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=password
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx

# Create directory for data protection keys and certificates
RUN mkdir -p /keys /https && \
    chown -R www-data:www-data /keys && \
    chmod 700 /keys

COPY --from=build /app .
COPY --from=build /https/aspnetapp.pfx /https/
ENTRYPOINT ["dotnet", "User.dll"]
