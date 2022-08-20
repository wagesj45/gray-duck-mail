#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 5000
ENV LOG_LEVEL="debug"
ENV FETCH_TIME="00:05:00"
ENV WEB_ONLY="0"
ENV MIN_SEARCH_SCORE="0.2"
ENV ASPNETCORE_URLS=http://+:5000;http://+:80
VOLUME /database

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["gray-duck-mail-web/gray-duck-mail-web.csproj", "gray-duck-mail-web/"]
RUN dotnet restore "gray-duck-mail-web/gray-duck-mail-web.csproj"
COPY . .
WORKDIR "/src/gray-duck-mail-web"
RUN dotnet build "gray-duck-mail-web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "gray-duck-mail-web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "gray-duck-mail-web.dll"]