using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelerikBlazorServerCRUD.Models;

namespace TelerikBlazorServerCRUD.Services
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private List<WeatherForecast>? _forecasts { get; set; }

        public Task<List<WeatherForecast>> GetForecastListAsync(DateTime startDate)
        {
            if (_forecasts == null)
            {
                var rng = new Random();
                _forecasts = Enumerable.Range(1, 150).Select(index => new WeatherForecast
                {
                    Id = index,
                    Date = startDate.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                }).ToList();
            }

            // detach the View data from the service for this example by creating a new pointer
            List<WeatherForecast> cloneForTemplate = new List<WeatherForecast>(_forecasts);
            return Task.FromResult<List<WeatherForecast>>(cloneForTemplate);
        }

        public async Task UpdateForecastAsync(WeatherForecast forecastToUpdate)
        {
            //implement proper error handling here, and then actual data source operations
            if (_forecasts == null)
            {
                return;
            }

            var index = _forecasts.FindIndex(i => i.Id == forecastToUpdate.Id);
            if (index != -1)
            {
                await Task.Run(() => { _forecasts[index] = forecastToUpdate; });
            }
        }

        public async Task DeleteForecastAsync(WeatherForecast forecastToRemove)
        {
            if (_forecasts == null) return;
            //implement proper error handling here, and then actual data source operations

            await Task.Run(() => { _forecasts.Remove(forecastToRemove); });
        }

        public async Task InsertForecastAsync(WeatherForecast forecastToInsert)
        {
            //implement proper error handling here, and then actual data source operations
            if (_forecasts == null)
            {
                return;
            }

            WeatherForecast insertedForecast = new WeatherForecast()
            {
                Id = _forecasts.Count + 1,
                Date = forecastToInsert.Date,
                TemperatureC = forecastToInsert.TemperatureC,
                Summary = forecastToInsert.Summary
            };

            await Task.Run(() => { _forecasts.Insert(0, insertedForecast); });
        }
    }
}
