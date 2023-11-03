#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebAPI.DevsuTest/WebAPI.DevsuTest.csproj", "WebAPI.DevsuTest/"]
COPY ["WebAPI.DevsuTest.Commons/WebAPI.DevsuTest.Commons.csproj", "WebAPI.DevsuTest.Commons/"]
COPY ["WebAPI.DevsuTest.Util/WebAPI.DevsuTest.Util.csproj", "WebAPI.DevsuTest.Util/"]
COPY ["WebAPI.DevsuTest.DTOs/WebAPI.DevsuTest.DTOs.csproj", "WebAPI.DevsuTest.DTOs/"]
COPY ["WebAPI.DevsuTest.Interfaces/WebAPI.DevsuTest.Interfaces.csproj", "WebAPI.DevsuTest.Interfaces/"]
COPY ["WebAPI.DevsuTest.Models/WebAPI.DevsuTest.Models.csproj", "WebAPI.DevsuTest.Models/"]
COPY ["WebAPI.DevsuTest.Repositories/WebAPI.DevsuTest.Repositories.csproj", "WebAPI.DevsuTest.Repositories/"]
COPY ["WebAPI.DevsuTest.Setup/WebAPI.DevsuTest.Setup.csproj", "WebAPI.DevsuTest.Setup/"]
COPY ["WebAPI.DevsuTest.Middlewares/WebAPI.DevsuTest.Middlewares.csproj", "WebAPI.DevsuTest.Middlewares/"]
COPY ["WebAPI.DevsuTest.Services/WebAPI.DevsuTest.Services.csproj", "WebAPI.DevsuTest.Services/"]
RUN dotnet restore "WebAPI.DevsuTest/WebAPI.DevsuTest.csproj"
COPY . .
WORKDIR "/src/WebAPI.DevsuTest"
RUN dotnet build "WebAPI.DevsuTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAPI.DevsuTest.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPI.DevsuTest.dll"]