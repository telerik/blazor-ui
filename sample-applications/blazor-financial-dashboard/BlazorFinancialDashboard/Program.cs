using BlazorFinancialDashboard.Components;
using BlazorFinancialDashboard.Services;
using Telerik.Blazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<TransactionService>();
builder.Services.AddSingleton<PaymentMethodService>();
builder.Services.AddSingleton<AIAssistantService>();
builder.Services.AddSingleton<InvestmentService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<CardService>();

builder.Services.AddTelerikBlazor();

#region Localization
builder.Services.AddControllers();
builder.Services.AddSingleton(typeof(ITelerikStringLocalizer), typeof(ResxLocalizer));
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
#endregion Localization

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

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

var supportedCultures = new[] { "en-US", "de-DE" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
