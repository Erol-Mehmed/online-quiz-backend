FROM mcr.microsoft.com/dotnet/sdk:10.0-preview

WORKDIR /app

# Copy csproj and restore
COPY *.csproj ./
RUN dotnet restore

# Copy everything
COPY . ./

EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

# Run with hot reload
ENTRYPOINT ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:8080"]
