using BlazorFinancialDashboard.Resources;
using Telerik.Blazor.Services;

namespace BlazorFinancialDashboard.Services
{
    public class ResxLocalizer : ITelerikStringLocalizer
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
            return TelerikMessages.ResourceManager.GetString(key, TelerikMessages.Culture) ?? string.Empty;
        }
    }
}
