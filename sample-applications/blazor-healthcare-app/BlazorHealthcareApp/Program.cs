using BlazorHealthcareApp.Components;
using BlazorHealthcareApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTelerikBlazor();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// ========== Application Services ==========
builder.Services.AddScoped<PatientService>();
builder.Services.AddScoped<AppointmentService>();
builder.Services.AddScoped<TaskService>();
builder.Services.AddScoped<AlertService>();
builder.Services.AddScoped<StaffService>();
builder.Services.AddScoped<AnalyticsService>();
builder.Services.AddScoped<AIChatService>();

var app = builder.Build();

app.UsePathBase("/blazor-healthcare/");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapBlazorHub("/blazor-healthcare/_blazor");

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
