using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PopupControl.Data
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private List<WeatherForecast> Forecasts { get; set; } = new List<WeatherForecast>();

        public WeatherForecastService()
        {
            var rng = new Random();
            this.Forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Id = index,
                Date = DateTime.Today.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToList();
        }

        public Task<List<WeatherForecast>> GetForecastAsync()
        {
            return Task.FromResult(this.Forecasts);
        }

        public Task<WeatherForecast> GetLastForecastAsync()
        {
            return Task.FromResult(this.Forecasts.OrderByDescending(o => o.Id).First());
        }

        public Task<WeatherForecast> GetForecastAsync(int id)
        {
            return Task.FromResult(this.Forecasts.Where(o => o.Id == id).FirstOrDefault());
        }

        public void AddForecast(WeatherForecast forecast)
        {
            this.Forecasts.Add(forecast);
        }
    }
}
