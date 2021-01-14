using BlazingCoffee.Client.Shared.Layouts;
using BlazingCoffee.Services;
using BlazingCoffee.Shared.Localization;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Telerik.Blazor.Services;

namespace BlazingCoffee.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            ConfigureServices(builder);

            var host = builder.Build();
            var localStorage = host.Services.GetRequiredService<ILocalStorageService>();
            var result = await localStorage.GetItemAsStringAsync("BlazorCulture");
            if (result != null)
            {
                var culture = new CultureInfo(result);
                CultureInfo.DefaultThreadCurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentUICulture = culture;
            }

            await host.RunAsync();
        }

        private static void ConfigureServices(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddTelerikBlazor();

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddHttpClient<PublicHttp>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
            builder.Services.AddHttpClient("BlazingCoffee.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                            .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
            builder.Services.AddScoped<MainLayoutState>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazingCoffee.ServerAPI"));
            builder.Services.AddApiAuthorization();

            // register a custom localizer for the Telerik components, after registering the Telerik services
            builder.Services.AddSingleton<ITelerikStringLocalizer, TelerikLocalizer>();
            builder.Services.AddLocalization();
        }
    }
}
