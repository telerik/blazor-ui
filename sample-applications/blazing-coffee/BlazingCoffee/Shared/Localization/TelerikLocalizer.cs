using BlazingCoffee.Shared.Resources;
using Microsoft.Extensions.Localization;
using Telerik.Blazor.Services;

namespace BlazingCoffee.Shared.Localization
{
    public class TelerikLocalizer : ITelerikStringLocalizer
    {
        private readonly IStringLocalizer<Global> globalLocalizer;

        public TelerikLocalizer(IStringLocalizer<Global> globalLocalizer)
        {
            this.globalLocalizer = globalLocalizer;
        }

        public string this[string name] => GetStringFromResource(name);

        public string GetStringFromResource(string key)
        {
            var localString = TelerikMessages.ResourceManager.GetString(key, TelerikMessages.Culture);
            if (string.IsNullOrWhiteSpace(localString))
            {
                return globalLocalizer.GetString(key);
            }
            return localString;
        }
    }
}
