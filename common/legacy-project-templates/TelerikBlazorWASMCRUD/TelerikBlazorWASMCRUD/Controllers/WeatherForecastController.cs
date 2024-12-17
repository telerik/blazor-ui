using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelerikBlazorWASMCRUD.Shared;

namespace TelerikBlazorWASMCRUD.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            this.logger = logger;
        }

        // this static list acts as our "database" in this sample
        private static List<WeatherForecast>? _forecasts { get; set; }

        [HttpGet]
        public Task<List<WeatherForecast>> Get([FromQuery] DateTime startDate)
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

            return Task.FromResult(_forecasts);
        }

        [HttpPost]
        public async Task Update(WeatherForecast forecastToUpdate)
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

        [HttpDelete]
        public async Task Delete(int idToRemove)
        {
            //implement proper error handling here, and then actual data source operations
            if (_forecasts == null)
            {
                return;
            }

            WeatherForecast forecastToDelete = _forecasts.Where(f => f.Id == idToRemove).First();
            if (forecastToDelete != null)
            {
                await Task.Run(() => { _forecasts.Remove(forecastToDelete); });
            }
        }

        [HttpPut]
        public async Task Put(WeatherForecast forecastToInsert)
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