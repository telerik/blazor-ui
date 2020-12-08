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
        private IJSRuntime jsRuntime { get; set; }

        [Inject]
        private WeatherForecastService MyDataService { get; set; }

        public PdfExportService(WeatherForecastService dataService, IJSRuntime JsRuntimeInstance)
        {
            MyDataService = dataService;
            jsRuntime = JsRuntimeInstance;
        }
        public async Task GetPdf(DataSourceRequest dataSourceRequest, bool allPages, bool useExcelGeneration)
        {
            if (allPages)
            {
                dataSourceRequest.PageSize = 0;
                dataSourceRequest.Skip = 0; // for virtualization
            }

            IQueryable<WeatherForecast> queriableData = await MyDataService.GetForecasts();

            var pdfExporter = new PdfExporter();
            byte[] fileData = null;
            if (useExcelGeneration)
            {
                fileData = await pdfExporter.ExportWithRadSpreadProcessing(queriableData, dataSourceRequest);
            }
            else
            {
                fileData = await pdfExporter.ExportWithRadPdfProcessing(queriableData, dataSourceRequest);
            }

            string base64File = Convert.ToBase64String(fileData);

            //you can write the generated file to the file system to troubleshoot downloading issues
            //System.IO.File.WriteAllBytes("C:\\temp\\test.pdf", fileData);

            await jsRuntime.InvokeVoidAsync("saveFile", base64File, "application/pdf", "TelerikGridExport.pdf");
        }
    }
}
