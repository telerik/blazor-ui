using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Telerik.DataSource;

namespace WasmApp.Shared
{
    public static class GroupDataHelpers
    {
        /// <summary>
        /// Used to deserialize the grouped data descriptor in this sample.
        /// </summary>
        public static List<AggregateFunctionsGroup> DeserializeGroups<TGroupItem>(List<AggregateFunctionsGroup> groups)
        {
            if (groups != null)
            {
                for (int i = 0; i < groups.Count; i++)
                {
                    var group = groups[i];
                    var groupItems = group.Items.Cast<JsonElement>().ToList();

                    if (group.HasSubgroups)
                    {
                        var deserializedItems = groupItems
                            .Select(x => x.Deserialize<AggregateFunctionsGroup>(new JsonSerializerOptions()
                            {
                                PropertyNameCaseInsensitive = true
                            }))
                            .ToList();

                        var items = deserializedItems.Cast<AggregateFunctionsGroup>().ToList();
                        var subgroups = DeserializeGroups<TGroupItem>(items);
                        group.Items = subgroups;
                    }
                    else
                    {
                        var deserializedItems = groupItems
                            .Select(x => x.Deserialize<TGroupItem>(new JsonSerializerOptions()
                            {
                                PropertyNameCaseInsensitive = true
                            }))
                            .ToList();

                        group.Items = deserializedItems;
                    }
                }
            }

            return groups;
        }
    }
}
