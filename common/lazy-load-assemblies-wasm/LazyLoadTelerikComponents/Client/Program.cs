using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Telerik.Blazor.Services;
using LazyLoadTelerikComponents.Shared.Services;

namespace LazyLoadTelerikComponents.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            // now you don't register Telerik services here because the assemblies will be lazy-loaded
            // so this code and namespaces won't be available when the app starts.
            //builder.Services.AddTelerikBlazor();
            //builder.Services.AddSingleton(typeof(ITelerikStringLocalizer), typeof(SampleResxLocalizer));



            var host = builder.Build();

            await SetCultureAsync(host);

            await host.RunAsync();
        }


        // based on https://github.com/pranavkm/LocSample
        private static async Task SetCultureAsync(WebAssemblyHost host)
        {
            var jsRuntime = host.Services.GetRequiredService<IJSRuntime>();
            var cultureName = await jsRuntime.InvokeAsync<string>("blazorCulture.get");

            if (cultureName != null)
            {
                var culture = new CultureInfo(cultureName);

                CultureInfo.DefaultThreadCurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentUICulture = culture;
            }
        }
    }
}
