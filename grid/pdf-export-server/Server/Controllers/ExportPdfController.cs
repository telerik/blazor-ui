using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PdfExport;
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

        public ExportPdfController(ILogger<WeatherForecastController> logger)
        {
            this.logger = logger;
        }

        [HttpPost]
        public async Task<byte[]> Post([FromBody] DataSourceRequest gridRequest)
        {

            var spreadExporter = new RadSpreadProcessingExporter();

            byte[] fileData = spreadExporter.ExportPdf(50, 10);

           // System.IO.File.WriteAllBytes("C:\\temp\\test.pdf", fileData);

            return await Task.FromResult(fileData);
        }
    }
}
