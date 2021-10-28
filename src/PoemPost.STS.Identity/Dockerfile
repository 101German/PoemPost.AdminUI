FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/PoemPost.STS.Identity/PoemPost.STS.Identity.csproj", "src/PoemPost.STS.Identity/"]
COPY ["src/PoemPost.Admin.EntityFramework.Shared/PoemPost.Admin.EntityFramework.Shared.csproj", "src/PoemPost.Admin.EntityFramework.Shared/"]
COPY ["src/PoemPost.Admin.EntityFramework.SqlServer/PoemPost.Admin.EntityFramework.SqlServer.csproj", "src/PoemPost.Admin.EntityFramework.SqlServer/"]
COPY ["src/PoemPost.Admin.EntityFramework.PostgreSQL/PoemPost.Admin.EntityFramework.PostgreSQL.csproj", "src/PoemPost.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/PoemPost.Shared/PoemPost.Shared.csproj", "src/PoemPost.Shared/"]
COPY ["src/PoemPost.Admin.EntityFramework.MySql/PoemPost.Admin.EntityFramework.MySql.csproj", "src/PoemPost.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/PoemPost.STS.Identity/PoemPost.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/PoemPost.STS.Identity"
RUN dotnet build "PoemPost.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PoemPost.STS.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "PoemPost.STS.Identity.dll"]