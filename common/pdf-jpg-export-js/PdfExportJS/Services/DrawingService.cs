using System;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace PdfExportJS.Services
{
	public class DrawingService
	{
        // The JavaScript namespace 
        const string JsNamespace = "telerikClientExporter";

        // IJSRuntime is resolved through DI
        public DrawingService(IJSRuntime js) => Js = js;

        public IJSRuntime Js { get; }

        /// <summary>
        /// Export an element from the page as a data image URI
        /// </summary>
        /// <param name="elementRef"></param>
        /// <returns>Data Image URI as a string</returns>
        public async ValueTask<string> ExportImage(ElementReference elementRef) =>
                      await Js.InvokeAsync<string>($"{JsNamespace}.exportImage", elementRef);

        /// <summary>
        /// Export an element from the page as a PDF formatted data URI
        /// </summary>
        /// <param name="elementRef"></param>
        /// <returns>Data URI as a string</returns>
        public async ValueTask<string> ExportPDF(ElementReference elementRef) =>
              await Js.InvokeAsync<string>($"{JsNamespace}.exportPDF", elementRef);

        /// <summary>
        /// Invokes the browser to save a Data URI formatted string to a file.
        /// </summary>
        /// <param name="dataUri">Data URI string</param>
        /// <param name="fileName">File name to save as</param>
        public async Task SaveAs(string dataUri, string fileName) =>
             await Js.InvokeVoidAsync($"{JsNamespace}.saveAs", dataUri, fileName);
    }
}
