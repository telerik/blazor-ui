using AIPromptIntegration.Components;
using Microsoft.Extensions.AI;
using Azure;
using Azure.AI.OpenAI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddTelerikBlazor();

builder.Services.AddSingleton(new AzureOpenAIClient(
    //new Uri("YOUR_AZURE_OPENAI_ENDPOINT"),
    //new AzureKeyCredential("YOUR_AZURE_OPENAI_CREDENTIAL"))
    new Uri("https://ai-explorations.openai.azure.com"),
    new AzureKeyCredential("---")));

builder.Services.AddChatClient(services => services.GetRequiredService<AzureOpenAIClient>().AsChatClient("gpt-4o-mini"));

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
