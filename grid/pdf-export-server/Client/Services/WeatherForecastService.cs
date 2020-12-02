using Microsoft.AspNetCore.Components;
using ServerPdfExport.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Telerik.DataSource;

namespace ServerPdfExport.Client.Services
{
    public class WeatherForecastService
    {
        [Inject]
        private HttpClient Http { get; set; }

        public WeatherForecastService(HttpClient client)
        {
            Http = client;
        }

        public async Task<DataEnvelope<WeatherForecast>> GetForecastListAsync(DataSourceRequest gridRequest)
        {

            HttpResponseMessage response = await Http.PostAsJsonAsync("WeatherForecast", gridRequest);
            // make sure to use the System.Text.Json serializer
            // e.g., JsonSerializer.Serialize(gridRequest) for the second argument if you have some other implementations
            // and that its serialization options match the server serialization options (see the readme)

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<DataEnvelope<WeatherForecast>>();
            }

            throw new Exception($"The service returned with status {response.StatusCode}");
        }
    }
}
