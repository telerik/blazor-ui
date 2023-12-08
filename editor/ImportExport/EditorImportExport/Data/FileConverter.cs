using Microsoft.AspNetCore.Hosting;
using Microsoft.JSInterop;
using System;
using System.IO;
using System.Threading.Tasks;
using Telerik.Documents.ImageUtils;
using Telerik.Windows.Documents.Common.FormatProviders;
using Telerik.Windows.Documents.Extensibility;
using Telerik.Windows.Documents.Flow.FormatProviders.Pdf;
using Telerik.Windows.Documents.Flow.FormatProviders.Docx;
using Telerik.Windows.Documents.Flow.FormatProviders.Html;
using Telerik.Windows.Documents.Flow.FormatProviders.Rtf;
using Telerik.Windows.Documents.Flow.FormatProviders.Txt;
using Telerik.Windows.Documents.Flow.Model;

namespace EditorImportExport.Data
{
    public class FileConverter
    {
        private IWebHostEnvironment Environment { get; set; }
        private IJSRuntime Js { get; set; }

        /// <summary>
        /// Import a file from disk and convert it to an HTML string for use in the Editor.
        /// </summary>
        /// <returns>An HTML string that is just the contents of the body tag. Returns null to denote an error.</returns>
        public string GetHtmlString()
        {
            try
            {
                // read the file - in this sample a hardcoded path
                string path = Path.Combine(Environment.WebRootPath, "JohnGrisham.docx");
                RadFlowDocument document = ReadFile(path);

                // convert the file to HTML
                HtmlFormatProvider provider = new HtmlFormatProvider();
                provider.ExportSettings.StylesExportMode = StylesExportMode.Inline;
                provider.ExportSettings.DocumentExportLevel = DocumentExportLevel.Fragment;
                string html = provider.Export(document);

                // get only the <body> contents
                int bodyStart = html.IndexOf("<body>") + "<body>".Length;
                int bodyEnd = html.IndexOf("</body>");
                string body = html.Substring(bodyStart, bodyEnd - bodyStart);

                return body;
            }
            catch(Exception ex)
            {
                Console.WriteLine("==================================================");
                Console.WriteLine("Document import failed. The exception message was:");
                Console.WriteLine("==================================================");
                Console.WriteLine(ex.Message);

                return string.Empty;
            }
        }

        /// <summary>
        /// Convert the HTML string to a file and download it in the browser.
        /// </summary>
        /// <param name="htmlContent">The HTML content to export</param>
        /// <param name="fileName">The name of the downloaded file. The file extension is used to fetch the export provider.</param>
        /// <returns>Returns true if the operation succeeded, false if there was an exception.</returns>
        public async Task<bool> ExportAndDownloadHtmlContent(string htmlContent, string fileName)
        {
            try
            {
                // Prepare a document with the HTML content.
                HtmlFormatProvider provider = new HtmlFormatProvider();
                RadFlowDocument document = provider.Import(htmlContent);

                // Enable conversion of non-JPG images to JPG.
                // https://docs.telerik.com/devtools/document-processing/libraries/radpdfprocessing/cross-platform/images
                JpegImageConverterBase defaultJpegImageConverter = new JpegImageConverter();
                FixedExtensibilityManager.JpegImageConverter = defaultJpegImageConverter;

                // Export the Editor content.
                string mimeType;
                IFormatProvider<RadFlowDocument> exportProvider = GetExportFormatProvider(fileName, out mimeType);
                byte[] exportFileBytes = null;
                using (MemoryStream ms = new MemoryStream())
                {
                    exportProvider.Export(document, ms);
                    exportFileBytes = ms.ToArray();
                }

                // Download the exported file.
                await FileDownloader.Save(Js, exportFileBytes, mimeType, fileName);
            }
            catch (Exception ex) 
            {
                Console.WriteLine("==================================================");
                Console.WriteLine("Document export failed. The exception message was:");
                Console.WriteLine("==================================================");
                Console.WriteLine(ex.Message);

                return false;
            }

            return true;
        }

        /// <summary>
        /// Read the file from the disk as an in-memory document.
        /// </summary>
        /// <param name="path">Path to the file to import.</param>
        /// <returns>RadFlowDocument that you can use to convert the contents to other formats</returns>
        private RadFlowDocument ReadFile(string path)
        {
            IFormatProvider<RadFlowDocument> fileFormatProvider = GetImportFormatProvider(Path.GetExtension(path));

            RadFlowDocument document;

            using (FileStream input = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                document = fileFormatProvider.Import(input);
            }

            return document;
        }

        /// <summary>
        /// Get Supported providers for the import operation based on the file extension
        /// </summary>
        /// <param name="extension">the extension of the file we will import, used to discern the provider type</param>
        /// <returns>IFormatProvider<RadFlowDocument> that you can use to read that file and import it as an in-memory document you can convert to other formats</returns>
        private IFormatProvider<RadFlowDocument> GetImportFormatProvider(string extension)
        {
            IFormatProvider<RadFlowDocument> fileFormatProvider;
            switch (extension)
            {
                case ".docx":
                    fileFormatProvider = new DocxFormatProvider();
                    break;
                case ".rtf":
                    fileFormatProvider = new RtfFormatProvider();
                    break;
                case ".html":
                    fileFormatProvider = new HtmlFormatProvider();
                    break;
                case ".txt":
                    fileFormatProvider = new TxtFormatProvider();
                    break;
                default:
                    fileFormatProvider = null;
                    break;
            }

            if (fileFormatProvider == null)
            {
                throw new NotSupportedException("File cannot be read with the supported format providers.");
            }

            return fileFormatProvider;
        }

        /// <summary>
        /// Get Supported providers for the export operation based on the file name, also gets its MIME type as an out parameter
        /// </summary>
        /// <param name="fileName">the file name you wish to export, the provider is discerned based on its extensiom</param>
        /// <param name="mimeType">an out parameter with the MIME type for this file so you can download it</param>
        /// <returns>IFormatProvider<RadFlowDocument> that you can use to export the original document to a certain file format</returns>
        private IFormatProvider<RadFlowDocument> GetExportFormatProvider(string fileName, out string mimeType)
        {
            IFormatProvider<RadFlowDocument> fileFormatProvider;
            string extension = Path.GetExtension(fileName);
            switch (extension)
            {
                case ".docx":
                    fileFormatProvider = new DocxFormatProvider();
                    mimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    break;
                case ".rtf":
                    fileFormatProvider = new RtfFormatProvider();
                    mimeType = "application/rtf";
                    break;
                case ".html":
                    fileFormatProvider = new HtmlFormatProvider();
                    mimeType = "text/html";
                    break;
                case ".txt":
                    fileFormatProvider = new TxtFormatProvider();
                    mimeType = "text/plain";
                    break;
                case ".pdf":
                    fileFormatProvider = new PdfFormatProvider();
                    mimeType = "application/pdf";
                    break;
                default:
                    fileFormatProvider = null;
                    mimeType = string.Empty;
                    break;
            }

            if (fileFormatProvider == null)
            {
                throw new NotSupportedException("The selected format cannot be exported with the supported format providers.");
            }

            return fileFormatProvider;
        }

        // DI to obtain the path to the wwwroot folder and JS runtime for downloading the file in the browser.
        public FileConverter(IWebHostEnvironment env, IJSRuntime js)
        {
            Environment = env;
            Js = js;
        }
    }
}
