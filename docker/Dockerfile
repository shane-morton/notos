FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build

WORKDIR /build

COPY ./src/Notos.Database/*.csproj ./Notos.Database/
COPY ./src/Notos.Service/*.csproj ./Notos.Service/
COPY ./src/Notos.WebApi/*.csproj ./Notos.WebApi/

WORKDIR /build/Notos.WebApi
RUN dotnet restore

# Copy everything else and build
WORKDIR /build
COPY ./src/Notos.Database/ ./Notos.Database/
COPY ./src/Notos.Service/ ./Notos.Service/
COPY ./src/Notos.WebApi/ ./Notos.WebApi/

WORKDIR /build/Notos.WebApi
RUN dotnet build "Notos.WebApi.csproj" -c Release -o build

FROM build AS publish
RUN dotnet publish -c release -o publish

# Build runtime image
FROM base AS final
WORKDIR /build
COPY --from=publish /build/Notos.WebApi/publish .
ENTRYPOINT ["dotnet", "Notos.WebApi.dll"]
