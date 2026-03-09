# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
WORKDIR /app

# Copy only the csproj and restore
COPY *.csproj ./
RUN dotnet restore

# Copy everything and publish
COPY . ./
RUN dotnet publish OnlineQuiz.Api.csproj -c Release -o /app/out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview
WORKDIR /app
COPY --from=build /app/out ./

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "OnlineQuiz.Api.dll"]
