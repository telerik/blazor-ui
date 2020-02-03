using ClientLocalizationResx.Client.Services;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Telerik.Blazor.Services;

namespace ClientLocalizationResx.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // in this sample, we set the culture that way, change it to fr-FR or something else (or remove entirely) to test
            var desiredCulture = new System.Globalization.CultureInfo("fr-FR");
            System.Globalization.CultureInfo.CurrentUICulture = desiredCulture;
            System.Globalization.CultureInfo.CurrentCulture = desiredCulture;

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTelerikBlazor();

            // register a custom localizer for the Telerik components, after registering the Telerik services
            builder.Services.AddSingleton(typeof(ITelerikStringLocalizer), typeof(SampleResxLocalizer));

            await builder.Build().RunAsync();
        }
    }
}
