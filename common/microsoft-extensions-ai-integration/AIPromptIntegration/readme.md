# AIPrompt integration with Microsoft.Extensions.AI

## Overview

This project demonstrates the [integration of the `Microsoft.Extensions.AI` package with the `AIPrompt` component](https://www.telerik.com/blazor-ui/documentation/common-features/microsoft-extensions-ai-integration). The integration enables AI-powered interactions leveraging the built-in [`IChatClient` service](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.ai.ichatclient?view=net-9.0-pp). The example uses **Azure OpenAI**, but you can use any service supported by `Microsoft.Extensions.AI`. 

## About `Microsoft.Extensions.AI`

The [`Microsoft.Extensions.AI` package](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.ai?view=net-9.0-pp) provides an abstraction for AI-powered services, making it easy to integrate large language models (LLMs) into .NET applications. It simplifies AI interaction by offering dependency injection support and a structured way to handle AI-based workflows.

## Integration with `AIPrompt` Component

- The [`AIPrompt` component](https://www.telerik.com/blazor-ui/documentation/components/aiprompt/overview) is configured to use `Microsoft.Extensions.AI` for AI-driven prompts.
- The project registers an [`IChatClient` service](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.ai.ichatclient?view=net-9.0-pp) in the `Program.cs` file.
- The [`OnPromptRequest` event](https://www.telerik.com/blazor-ui/documentation/components/aiprompt/events#onpromptrequest) of the `AIPrompt` is not handled, so the component will automatically use the registered `IChatClient` service for to generate a response.
- **Azure OpenAI** is used as the AI provider for generating responses.

## Setup & Configuration

To run the project successfully, you need to provide your **Azure OpenAI URI** and **API key**. The steps apply to using **Azure Open AI** and the configuration may be different if you are using a different model. Refer to the official Microsoft documentation to see how to configure other models.

### Steps:

1. Open the `Program.cs` file.
2. Locate the `IChatClient` service registration.
3. Uncomment the service registration.
3. Replace the placeholder values with your actual Azure OpenAI endpoint and API key:

   ```csharp
   new Uri("YOUR_AZURE_OPENAI_ENDPOINT"),
   new AzureKeyCredential("YOUR_AZURE_OPENAI_CREDENTIAL"))
   ```

4. Run the application and interact with the `AIPrompt` component.

