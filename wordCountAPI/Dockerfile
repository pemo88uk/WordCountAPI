# Use .NET 7 SDK to build the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY wordCountAPI/wordCountAPI.csproj ./
RUN dotnet restore wordCountAPI.csproj

# Copy the remaining source code
COPY wordCountAPI/. ./
RUN dotnet publish -c Release -o out

# Use .NET 7 ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Expose port 80
EXPOSE 80

# Run the app
ENTRYPOINT ["dotnet", "wordCountAPI.dll"]