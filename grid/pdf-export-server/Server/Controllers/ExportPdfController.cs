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
        [Route("Direct")]
        public async Task<string> PdfOnly([FromBody] DataSourceRequest gridRequest)
        {
            string base64File = await GenerateFile(false, gridRequest);

            return await Task.FromResult(base64File);
        }

        [HttpPost]
        [Route("FromExcel")]
        public async Task<string> FromExcel([FromBody] DataSourceRequest gridRequest)
        {
            string base64File = await GenerateFile(true, gridRequest);

            return await Task.FromResult(base64File);
        }

        private async Task<string> GenerateFile(bool useExcel, DataSourceRequest gridRequest)
        {
            IQueryable<WeatherForecast> queriableData = await MyDataService.GetForecasts();

            var pdfExporter = new PdfExporter();
            byte[] fileData = null;
            if (useExcel)
            {
                fileData = await pdfExporter.ExportWithRadSpreadProcessing(queriableData, gridRequest);
            }
            else
            {
                fileData = await pdfExporter.ExportWithRadPdfProcessing(queriableData, gridRequest);
            }

            string base64File = Convert.ToBase64String(fileData);

            //you can write the generated file to the file system to troubleshoot downloading issues
            //System.IO.File.WriteAllBytes("C:\\temp\\test.pdf", fileData);

            return await Task.FromResult(base64File);
        }
    }
}
