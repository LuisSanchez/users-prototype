FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=build /app .
COPY --from=build /src/User/aspnetapp.pfx .
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=password
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/app/aspnetapp.pfx
ENTRYPOINT ["dotnet", "User.dll"]
