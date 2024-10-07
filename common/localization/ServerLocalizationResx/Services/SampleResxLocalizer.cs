using ServerLocalizationResx.Resources;
using Telerik.Blazor.Services;

namespace ServerLocalizationResx.Services
{
    public class SampleResxLocalizer : ITelerikStringLocalizer
    {
        // This indexer is required
        public string this[string name]
        {
            get
            {
                return GetStringFromResource(name);
            }
        }

        // Sample implementation that uses .resx files in ~/Resources named TelerikMessages.<culture-locale>.resx
        public string GetStringFromResource(string key)
        {
            return TelerikMessages.ResourceManager.GetString(key, TelerikMessages.Culture) ?? key;
        }
    }
}
