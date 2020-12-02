using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PdfExport;
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
    public class ExportPdfController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> logger;

        private WeatherForecastDataService MyDataService { get; set; }

        public ExportPdfController(ILogger<WeatherForecastController> logger, WeatherForecastDataService dataService)
        {
            this.logger = logger;
            MyDataService = dataService;
        }

        [HttpPost]
        public async Task<string> Post([FromBody] DataSourceRequest gridRequest)
        {
            IQueryable<WeatherForecast> queriableData = await MyDataService.GetForecasts();

            var spreadExporter = new RadSpreadProcessingExporter();

            byte[] fileData = await spreadExporter.ExportPdf(queriableData, gridRequest);
            string base64File = Convert.ToBase64String(fileData);
             System.IO.File.WriteAllBytes("C:\\temp\\test.pdf", fileData);

            return await Task.FromResult(base64File);
        }
    }
}
