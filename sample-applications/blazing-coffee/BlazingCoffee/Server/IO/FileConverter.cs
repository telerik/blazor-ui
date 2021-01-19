using Microsoft.AspNetCore.Http;
using System.IO;
using Telerik.Windows.Documents.Flow.FormatProviders.Docx;
using Telerik.Windows.Documents.Flow.FormatProviders.Pdf;
using Telerik.Windows.Documents.Flow.Model;

namespace BlazingCoffee.Server.IO
{
    public static class FileConverter
    {
        public static byte[] ConvertWordToPDF(byte[] file)
        {

            static RadFlowDocument ReadWordDocument(byte[] stream)
            {
                var fileFormatProvider = new DocxFormatProvider();
                return fileFormatProvider.Import(stream);
            }

            static byte[] ConvertToPDF(RadFlowDocument document)
            {
                using MemoryStream ms = new MemoryStream();
                PdfFormatProvider convertFormatProvider = new PdfFormatProvider();
                convertFormatProvider.Export(document, ms);
                return ms.ToArray();
            }

            var doc = ReadWordDocument(file);
            return ConvertToPDF(doc);

        }

        public static byte[] ToBytes(IFormFile file)
        {
            using MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            return ms.ToArray();
        }

    }
}
