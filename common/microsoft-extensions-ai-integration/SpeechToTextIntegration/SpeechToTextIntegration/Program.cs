using Microsoft.Extensions.AI;
using SpeechToTextIntegration.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddHubOptions(o => o.MaximumReceiveMessageSize = 4 * 1024 * 1024);

builder.Services.AddTelerikBlazor();

#region AI Service Registration Start

// Get the appropriate environment variables for your model's service.
var key = Environment.GetEnvironmentVariable("YOUR_TRANSCRIPTION_MODEL_API_KEY");

// Open AI whisper-1 model registration. Refer to your preferred model documentation for more details.
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSpeechToTextClient(services =>
    new OpenAI.Audio.AudioClient("whisper-1", key).AsISpeechToTextClient());

#endregion AI Service Registration End

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseDeveloperExceptionPage();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
