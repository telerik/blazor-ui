using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServerPdfExport.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telerik.DataSource;
using Telerik.DataSource.Extensions;

namespace ServerPdfExport.Server.Controllers
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
        public async Task<DataEnvelope<WeatherForecast>> Post([FromBody] DataSourceRequest gridRequest)
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
                }).ToList();
            }

            // we will cast the data to an IQueriable to simulate an actual database (EF) service
            // in a real case, you would be fetching the data from the service, not generating it here
            IQueryable<WeatherForecast> queriableData = _forecasts.AsQueryable();


            // use the Telerik DataSource Extensions to perform the query on the data
            // the Telerik extension methods can also work on "regular" collections like List<T> and IQueriable<T>
            DataSourceResult processedData = await queriableData.ToDataSourceResultAsync(gridRequest);


            DataEnvelope<WeatherForecast> dataToReturn = new DataEnvelope<WeatherForecast>
            {
                CurrentPageData = processedData.Data.Cast<WeatherForecast>().ToList(),
                TotalItemCount = processedData.Total
            };

            return dataToReturn;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 500).Select(index => new WeatherForecast
            {
                Id = index,
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
