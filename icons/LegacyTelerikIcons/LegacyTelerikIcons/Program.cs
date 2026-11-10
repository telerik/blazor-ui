using Microsoft.AspNetCore.SignalR;
using LegacyTelerikIcons.Components;
using LegacyTelerikIcons.Services;
using Telerik.Blazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddTelerikBlazor();
builder.Services.AddSingleton<ITelerikIconService, TelerikSvgIconsV4Service>();

// SignalR max message size for Editor, FileManager, FileSelect, PDF Viewer, Signature
builder.Services.Configure<HubOptions>(options =>
{
    //options.MaximumReceiveMessageSize = 32 * 1024; // 32 KB, or use null for no limit
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);

app.UseHttpsRedirection();

app.MapStaticAssets();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();