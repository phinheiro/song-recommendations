#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["Conexia.SR.WebAPI/Conexia.SR.WebAPI.csproj", "Conexia.SR.WebAPI/"]
COPY ["Conexia.SR.Data/Conexia.SR.Data.csproj", "Conexia.SR.Data/"]
COPY ["Conexia.SR.Domain.Core/Conexia.Core.csproj", "Conexia.SR.Domain.Core/"]
COPY ["Conexia.SR.Domain/Conexia.SR.Domain.csproj", "Conexia.SR.Domain/"]
COPY ["Conexia.SR.Application/Conexia.SR.Application.csproj", "Conexia.SR.Application/"]
COPY ["Conexia.SR.CrossCutting.Identity/Conexia.SR.CrossCutting.Identity.csproj", "Conexia.SR.CrossCutting.Identity/"]
RUN dotnet restore "Conexia.SR.WebAPI/Conexia.SR.WebAPI.csproj"
COPY . .
WORKDIR "/src/Conexia.SR.WebAPI"
RUN dotnet build "Conexia.SR.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Conexia.SR.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Conexia.SR.WebAPI.dll"]