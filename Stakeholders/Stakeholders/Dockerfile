FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY Stakeholders/*.csproj Stakeholders/
COPY API/*.csproj API/
COPY Common/*.csproj Common/
COPY Core/*.csproj Core/
COPY Infrastructure/*.csproj Infrastructure/
COPY *.sln ./
RUN dotnet restore 
COPY . .
WORKDIR "/src/Stakeholders"
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false --no-restore
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish ./
ENTRYPOINT [ "dotnet", "Stakeholders.dll" ]