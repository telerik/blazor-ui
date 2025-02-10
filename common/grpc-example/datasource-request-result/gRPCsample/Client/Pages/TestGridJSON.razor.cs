using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using gRPCsample.Shared;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor.Components;
using Telerik.DataSource;

namespace gRPCsample.Client.Pages
{
    public partial class TestGridJSON
    {
        #region Properties

        [Inject] public HttpClient Http { get; set; }

        #endregion

        #region Grid

        #region Read

        private async Task ReadHandler(GridReadEventArgs args)
        {
            try
            {
                DataEnvelope<TestGridJSONModel> result = await GetTestDataAsync(args.Request);

                if (args.Request.Groups.Count > 0)
                {
                    var data = GroupDataHelpers.DeserializeGroups<TestGridJSONModel>(result.GroupedData);
                    args.Data = data.ToList();
                }
                else
                {
                    args.Data = result.CurrentPageData.ToList();
                }

                args.Total = result.TotalItemCount;
            }
            catch (Exception ex)
            {
                // Show Error message
            }
        }

        private async Task<DataEnvelope<TestGridJSONModel>> GetTestDataAsync(DataSourceRequest gridRequest)
        {
            HttpResponseMessage response = await Http.PostAsJsonAsync("TestGridJSON", gridRequest);
            // make sure to use the System.Text.Json serializer
            // e.g., JsonSerializer.Serialize(gridRequest) for the second argument if you have some other implementations
            // and that its serialization options match the server serialization options (see the readme)
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<DataEnvelope<TestGridJSONModel>>();
            }

            throw new Exception($"The service returned with status {response.StatusCode}");
        }

        #endregion

        #endregion
    }
}
