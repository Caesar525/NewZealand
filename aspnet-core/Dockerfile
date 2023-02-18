FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src
COPY ["src/NEWZEALAND.Web.Host/NEWZEALAND.Web.Host.csproj", "src/NEWZEALAND.Web.Host/"]
COPY ["src/NEWZEALAND.Web.Core/NEWZEALAND.Web.Core.csproj", "src/NEWZEALAND.Web.Core/"]
COPY ["src/NEWZEALAND.Application/NEWZEALAND.Application.csproj", "src/NEWZEALAND.Application/"]
COPY ["src/NEWZEALAND.Core/NEWZEALAND.Core.csproj", "src/NEWZEALAND.Core/"]
COPY ["src/NEWZEALAND.EntityFrameworkCore/NEWZEALAND.EntityFrameworkCore.csproj", "src/NEWZEALAND.EntityFrameworkCore/"]
WORKDIR "/src/src/NEWZEALAND.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/NEWZEALAND.Web.Host", "src/NEWZEALAND.Web.Host"]
COPY ["src/NEWZEALAND.Web.Core", "src/NEWZEALAND.Web.Core"]
COPY ["src/NEWZEALAND.Application", "src/NEWZEALAND.Application"]
COPY ["src/NEWZEALAND.Core", "src/NEWZEALAND.Core"]
COPY ["src/NEWZEALAND.EntityFrameworkCore", "src/NEWZEALAND.EntityFrameworkCore"]
WORKDIR "/src/src/NEWZEALAND.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "NEWZEALAND.Web.Host.dll"]
