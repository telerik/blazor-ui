using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.IO;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf.Export;
using Telerik.Windows.Documents.Fixed.Model;
using Telerik.Windows.Documents.Fixed.Model.ColorSpaces;
using Telerik.Windows.Documents.Fixed.Model.Editing;
using Telerik.Windows.Documents.Fixed.Model.Editing.Flow;
using Telerik.Windows.Documents.Fixed.Model.Fonts;
using Telerik.Windows.Documents.Fixed.Model.Graphics;
using Telerik.Windows.Documents.Fixed.Model.Editing.Tables;

namespace PdfExport
{
    public class PdfExporter
    {
        public Stream ExportWithRadPdfProcessing(int rowCount, int columnCount)
        {
            var pdfExporter = new RadPdfProcessingExporter();

            return pdfExporter.ExportPdf(rowCount, columnCount);
        }
        public byte[] ExportWithRadSpreadProcessing(int rowCount, int columnCount)
        {
            var spreadExporter = new RadSpreadProcessingExporter();

            return spreadExporter.ExportPdf(rowCount, columnCount);
        }
    }
}
