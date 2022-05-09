#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
COPY . .
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LuckyWheel/LuckyWheel.csproj", "LuckyWheel/"]
COPY ["LuckyWheel.Core/LuckyWheel.Core.csproj", "LuckyWheel.Core/"]
RUN dotnet restore "LuckyWheel/LuckyWheel.csproj"
COPY . .
WORKDIR "/src/LuckyWheel"
RUN dotnet build "LuckyWheel.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LuckyWheel.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LuckyWheel.dll"]