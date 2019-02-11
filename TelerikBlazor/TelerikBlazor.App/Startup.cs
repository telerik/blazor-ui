using Microsoft.AspNetCore.Components.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TelerikBlazor.App.Models;
using TelerikBlazor.App.Services;

namespace TelerikBlazor.App
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup() => Configuration = new ConfigurationBuilder().AddUserSecrets<Startup>().Build();

        public void ConfigureServices(IServiceCollection services)
        {
            // Example of a data service
            services.AddSingleton<WeatherForecastService>();

            var connection = Configuration["ConnectionStrings:NorthwindDB"];
            var options = new DbContextOptionsBuilder<NorthwindContext>()
                                .UseSqlServer(connection)
                                .Options;
            services.AddSingleton(new NorthwindContext(options));

            services.AddKendoBlazor();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
