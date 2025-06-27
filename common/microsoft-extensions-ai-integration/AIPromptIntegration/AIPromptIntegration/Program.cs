using AIPromptIntegration.Components;
using Microsoft.Extensions.AI;

// Optional model provider implementations:
// Azure models
using Azure;
using Azure.AI.OpenAI;
// OpenAI models
using OpenAI;
// GitHub models
using System.ClientModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddTelerikBlazor();

// You will need to set the endpoint and key to your own values
// You can do this using Visual Studio's "Manage User Secrets" UI, or on the command line 💻:
//   cd this-project-directory
//   dotnet user-secrets set Endpoint https://YOUR-DEPLOYMENT-NAME.openai.azure.com
//   dotnet user-secrets set ApiKey super-secret-api-key

// 🌐 The Uri of your provider
var endpoint = builder.Configuration["Endpoint"] ?? throw new InvalidOperationException("Missing configuration: Endpoint. See the README for details.");
// 🔑 The API Key for your provider
var apikey = builder.Configuration["ApiKey"] ?? throw new InvalidOperationException("Missing configuration: ApiKey. See the README for details.");
// 🧠 The model name or Azure deployment name
var model = "YOUR_MODEL_NAME";

// Use your preferred AI client below

// If using OpenAIClient
builder.Services.AddSingleton(new OpenAIClient(
    new ApiKeyCredential(apikey),
    new OpenAIClientOptions()
    {
        Endpoint = new Uri(endpoint)
    }
));

builder.Services.AddChatClient(services => services.GetRequiredService<OpenAIClient>().GetChatClient(model).AsIChatClient())  // 🤖 Add the configured chat client
    .UseFunctionInvocation() // 🛠️ Include tool calling
    .UseLogging(); //🐞 Include Logging

// OR

// If using AzureOpenAIClient

// builder.Services.AddSingleton(new AzureOpenAIClient(
//     new Uri(endpoint),
//     new AzureKeyCredential(apikey)
// ));

// builder.Services.AddChatClient(services => services.GetRequiredService<AzureOpenAIClient>().GetChatClient(model).AsIChatClient());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
