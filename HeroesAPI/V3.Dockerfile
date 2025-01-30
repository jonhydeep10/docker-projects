## --------------------------------------------La ultima forma es usar Multi-Stage, el cual es poder utilizar 
##                                              varias imagenes como base y generar la imagen final usando varios pasos

## Paso 1: Definir la imagen base que sera usada para hospedar la app

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base

LABEL org.opencontainers.image.source=https://github.com/jonhydeep10/docker-projects
LABEL org.opencontainers.image.description="Mis proyectos docker"
LABEL org.opencontainers.image.license="MIT"

WORKDIR /app

EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

## Paso 2: Publicar la app usando otra imagen

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

COPY . .

RUN dotnet publish "HeroesAPI.csproj" -c release -o /app/publish

## Paso 3: Copiar los archivos de la publicacion en la primer imagen

FROM base AS final

WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet","HeroesAPI.dll"]


