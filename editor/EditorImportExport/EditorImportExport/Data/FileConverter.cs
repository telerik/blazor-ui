using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Telerik.Windows.Documents.Common.FormatProviders;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf;
using pdfProviderNamespace = Telerik.Windows.Documents.Flow.FormatProviders.Pdf;
using Telerik.Windows.Documents.Flow.FormatProviders.Docx;
using Telerik.Windows.Documents.Flow.FormatProviders.Html;
using Telerik.Windows.Documents.Flow.FormatProviders.Rtf;
using Telerik.Windows.Documents.Flow.FormatProviders.Txt;
using Telerik.Windows.Documents.Flow.Model;
using Microsoft.JSInterop;

namespace EditorImportExport.Data
{
    public class FileConverter
    {
        private IWebHostEnvironment Environment { get; set; }
        private IJSRuntime _js { get; set; }

        public string GetHtmlString()
        {
            try
            {
                RadFlowDocument document = ReadFile(null);
                HtmlFormatProvider provider = new HtmlFormatProvider();
                provider.ExportSettings.DocumentExportLevel = DocumentExportLevel.Fragment;
                string html = provider.Export(document);
                int bodyStart = html.IndexOf("<body>") + "<body>".Length;
                int bodyEnd = html.IndexOf("</body>");
                string body = html.Substring(bodyStart, bodyEnd - bodyStart);
                return body;
            }
            catch(Exception ex)
            {
                return string.Empty;
            }
        }

        public async Task ExportHtmlFileToPdf(string htmlContent)
        {
            try
            {
                HtmlFormatProvider provider = new HtmlFormatProvider();
                RadFlowDocument document = provider.Import(htmlContent);

                pdfProviderNamespace.PdfFormatProvider pdfProvider = new pdfProviderNamespace.PdfFormatProvider();
                byte[] pdfFileBytes = pdfProvider.Export(document);

                await FileDownloader.Save(_js, pdfFileBytes, "application/pdf", "EditorContent.pdf");
            }
            catch { }
        }

        RadFlowDocument ReadFile(string path)
        {
            IFormatProvider<RadFlowDocument> fileFormatProvider = null;
            RadFlowDocument document = null;

            if (string.IsNullOrEmpty(path))
            {
                path = Path.Combine(Environment.WebRootPath, "JohnGrisham.docx");
            }

            switch (Path.GetExtension(path))
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

            using (FileStream input = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                document = fileFormatProvider.Import(input);
            }

            return document;
        }


        public FileConverter(IWebHostEnvironment env, IJSRuntime js)
        {
            Environment = env;
            _js = js;
        }
    }


}
