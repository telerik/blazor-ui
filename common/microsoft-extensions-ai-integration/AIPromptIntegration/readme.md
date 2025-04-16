# AIPrompt integration with Microsoft.Extensions.AI

## Overview

This project demonstrates the [integration of the `Microsoft.Extensions.AI` package with the `AIPrompt` component](https://www.telerik.com/blazor-ui/documentation/common-features/microsoft-extensions-ai-integration). The integration enables AI-powered interactions leveraging the built-in [`IChatClient` service](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.ai.ichatclient?view=net-9.0-pp). The example shows how to use the [various models supported by `Microsoft.Extensions.AI`](https://devblogs.microsoft.com/dotnet/introducing-microsoft-extensions-ai-preview/#chat). 

## About `Microsoft.Extensions.AI`

The [`Microsoft.Extensions.AI` package](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.ai?view=net-9.0-pp) provides an abstraction for AI-powered services, making it easy to integrate large language models (LLMs) into .NET applications. It simplifies AI interaction by offering dependency injection support and a structured way to handle AI-based workflows.

## Integration with `AIPrompt` Component

- The [`AIPrompt` component](https://www.telerik.com/blazor-ui/documentation/components/aiprompt/overview) is configured to use `Microsoft.Extensions.AI` for AI-driven prompts.
- The project registers several [`IChatClient` services](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.ai.ichatclient?view=net-9.0-pp) in the `Program.cs` file - one for each model supported by `Microsoft.Extensions.AI`.
- The [`OnPromptRequest` event](https://www.telerik.com/blazor-ui/documentation/components/aiprompt/events#onpromptrequest) of the `AIPrompt` is not handled, so the component will automatically use the registered `IChatClient` service to generate a response.

## Setup & Configuration

To run the project successfully, you need to provide your endpoint and credentials for the model you want to use.

### Steps:

1. Open the `Program.cs` file.
2. Locate the `IChatClient` service registration that uses your preferred model.
3. Uncomment the service registration.
3. Replace the placeholder values with your actual endpoint and credentials.
4. Run the application and interact with the `AIPrompt` component.

### Client Registrations

**Azure AI Inference Client registration**

```csharp
var innerClient = new Azure.AI.Inference.ChatCompletionsClient(
        new Uri(endpoint),
        new AzureKeyCredential(apikey)
    ).AsChatClient(model);
```

**Azure OpenAI Client registration**

```csharp
var innerClient = new AzureOpenAIClient(
        new Uri(endpoint),
        new AzureKeyCredential(apikey)
    ).AsChatClient(model);
```

**OpenAI Client registration**

```csharp
var innerClient = new OpenAIClient(apikey)
                        .AsChatClient(model);
```

**GitHub Models Client registration**

```csharp
var innerClient = new OpenAIClient(
			new ApiKeyCredential(apikey),
			new OpenAIClientOptions()
			{
				Endpoint = new Uri(endpoint)
			}
		).AsChatClient(model);
```

**Ollama Client registration**
```csharp 
var innerClient = new OllamaChatClient(new Uri(endpoint), model);
```
