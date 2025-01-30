## --------------------------------------------De esta manera ya no se depende del sdk en la maquina

FROM mcr.microsoft.com/dotnet/sdk:9.0

WORKDIR /app

EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

COPY . .

RUN dotnet publish "HeroesAPI.csproj" -c release -o /app

ENTRYPOINT ["dotnet","HeroesAPI.dll"]

