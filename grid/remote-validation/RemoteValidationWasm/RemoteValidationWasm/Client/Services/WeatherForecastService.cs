using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using RemoteValidationWasm.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace RemoteValidationWasm.Services
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
            return data;
        }
        public async Task DeleteForecastAsync(WeatherForecast forecastToRemove)
        {
            HttpResponseMessage response = await Http.DeleteAsync("WeatherForecast?idToRemove=" + forecastToRemove.Id);
            string body = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(body);
            }
        }

        // Updates and Inserts return the newly updated item from the server in case it changes it further
        // this is returned to the view to update the view-model with that data
        // the service "handles" errors from the server to provide a more unified experience for the view
        // in this example it just returns the error message from the body - the controller returns plain exceptions

        public async Task<WeatherForecast> UpdateForecastAsync(WeatherForecast forecastToUpdate)
        {
            HttpResponseMessage response = await Http.PostAsJsonAsync("WeatherForecast", forecastToUpdate);
            return await ReturnDataFromHttpCall(response);
        }

        public async Task<WeatherForecast> InsertForecastAsync(WeatherForecast forecastToInsert)
        {
            HttpResponseMessage response = await Http.PutAsJsonAsync("WeatherForecast", forecastToInsert);
            return await ReturnDataFromHttpCall(response);
        }

        private async Task<WeatherForecast> ReturnDataFromHttpCall(HttpResponseMessage response)
        {
            string body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                WeatherForecast insertedForecast = JsonSerializer.Deserialize<WeatherForecast>(
                    body,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return insertedForecast;
            }
            else
            {
                throw new Exception(body);
            }

            // one way to simplify the component code error handling - always throw an exception to show errors in the UI
            throw new NullReferenceException("no updated data returned from the server, try again");
        }
    }
}