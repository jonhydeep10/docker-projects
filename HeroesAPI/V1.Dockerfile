## --------------------------------------------Al hacerlo de esta forma se esta dependiendo de que la maquina tenga el sdk de .net 8 para publicar

FROM mcr.microsoft.com/dotnet/aspnet:9.0

WORKDIR /app

EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

COPY publish .

ENTRYPOINT ["dotnet","HeroesAPI.dll"]


