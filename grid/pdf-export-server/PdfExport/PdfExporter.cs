using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.DataSource;

namespace PdfExport
{
    public class PdfExporter
    {
        public async Task<byte[]> ExportWithRadPdfProcessing<T>(IQueryable<T> data, DataSourceRequest gridRequest)
        {
            var pdfExporter = new RadPdfProcessingExporter();

            return await pdfExporter.ExportPdf(data, gridRequest);
        }
        public async Task<byte[]> ExportWithRadSpreadProcessing<T>(IQueryable<T> data, DataSourceRequest gridRequest)
        {
            var spreadExporter = new RadSpreadProcessingExporter();

            return await spreadExporter.ExportPdf(data, gridRequest);
        }
    }
}
