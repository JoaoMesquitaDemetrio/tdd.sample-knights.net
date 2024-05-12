FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS restore
WORKDIR /src
COPY ["src/UI/Sample.Knights.UI.Api/Sample.Knights.UI.Api.csproj", "src/UI/Sample.Knights.UI.Api/"]
COPY ["src/Core/Sample.Knights.Core.Application/Sample.Knights.Core.Application.csproj", "src/Core/Sample.Knights.Core.Application/"]
COPY ["src/Core/Sample.Knights.Core.Domain/Sample.Knights.Core.Domain.csproj", "src/Core/Sample.Knights.Core.Domain/"]
COPY ["src/Core/Sample.Knights.Core.Infra/Sample.Knights.Core.Infra.csproj", "src/Core/Sample.Knights.Core.Infra/"]
COPY ["src/Core/Sample.Knights.Core.IoC/Sample.Knights.Core.IoC.csproj", "src/Core/Sample.Knights.Core.IoC/"]
COPY ["utility/Sample.Utils/Sample.Utils.csproj", "utility/Sample.Utils/"]
RUN dotnet restore "src/UI/Sample.Knights.UI.Api/Sample.Knights.UI.Api.csproj"

FROM restore AS build
COPY . .
WORKDIR "/src/src/UI/Sample.Knights.UI.Api"
RUN dotnet build "Sample.Knights.UI.Api.csproj" --no-restore -c:"Release" -p:"Platform=x64"

FROM build AS publish
RUN dotnet publish "Sample.Knights.UI.Api.csproj" --no-build -c:"Release" -o /app/publish -p:"Platform=x64"

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV COMPlus_GCHeapHardLimit=20000000
ENV COMPlus_gcConcurrent=1
ENV COMPlus_gcServer=0
ENV DOTNET_EnableWriteXorExecute=1
ENV TZ America/Sao_Paulo
ENV ASPNETCORE_HTTP_PORTS=80
ENTRYPOINT ["dotnet", "Sample.Knights.UI.Api.dll"]
