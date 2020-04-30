using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Telerik.DataSource;
using Telerik.DataSource.Extensions;
using WebApiFromServerApp.SharedClasses;

namespace SampleWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private static List<WeatherForecast> _forecasts { get; set; }

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("customreturn")]
        public async Task<DataEnvelope<WeatherForecast>> CustomObjectReturn([FromBody]DataSourceRequest gridRequest)
        {
            // generate some data for the sake of this demo
            GenerateForecasts();

            // we will cast the data to an IQueriable to simulate an actual database (EF) service
            // in a real case, you would be fetching the data from the service, not generating it here
            IQueryable<WeatherForecast> queriableData = _forecasts.AsQueryable();

            // deserialize the DataSourceRequest from the HTTP query
            // make sure to use the System.Text.Json serializer
            //DataSourceRequest gridRequest = JsonSerializer.Deserialize<DataSourceRequest>(dsRequest);

            // use the Telerik DataSource Extensions to perform the query on the data
            // the Telerik extension methods can also work on "regular" collections like List<T> and IQueriable<T>
            DataSourceResult processedData = await queriableData.ToDataSourceResultAsync(gridRequest);

            // We now need to make this deserializable because the framework cannot deserialize IEnumerable
            // So we will use an envelope class that will contain the exact type of the data items instead of DataSourceResult directly
            // This is required as System.Text.Json cannot successfully deserialize interface properties
            DataEnvelope<WeatherForecast> dataToReturn = new DataEnvelope<WeatherForecast>
            {
                CurrentPageData = processedData.Data as List<WeatherForecast>,
                TotalItemCount = processedData.Total
            };

            return dataToReturn;
        }

        [HttpPost]
        [Route("actionresultsample")]
        public async Task<IActionResult> ActionResultReturn([FromBody]DataSourceRequest request)
        {
            GenerateForecasts();

            DataSourceResult result = await _forecasts.ToDataSourceResultAsync(request);

            // We now need to make this deserializable because the framework cannot deserialize IEnumerable
            // So we will use an envelope class that will contain the exact type of the data items instead of DataSourceResult directly
            // This is required as System.Text.Json cannot successfully deserialize interface properties
            DataEnvelope<WeatherForecast> dataToReturn = new DataEnvelope<WeatherForecast>
            {
                CurrentPageData = result.Data as List<WeatherForecast>,
                TotalItemCount = result.Total
            };

            return Ok(dataToReturn);
        }


        void GenerateForecasts()
        {
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
        }
    }
}
