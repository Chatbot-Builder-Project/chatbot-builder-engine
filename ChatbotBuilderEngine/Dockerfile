FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ChatbotBuilderEngine/ChatbotBuilderEngine.csproj", "ChatbotBuilderEngine/"]
RUN dotnet restore "ChatbotBuilderEngine/ChatbotBuilderEngine.csproj"

WORKDIR /src/ChatbotBuilderEngine.Presentation
RUN git clone https://github.com/Chatbot-Builder-Project/chatbot-builder-protos.git
RUN cp -r chatbot-builder-protos/protos Protos

WORKDIR /src
COPY . .
WORKDIR "/src/ChatbotBuilderEngine"
RUN dotnet build "ChatbotBuilderEngine.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ChatbotBuilderEngine.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChatbotBuilderEngine.dll"]
