using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Telerik.DataSource;
using Telerik.Blazor.ExtensionMethods;
using System.Net.Http;
using System.Text.Json;

namespace ServerApp.Data
{
    public class ODataOrdersService
    {
        private IHttpClientFactory _clientFactory { get; set; }

        public ODataOrdersService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<ODataOrdersResponse> GetOrders(DataSourceRequest request)
        {
            var baseUrl = "https://demos.telerik.com/kendo-ui/service-v4/odata/Orders?";

            var requestUrl = $"{baseUrl}{request.ToODataString()}";

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            requestMessage.Headers.Add("Accept", "application/json");
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(requestMessage);
            if (response.IsSuccessStatusCode)
            {
                string body = await response.Content.ReadAsStringAsync();
                ODataOrdersResponse oDataResponse = JsonSerializer.Deserialize<ODataOrdersResponse>(body);
                return oDataResponse;
            }
            else
            {
                throw new HttpRequestException("Request failed. I need better error handling, e.g., returning empty data");
            }
        }
    }
}
