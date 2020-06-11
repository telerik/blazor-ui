﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WasmApp.Shared;
using Microsoft.AspNetCore.Components;
// these two using statements provide the data source operations
using Telerik.DataSource;
using Telerik.DataSource.Extensions;
using System.Text.Json;
using System.Net.Http.Json;

namespace WasmApp.Services
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

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<DataEnvelope<WeatherForecast>>();
            }

            throw new Exception($"The service returned with status {response.StatusCode}");
        }

        // for brevity, CUD operations are not implemented, only Read
    }
}