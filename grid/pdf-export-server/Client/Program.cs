using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ServerPdfExport.Client.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ServerPdfExport.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<WeatherForecastService>();
            builder.Services.AddTelerikBlazor();

            await builder.Build().RunAsync();
        }
    }
}
