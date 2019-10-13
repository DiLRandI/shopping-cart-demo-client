FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out --self-contained -r linux-musl-x64

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim
WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "shopping-cart-demo-client.dll"]