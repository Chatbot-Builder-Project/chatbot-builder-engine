# Chatbot Builder Engine

## Development

### Setting Up Protos

1. Navigate to the presentation layer:
    ```bash
    cd ChatbotBuilderEngine.Presentation
    ```

2. Clone the `chatbot-builder-protos` repository:
   ```bash
   git clone https://github.com/Chatbot-Builder-Project/chatbot-builder-protos.git
   ```
   Or update the repository if it already cloned:
   ```bash
   cd chatbot-builder-protos
   git pull
   cd ..
   ```

3. Copy the `chatbot-builder-protos/protos` directory to the `Protos` namespace:
   ```bash
   cp -r chatbot-builder-protos/protos Protos
   ```

4. Build the solution:
   ```bash
   dotnet build
   ```

### Running the Application

- The dockerfile has to be built from the root directory to ensure broader context in the building steps.
    ```bash
    docker build -f ChatbotBuilderEngine/Dockerfile -t chatbot-builder-engine .
    ```

- Then run the docker container:
    ```bash
    docker run -d -p 8080:8080 -p 8081:8081 chatbot-builder-engine
    ```
