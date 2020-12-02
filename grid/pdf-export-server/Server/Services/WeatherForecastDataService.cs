using ServerPdfExport.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPdfExport.Server.Services
{
    public class WeatherForecastDataService
    {
        private static readonly string[] Summaries = new[]
      {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        // this static list acts as our "database" in this sample
        private static IQueryable<WeatherForecast> _forecasts { get; set; }

        public async Task<IQueryable<WeatherForecast>> GetForecasts()
        {
            // generate some data for the sake of this demo
            if (_forecasts == null)
            {
                var rng = new Random();
                var startDate = DateTime.Now.Date;
                _forecasts = Enumerable.Range(1, 500).Select(index => new WeatherForecast
                {
                    Id = index,
                    Date = startDate.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                }).AsQueryable();
            }

            return await Task.FromResult(_forecasts);
        }
    }
}
