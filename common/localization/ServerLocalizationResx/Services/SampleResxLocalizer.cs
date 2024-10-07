using ServerLocalizationResx.Resources;
using Telerik.Blazor.Services;

namespace ServerLocalizationResx.Services
{
    public class SampleResxLocalizer : ITelerikStringLocalizer
    {
        // This indexer is required
        public string this[string key]
        {
            get
            {
                return TelerikMessages.ResourceManager.GetString(key, TelerikMessages.Culture) ?? key;
            }
        }
    }
}
