#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["RentAndInvoice.Core.WebAPI/RentAndInvoice.Core.WebAPI.csproj", "RentAndInvoice.Core.WebAPI/"]
COPY ["RentAndInvoice.Core.Application/RentAndInvoice.Core.Application.csproj", "RentAndInvoice.Core.Application/"]
COPY ["RentAndInvoice.Core.Domain/RentAndInvoice.Core.Domain.csproj", "RentAndInvoice.Core.Domain/"]
COPY ["RentAndInvoice.Core.Infraestructure/RentAndInvoice.Core.Infraestructure.csproj", "RentAndInvoice.Core.Infraestructure/"]
RUN dotnet restore "RentAndInvoice.Core.WebAPI/RentAndInvoice.Core.WebAPI.csproj"
COPY . .
WORKDIR "/src/RentAndInvoice.Core.WebAPI"
RUN dotnet build "RentAndInvoice.Core.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RentAndInvoice.Core.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RentAndInvoice.Core.WebAPI.dll"]