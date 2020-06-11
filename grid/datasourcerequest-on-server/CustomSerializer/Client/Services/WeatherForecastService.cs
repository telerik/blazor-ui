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
            HttpResponseMessage response = await Http.PostAsJsonAsync(
                "WeatherForecast", gridRequest);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {

                return await response.Content.ReadFromJsonAsync<DataEnvelope<WeatherForecast>>();

                ///////remnants of attempts to deserialize the entire datasourceresult


                //string responseData = await response.Content.ReadAsStringAsync();
                //try
                //{
                //    DefaultContractResolver contractResolver = new DefaultContractResolver
                //    {
                //        NamingStrategy = new CamelCaseNamingStrategy()
                //    };

                //    DataSourceResult result = JsonConvert.DeserializeObject<DataSourceResult>(responseData, 
                //        new JsonSerializerSettings
                //        {
                //            ContractResolver = new DefaultContractResolver(),//contractResolver,
                //           // Formatting = Formatting.Indented
                           
                //        });

                //   // JsonConvert.DeserializeObject<DataSourceResult>(responseData, )

                //    return await Task.FromResult(result);
                //}
                //catch (Exception ex)
                //{
                //    throw ex;
                //}

            }

            throw new Exception($"The service returned with status {response.StatusCode}");
        }

        // for brevity, CUD operations are not implemented, only Read
    }
}
