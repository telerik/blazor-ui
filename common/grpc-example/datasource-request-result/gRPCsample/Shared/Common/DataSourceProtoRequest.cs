using System.Text.Json;
using Telerik.DataSource;

namespace gRPCsample.Shared
{
    /// <summary>
    /// The helper function to serialise and de-serialise the DataSourceRequest
    /// </summary>
    public partial class DataSourceProtoRequest
    {
        public DataSourceProtoRequest(DataSourceRequest dataSourceRequest)
        {
            DataSourceRequestJson = JsonSerializer.Serialize(dataSourceRequest);
        }

        public DataSourceRequest FromProto()
        {
            return JsonSerializer.Deserialize<DataSourceRequest>(DataSourceRequestJson);
        }
    }
}
