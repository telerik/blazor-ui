using Telerik.Blazor.Services;
using ClientLocalizationResx.Shared.Resources;

namespace ClientLocalizationResx.Shared.Services
{
    public class SampleResxLocalizer : ITelerikStringLocalizer
    {
        public string this[string name]
        {
            get
            {
                return GetStringFromResource(name);
            }
        }

        public string GetStringFromResource(string key)
        {
            return TelerikMessages.ResourceManager.GetString(key, TelerikMessages.Culture);
        }
    }
}
