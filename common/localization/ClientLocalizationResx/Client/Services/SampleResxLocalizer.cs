using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Telerik.Blazor.Services;

namespace ClientLocalizationResx.Client.Services
{
    public class SampleResxLocalizer : ITelerikStringLocalizer
    {
        // this is the indexer you must implement
        public string this[string name]
        {
            get
            {
                return GetStringFromResource(name);
            }
        }

        private static readonly string BaseLocalizationType = "ClientLocalizationResx.Shared.Translations.TelerikMessages";
        private static string CurrLocalizationType { get; set; }
        private static Assembly SharedAssembly { get; set; }
        private static object LocalizationClassInstance { get; set; }
        private void EnsureInstance()
        {
            if (SharedAssembly == null || LocalizationClassInstance == null)
            {
                CurrLocalizationType = BaseLocalizationType;
                // in this sample, only fr-FR and bg-BG strings are available
                if (Thread.CurrentThread.CurrentUICulture.Name == "fr-FR" || Thread.CurrentThread.CurrentUICulture.Name == "bg-BG")
                {
                    // this is the name of the class that is generated from the resx files
                    CurrLocalizationType += $"_{Thread.CurrentThread.CurrentUICulture.Name.Replace("-", "_")}";
                }

                Type LocalizationType = Type.GetType(CurrLocalizationType + ", ClientLocalizationResx.Shared");
                Type FullyQualifiedName = Type.GetType(LocalizationType.AssemblyQualifiedName);
                SharedAssembly = Assembly.GetAssembly(FullyQualifiedName);
                LocalizationClassInstance = Activator.CreateInstance(LocalizationType);
            }
        }

        // sample implementation - uses reflection to get the static fields generated from the resx files.
        // can be improved and refactored - at the moment it does some basic singleton-like caching
        public string GetStringFromResource(string key)
        {
            EnsureInstance();

            string result = SharedAssembly.GetType(CurrLocalizationType).GetProperty(key).GetValue(LocalizationClassInstance, null) as string;

            return result;
        }
    }
}
