using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerApp.Models;
// these two using statements provide the data source operations
using Telerik.DataSource;
using Telerik.DataSource.Extensions;

namespace ServerApp.Services
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

        private List<WeatherForecast> _forecasts { get; set; }

        public async Task<DataSourceResult> GetForecastListAsync(DataSourceRequest gridRequest)
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
            DataSourceResult dataToReturn = await queriableData.ToDataSourceResultAsync(gridRequest);

            return dataToReturn;
        }

        // for brevity, CUD operations are not implemented, only Read
    }
}
