FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/PoemPost.Admin/PoemPost.Admin.csproj", "src/PoemPost.Admin/"]
COPY ["src/PoemPost.Admin.EntityFramework.Shared/PoemPost.Admin.EntityFramework.Shared.csproj", "src/PoemPost.Admin.EntityFramework.Shared/"]
COPY ["src/PoemPost.Admin.EntityFramework.SqlServer/PoemPost.Admin.EntityFramework.SqlServer.csproj", "src/PoemPost.Admin.EntityFramework.SqlServer/"]
COPY ["src/PoemPost.Admin.EntityFramework.PostgreSQL/PoemPost.Admin.EntityFramework.PostgreSQL.csproj", "src/PoemPost.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/PoemPost.Shared/PoemPost.Shared.csproj", "src/PoemPost.Shared/"]
COPY ["src/PoemPost.Admin.EntityFramework.MySql/PoemPost.Admin.EntityFramework.MySql.csproj", "src/PoemPost.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/PoemPost.Admin/PoemPost.Admin.csproj"
COPY . .
WORKDIR "/src/src/PoemPost.Admin"
RUN dotnet build "PoemPost.Admin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PoemPost.Admin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "PoemPost.Admin.dll"]