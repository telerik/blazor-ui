using CustomSerializer.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Telerik.DataSource;
using Telerik.DataSource.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CustomSerializer.Server.Controllers
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
        private static List<WeatherForecast> _forecasts { get; set; }

        [HttpPost]
        public async Task<DataEnvelope<WeatherForecast>> Post([FromBody] DataSourceRequest request)
        {
            // generate some data for the sake of this demo
            if (_forecasts == null)
            {
                var rng = new Random();
                var startDate = DateTime.Now.Date;
                _forecasts = Enumerable.Range(1, 150).Select(index => new WeatherForecast
                {
                    Id = index,
                    Date = startDate.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                }).ToList();
            }

            IQueryable<WeatherForecast> queriableData = _forecasts.AsQueryable();

            DataSourceResult processedData = await queriableData.ToDataSourceResultAsync(request);

            DataEnvelope<WeatherForecast> dataToReturn = new DataEnvelope<WeatherForecast>
            {
                CurrentPageData = processedData.Data as List<WeatherForecast>,
                TotalItemCount = processedData.Total
            };

            return dataToReturn;
        }

        // for brevity, CUD operations are not implemented, only Read
    }
}
