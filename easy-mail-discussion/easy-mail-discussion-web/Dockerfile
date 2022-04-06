#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
ENV LOG_LEVEL="debug"
ENV FETCH_TIME="00:05:00"
ENV WEB_ONLY="1"

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["easy-mail-discussion-web/easy-mail-discussion-web.csproj", "easy-mail-discussion-web/"]
RUN dotnet restore "easy-mail-discussion-web/easy-mail-discussion-web.csproj"
COPY . .
WORKDIR "/src/easy-mail-discussion-web"
RUN dotnet build "easy-mail-discussion-web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "easy-mail-discussion-web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "easy-mail-discussion-web.dll"]