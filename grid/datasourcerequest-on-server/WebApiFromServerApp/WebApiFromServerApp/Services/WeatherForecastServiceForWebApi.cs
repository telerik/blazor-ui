using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Telerik.DataSource;
using WebApiFromServerApp.SharedClasses;

namespace WebApiFromServerApp.Services
{
    public class WeatherForecastServiceForWebApi
    {
        private readonly IHttpClientFactory _clientFactory;

        // the URL and port match the web api project settings (launchSettings.json)
        // make sure to configure that properly for your app
        private static string _baseUrl = "https://localhost:44326/WeatherForecast/";

        public WeatherForecastServiceForWebApi(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<DataEnvelope<WeatherForecast>> GetData(DataSourceRequest dsRequest, string actionSuffix)
        {
            string content = JsonSerializer.Serialize(
                dsRequest//, // if serialization does not work as expected, start by adding this and also see the Startup.cs of the webAPI project - the goal is to have the same serialization settings on both ends so serialization can work
                //new JsonSerializerOptions()
                //{
                //    PropertyNameCaseInsensitive = true
                //}
            );

            var request = new HttpRequestMessage(HttpMethod.Post, actionSuffix);
            request.Headers.Add("Accept", "*/*");
            request.Content = new StringContent(content, Encoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri(_baseUrl);

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();

                DataEnvelope<WeatherForecast> data =
                    JsonSerializer.Deserialize<DataEnvelope<WeatherForecast>>(
                        responseString,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                        //the deserialization options are important because the framework cannot properly deserialize
                        //the object names - they come back as camelCase instead of PascalCase
                    );

                return data;
            }

            throw new Exception($"The service returned with status {response.StatusCode}");
        }
    }
}
