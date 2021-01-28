using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.DataSource;
using Telerik.DataSource.Extensions;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/weatherforecast")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //DataSourceRequest is correctly binded usind DataSourceRequestBinder (configured during startup phase)

        [HttpGet]
        public DataSourceResult  Get(DataSourceRequest request)
        {
            // High records number to simulate pagination from data source extension
            return Enumerable.Range(1, 1000).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.Date.AddDays(index),
                Temp = index,
            })
            .ToDataSourceResult(request);
        }
    }
}
