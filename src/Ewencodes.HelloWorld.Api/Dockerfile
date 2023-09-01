FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
LABEL maintainer="https://github.com/ewencodes"
LABEL description="Ewencodes.HelloWorld.Api"

# Non-root user configuration
RUN groupadd -r dotnet-user && useradd --no-log-init -r -g dotnet-user dotnet-user
USER dotnet-user

WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG TARGETARCH

# Build
WORKDIR /src
COPY ["src/Ewencodes.HelloWorld.Api/Ewencodes.HelloWorld.Api.csproj", "Ewencodes.HelloWorld.Api/"]
RUN dotnet restore "Ewencodes.HelloWorld.Api/Ewencodes.HelloWorld.Api.csproj" -a $TARGETARCH
COPY ./src .
WORKDIR /src/Ewencodes.HelloWorld.Api
RUN dotnet build "Ewencodes.HelloWorld.Api.csproj" -c Release -a $TARGETARCH -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "Ewencodes.HelloWorld.Api.csproj" -c Release -a $TARGETARCH -o /app/publish

# App
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ewencodes.HelloWorld.Api.dll"]