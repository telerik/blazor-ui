using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PdfExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Telerik.DataSource;

namespace ServerSideSample.Data
{
    public class PdfExportService
    {
        [Inject]
        private IJSRuntime JS { get; set; }

        [Inject]
        private WeatherForecastService MyDataService { get; set; }

        public PdfExportService(WeatherForecastService dataService, IJSRuntime _js)
        {
            MyDataService = dataService;
            JS = _js;
        }
        public async Task GetPdf(DataSourceRequest gridRequest, bool allPages, bool useExcelGeneration)
        {
            if (allPages)
            {
                gridRequest.PageSize = 0;
            }

            IQueryable<WeatherForecast> queriableData = await MyDataService.GetForecasts();

            var pdfExporter = new PdfExporter();
            byte[] fileData = null;
            if (useExcelGeneration)
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

            await JS.InvokeVoidAsync("saveFile", base64File, "application/pdf", "TelerikGridExport.pdf");
        }
    }
}
