using gRPCsample.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telerik.DataSource;

namespace gRPCsample.Client.Helpers
{
    public delegate IEnumerable<object> DataListModelCallBack(DataGroupModel dataGroupModel);

    /// <summary>
    /// Helper class to create the grouped Grid data
    /// </summary>
    public class GridHelper
    {
        public static List<AggregateFunctionsGroup> GetGroupedData(List<DataGroupModel> subGroups, DataListModelCallBack callBack)
        {
            List<AggregateFunctionsGroup> groups = new List<AggregateFunctionsGroup>();

            foreach (var subGroup in subGroups)
            {
                AggregateFunctionsGroup group = new AggregateFunctionsGroup()
                {
                    HasSubgroups = subGroup.SubGroups.Count > 0,
                    ItemCount = subGroup.GridGroupModel.ItemCount,
                    Key = subGroup.GridGroupModel.Key,
                    Member = subGroup.GridGroupModel.Member,
                    Items = callBack(subGroup),
                };

                if (subGroup.SubGroups.Count > 0)
                    group.Items = GetGroupedData(subGroup.SubGroups.ToList(), callBack);

                groups.Add(group);
            }

            return groups;
        }
    }
}
