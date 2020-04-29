using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace export_to_xlsx_hierarchy.Helpers
{
    public static class ExtensionHelper
    {
        public static IEnumerable<string> PropertiesFromType<T>(this IEnumerable<T> input)
        {
            var properties = new List<string>();
            var item = input.FirstOrDefault();
            
            foreach (PropertyInfo property in item?.GetType().GetProperties())
            {
                properties.Add(property.Name);
            }

            return properties;
        }
    }
}