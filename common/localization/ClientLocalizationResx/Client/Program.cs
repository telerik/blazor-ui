using Microsoft.AspNetCore.Blazor.Hosting;

namespace ClientLocalizationResx.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // in this sample, we set the culture that way, change it to fr-FR or something else (or remove entirely) to test
            var desiredCulture = new System.Globalization.CultureInfo("fr-FR");
            System.Globalization.CultureInfo.CurrentUICulture = desiredCulture;
            System.Globalization.CultureInfo.CurrentCulture = desiredCulture;

            CreateHostBuilder(args).Build().Run();
        }

        public static IWebAssemblyHostBuilder CreateHostBuilder(string[] args) =>
            BlazorWebAssemblyHost.CreateDefaultBuilder()
                .UseBlazorStartup<Startup>();
    }
}
