using Microsoft.AspNetCore.Blazor.Builder;
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
            // Since Blazor is running on the server, we can use an application service
            // to read the forecast data.
            services.AddSingleton<WeatherForecastService>();

            var connection = Configuration["ConnectionStrings:NorthwindDB"];
            var options = new DbContextOptionsBuilder<NorthwindContext>()
                                .UseSqlServer(connection)
                                .Options;
            services.AddSingleton(new NorthwindContext(options));
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
