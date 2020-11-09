using LazyLoadTelerikComponents.Shared.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Telerik.Blazor.Services;

namespace LazyLoadTelerikComponents.Shared.Services
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
