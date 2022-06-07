#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NuGet.config", "."]
COPY ["src/Message.Dispatcher.Web/Message.Dispatcher.Web.csproj", "src/Message.Dispatcher.Web/"]
COPY ["src/Message.Dispatcher.Messages/Message.Dispatcher.Messages.csproj", "src/Message.Dispatcher.Messages/"]
COPY ["src/Message.Dispatcher.Share/Message.Dispatcher.Share.csproj", "src/Message.Dispatcher.Share/"]
COPY ["src/Message.Dispatcher.Application/Message.Dispatcher.Application.csproj", "src/Message.Dispatcher.Application/"]
COPY ["src/Message.Dispatcher.Infrastructure/Message.Dispatcher.Infrastructure.csproj", "src/Message.Dispatcher.Infrastructure/"]
COPY ["src/Message.Dispatcher.Core/Message.Dispatcher.Core.csproj", "src/Message.Dispatcher.Core/"]
COPY ["src/Message.Dispatcher.Mapping/Message.Dispatcher.Mapping.csproj", "src/Message.Dispatcher.Mapping/"]
RUN dotnet restore "src/Message.Dispatcher.Web/Message.Dispatcher.Web.csproj"
COPY . .
WORKDIR "/src/src/Message.Dispatcher.Web"
RUN dotnet build "Message.Dispatcher.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Message.Dispatcher.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Message.Dispatcher.Web.dll"]