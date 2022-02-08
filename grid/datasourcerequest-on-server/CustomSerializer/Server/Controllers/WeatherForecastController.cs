using CustomSerializer.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Telerik.DataSource;
using Telerik.DataSource.Extensions;

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

            // we will cast the data to an IQueriable to simulate an actual database (EF) service
            // in a real case, you would be fetching the data from the service, not generating it here
            IQueryable<WeatherForecast> queriableData = _forecasts.AsQueryable();


            // use the Telerik DataSource Extensions to perform the query on the data
            // the Telerik extension methods can also work on "regular" collections like List<T> and IQueriable<T>
            DataSourceResult processedData = await queriableData.ToDataSourceResultAsync(request);

            DataEnvelope<WeatherForecast> dataToReturn;

            if (request.Groups.Count > 0)
            {
                // If there is grouping, use the field for grouped data
                // The app must be able to serialize and deserialize it
                // Example helper methods for this are available in this project
                // See the GroupDataHelper.DeserializeGroups and JsonExtensions.Deserialize methods
                dataToReturn = new DataEnvelope<WeatherForecast>
                {
                    GroupedData = processedData.Data.Cast<AggregateFunctionsGroup>().ToList(),
                    TotalItemCount = processedData.Total
                };
            }
            else
            {
                // When there is no grouping, the simplistic approach of 
                // just serializing and deserializing the flat data is enough
                dataToReturn = new DataEnvelope<WeatherForecast>
                {
                    CurrentPageData = processedData.Data.Cast<WeatherForecast>().ToList(),
                    TotalItemCount = processedData.Total
                };
            }

            return dataToReturn;
        }

        // for brevity, CUD operations are not implemented, only Read
    }
}
