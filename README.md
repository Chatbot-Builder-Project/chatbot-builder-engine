# Chatbot Builder Engine

## Development

### Setting Up Protos

1. Navigate to the infrastructure layer:
    ```bash
    cd ChatbotBuilderEngine.Infrastructure
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