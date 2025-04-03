using AIPromptIntegration.Components;
using Microsoft.Extensions.AI;
using Azure;
using Azure.AI.OpenAI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddTelerikBlazor();

#region Azure AI Inference Client registration

//builder.Services.AddChatClient(
//    new Azure.AI.Inference.ChatCompletionsClient(
//        new Uri("https://models.inference.ai.azure.com"),
//        new AzureKeyCredential("YOUR_AZURE_OPENAI_CREDENTIAL")
//    ).AsChatClient("Phi-3.5-MoE-instruct"));

#endregion Azure AI Inference Client registration

#region OpenAI Client registration

//builder.Services.AddSingleton(new OpenAIClient("YOUR_API_KEY));
//builder.Services.AddDistributedMemoryCache();
//builder.Services.AddLogging(b => b.AddConsole().SetMinimumLevel(LogLevel.Trace));

//builder.Services.AddChatClient(services => services.GetRequiredService<OpenAIClient>().AsChatClient("YOUR_MODEL_NAME"))
//    .UseDistributedCache()
//    .UseLogging();

#endregion OpenAI Client registration

#region Azure OpenAI Client registration

//builder.Services.AddSingleton(new AzureOpenAIClient(
//   new Uri("YOUR_AZURE_OPENAI_ENDPOINT"),
//   new AzureKeyCredential("YOUR_AZURE_OPENAI_CREDENTIAL")));

//builder.Services.AddChatClient(services => services.GetRequiredService<AzureOpenAIClient>().AsChatClient("gpt-4o-mini"));

#endregion Azure OpenAI Client registration

#region Ollama Chat Client registration

//builder.Services.AddDistributedMemoryCache();
//builder.Services.AddLogging(b => b.AddConsole().SetMinimumLevel(LogLevel.Trace));

//builder.Services.AddChatClient(new OllamaChatClient(new Uri("THE_URI_OF_YOUR_CLIENT"), "llama3.1"))
//    .UseDistributedCache()
//    .UseLogging();

#endregion Ollama Chat Client registration

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
