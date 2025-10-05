# Backend/TodoApp/Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .

RUN dotnet restore "TodoApp.csproj"
RUN dotnet build "TodoApp.csproj" -c Release -o /app/build
RUN dotnet publish "TodoApp.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "TodoApp.dll"]