using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using TelerikBlazor.App.Models;
using TelerikBlazor.App.Services;

namespace TelerikBlazor.App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Example of a data service
            services.AddSingleton<WeatherForecastService>();

            services.AddSingleton(new NorthwindContext());

            services.AddKendoBlazor();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
