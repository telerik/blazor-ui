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
        private IJSRuntime JS { get; set; }

        public PdfExportService(HttpClient client, IJSRuntime _js)
        {
            Http = client;
            JS = _js;
        }

        public async Task GetPdf(DataSourceRequest gridRequest, bool allPages)
        {
            //if we want all the pages, remove the paging from the grid request
            //you can use any other means of transporting and using this information
            if (allPages)
            {
                gridRequest.PageSize = 0;
            }

            HttpResponseMessage response = await Http.PostAsJsonAsync("ExportPdf", gridRequest);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string base64File = await response.Content.ReadAsStringAsync();
                await JS.InvokeVoidAsync("saveFile", base64File, "application/pdf", "TelerikGridExport.pdf");
            }
            else
            {
                throw new Exception($"The service returned with status {response.StatusCode}");
            }
        }
    }
}
