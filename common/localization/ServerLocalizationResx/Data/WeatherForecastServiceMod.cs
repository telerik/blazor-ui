using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerLocalizationResx.Data
{
    public class WeatherForecastServiceMod
    {
        public static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<List<WeatherForecast>> GetForecastAsync()
        {
            return GetForecastAsync(30);
        }

        public Task<List<WeatherForecast>> GetForecastAsync(int count)
        {
            var rng = new Random();

            return Task.FromResult(Enumerable.Range(1, count).Select(index => GenerateForecast(index)).ToList());
        }

        public WeatherForecast GenerateForecast(int index)
        {
            var rng = new Random();
            return new WeatherForecast
            {
                Id = index,
                Date = DateTime.Now.AddDays(rng.Next(-10, 10)).Date,
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            };
        }

        public WeatherForecast GenerateForecast()
        {
            var rng = new Random();
            return new WeatherForecast
            {
                Date = DateTime.Now.AddDays(rng.Next(-10, 10)),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            };
        }
    }
}
