FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["clientgrpc/clientgrpc.csproj", "clientgrpc/"]
RUN dotnet restore "clientgrpc/clientgrpc.csproj"
COPY . .
WORKDIR "/src/clientgrpc"
RUN dotnet build "clientgrpc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "clientgrpc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "clientgrpc.dll"]
