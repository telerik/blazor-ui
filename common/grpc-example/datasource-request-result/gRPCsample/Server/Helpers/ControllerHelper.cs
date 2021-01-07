using gRPCsample.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telerik.DataSource;

namespace gRPCsample.Server.Helpers
{
    public delegate void DataGroupModelCallBack(object records, DataGroupModel dataGroupModel);

    /// <summary>
    /// This is the helper that converts the DataSource result to the Protobuf object.
    /// It is required if grouping is being used.
    /// </summary>
    public class ControllerHelper
    {
        public static void ConvertDataSourceResult(DataListResponse response, DataSourceResult dataSourceResult, DataGroupModelCallBack callBack)
        {
            response.GridData = new DataGroupModel();
            if (dataSourceResult.Data is List<AggregateFunctionsGroup>)
            {
                // Process the grouped Data
                response.GridData.SubGroups.AddRange(AddFunctionsGroup(dataSourceResult.Data, callBack));
                response.Result.TotalRecords = dataSourceResult.Total;
            }
            else
            {
                // Process the flat item list
                callBack(dataSourceResult.Data, response.GridData);
                response.GridData.GridGroupModel = new TelerikGroupModel()
                {
                    ItemCount = dataSourceResult.Total,
                    Member = string.Empty
                };

                response.Result.TotalRecords = dataSourceResult.Total;
            }
        }

        private static List<DataGroupModel> AddFunctionsGroup(System.Collections.IEnumerable groups, DataGroupModelCallBack callBack)
        {
            var groupModelList = new List<DataGroupModel>();

            foreach (AggregateFunctionsGroup group in groups)
            {
                DataGroupModel groupModel = new DataGroupModel()
                {
                    GridGroupModel = CreateTelerikGroupModel(group)
                };

                if (group.HasSubgroups)
                    groupModel.SubGroups.AddRange(AddFunctionsGroup(group.Items, callBack));
                else
                    callBack(group.Items, groupModel);

                groupModelList.Add(groupModel);
            }

            return groupModelList;
        }

        private static TelerikGroupModel CreateTelerikGroupModel(AggregateFunctionsGroup group)
        {
            return new TelerikGroupModel()
            {
                ItemCount = group.ItemCount,
                Key = group.Key?.ToString(),
                Member = group.Member
            };
        }
    }
}
