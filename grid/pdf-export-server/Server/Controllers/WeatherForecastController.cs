using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServerPdfExport.Server.Services;
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
        private readonly ILogger<WeatherForecastController> logger;
        private WeatherForecastDataService MyDataService { get; set; }

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherForecastDataService dataService)
        {
            this.logger = logger;
            this.MyDataService = dataService;
        }

        [HttpPost]
        public async Task<DataEnvelope<WeatherForecast>> Post([FromBody] DataSourceRequest gridRequest)
        {
            IQueryable<WeatherForecast> queriableData = await MyDataService.GetForecasts();
            DataSourceResult processedData = await queriableData.ToDataSourceResultAsync(gridRequest);
            DataEnvelope<WeatherForecast> dataToReturn = new DataEnvelope<WeatherForecast>
            {
                CurrentPageData = processedData.Data.Cast<WeatherForecast>().ToList(),
                TotalItemCount = processedData.Total
            };

            return dataToReturn;
        }
    }
}
