FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["TrackIt/TrackIt.csproj", "TrackIt/"]
RUN dotnet restore "TrackIt/TrackIt.csproj"
COPY . .
WORKDIR "/src/TrackIt"
RUN dotnet build "TrackIt.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TrackIt.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TrackIt.dll"]