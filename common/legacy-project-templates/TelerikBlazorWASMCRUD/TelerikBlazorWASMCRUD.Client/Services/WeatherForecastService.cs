using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TelerikBlazorWASMCRUD.Shared;

namespace TelerikBlazorWASMCRUD.Services
{
    public class WeatherForecastService
    {
        [Inject]
        private HttpClient Http { get; set; }

        public WeatherForecastService(HttpClient client)
        {
            Http = client;
        }

        public async Task<List<WeatherForecast>> GetForecastListAsync(DateTime startDate)
        {
            var data = await Http.GetFromJsonAsync<List<WeatherForecast>>("WeatherForecast?startDate=" + startDate.ToString(CultureInfo.InvariantCulture));
            return data ?? new List<WeatherForecast>();
        }

        public async Task UpdateForecastAsync(WeatherForecast forecastToUpdate)
        {
            await Http.PostAsJsonAsync("WeatherForecast", forecastToUpdate);
        }

        public async Task DeleteForecastAsync(WeatherForecast forecastToRemove)
        {
            await Http.DeleteAsync("WeatherForecast?idToRemove=" + forecastToRemove.Id);
        }

        public async Task InsertForecastAsync(WeatherForecast forecastToInsert)
        {
            await Http.PutAsJsonAsync("WeatherForecast", forecastToInsert);
        }
    }
}
