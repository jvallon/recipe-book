#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_URLS="http://0.0.0.0:5000"

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["recipebookserver/recipebookserver.csproj", "recipebookserver/"]
RUN dotnet restore "recipebookserver/recipebookserver.csproj"
COPY . .
WORKDIR "/src/recipebookserver"
RUN dotnet build "recipebookserver.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "recipebookserver.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "recipebookserver.dll"]