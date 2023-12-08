using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace EditorImportExport.Data
{
    public static class FileDownloader
    {
        public static async Task Save(IJSRuntime jsRuntime, byte[] byteData, string mimeType, string fileName)
        {
            if (byteData == null)
            {
                await jsRuntime.InvokeVoidAsync("alert", "The byte array provided for exporting was null.");
            }
            else
            {
                await jsRuntime.InvokeVoidAsync("saveFile", Convert.ToBase64String(byteData), mimeType, fileName);
            }
        }
    }
}
