FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GrpcRandomNumbersService.csproj", "GrpcRandomNumbersService/"]
RUN dotnet restore "GrpcRandomNumbersService/GrpcRandomNumbersService.csproj"
WORKDIR "/src/GrpcRandomNumbersService"
COPY . .
RUN dotnet build "GrpcRandomNumbersService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GrpcRandomNumbersService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS="http://+:8080"

EXPOSE 8080/tcp

ENTRYPOINT ["dotnet", "GrpcRandomNumbersService.dll"]