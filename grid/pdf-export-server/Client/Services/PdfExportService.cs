using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Telerik.DataSource;

namespace ServerPdfExport.Client.Services
{
    public class PdfExportService
    {
        [Inject]
        private HttpClient Http { get; set; }

        [Inject]
        private IJSRuntime jsRuntime { get; set; }

        public PdfExportService(HttpClient client, IJSRuntime JsRuntimeInstance)
        {
            Http = client;
            jsRuntime = JsRuntimeInstance;
        }

        public async Task GetPdf(DataSourceRequest dataSourceRequest, bool allPages, bool useExcelGeneration)
        {
            //if we want all the pages, remove the paging from the grid request
            //you can use any other means of transporting and using this information
            if (allPages)
            {
                dataSourceRequest.PageSize = 0;
                dataSourceRequest.Skip = 0; // for virtualization
            }

            string actionMethod = "ExportPdf/FromPdf";

            if (useExcelGeneration)
            {
                actionMethod = "ExportPdf/FromExcel";
            }

            HttpResponseMessage response = await Http.PostAsJsonAsync(actionMethod, dataSourceRequest);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string base64File = await response.Content.ReadAsStringAsync();
                await jsRuntime.InvokeVoidAsync("saveFile", base64File, "application/pdf", "TelerikGridExport.pdf");
            }
            else
            {
                throw new Exception($"The service returned with status {response.StatusCode}");
            }
        }
    }
}
