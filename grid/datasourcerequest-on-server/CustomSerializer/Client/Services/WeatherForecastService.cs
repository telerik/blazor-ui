using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Telerik.DataSource;
using Newtonsoft.Json.Serialization;
using System.Text.Json;
using CustomSerializer.Shared;

namespace CustomSerializer.Client.Services
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
            // in this sample the Blazor app uses the System.Text.Json serializer and deserializer
            // and the server-side API can handle that through a custom converter for Newtsonsoft
            // you can choose to carry a newtonsoft package to the Blazor app and use that instead,
            // just make sure that serialization and deserialization both work correctly
            HttpResponseMessage response = await Http.PostAsJsonAsync("WeatherForecast", gridRequest);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<DataEnvelope<WeatherForecast>>();
            }

            throw new Exception($"The service returned with status {response.StatusCode}");
        }

        // for brevity, CUD operations are not implemented, only Read
    }
}
