FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["User/User.csproj", "User/"]
RUN dotnet restore "User/User.csproj"
COPY . .
WORKDIR "/src/User"
RUN dotnet build "User.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "User.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "User.dll"]
