using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using ClientLocalizationResx.Client.Services;
using Telerik.Blazor.Services;

namespace ClientLocalizationResx.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTelerikBlazor();
            // register a custom localizer for the Telerik components, after registering the Telerik services
            services.AddSingleton(typeof(ITelerikStringLocalizer), typeof(SampleResxLocalizer));
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
