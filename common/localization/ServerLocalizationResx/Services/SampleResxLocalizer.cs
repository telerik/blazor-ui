using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telerik.Blazor.Services;

namespace ServerLocalizationResx.Services
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

        // sample implementation - uses .resx files in the ~/Resources folder names TelerikMessages.<culture-locale>.resx
        public string GetStringFromResource(string key)
        {
            try
            {
                return Resources.TelerikMessages.ResourceManager.GetString(key, Resources.TelerikMessages.Culture);
            }
            catch (Exception ex)//something failed (like a missing resource key or something else, this is a sample fail-safe
            {
                return key;
            }
        }
    }
}
