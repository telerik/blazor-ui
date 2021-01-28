using System;
using System.Collections.Generic;
using Telerik.DataSource;
using Telerik.DataSource.Extensions;

namespace Loccioni.DataSource
{
    public class GridDescriptorSerializer
    {
        private const string ColumnDelimiter = "~";

        public static IList<T> Deserialize<T>(string from) where T : IDescriptor, new()
        {
            var result = new List<T>();

            if (!from.HasValue())
            {
                return result;
            }

            var components = from.Split(ColumnDelimiter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (string component in components)
            {
                var descriptor = new T();

                descriptor.Deserialize(component);

                result.Add(descriptor);
            }

            return result;
        }
    }

}
