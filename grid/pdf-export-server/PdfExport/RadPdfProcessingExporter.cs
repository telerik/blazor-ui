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
    public class RadPdfProcessingExporter
    {
        public void ExportSamples()
        {
            ExportPdf(20, 20);
            //ExportPdf(100, 20);
            //ExportPdf(100, 100);
            //ExportPdf(200, 100);
            //ExportPdf(1000, 20);
            //ExportPdf(2000, 20);
        }

        public Stream ExportPdf(int rowCount, int columnCount)
        {
            Console.WriteLine($"Exporting {rowCount} rows and {columnCount} columns with PdfProcessing");

            var watch1 = Stopwatch.StartNew();
            PdfFormatProvider provider = new PdfFormatProvider();
            var document = GenerateSampleDocument(rowCount, columnCount);
            Console.WriteLine($"file generation time: {watch1.ElapsedMilliseconds * 0.001} seconds.");
            Debug.WriteLine($"file generation time: {watch1.ElapsedMilliseconds * 0.001} seconds.");

            using var memoryStream = new MemoryStream();
            var watch2 = Stopwatch.StartNew();
            provider.Export(document, memoryStream);
            Console.WriteLine($"export time: {watch2.ElapsedMilliseconds * 0.001} seconds.");
            Debug.WriteLine($"export time: {watch2.ElapsedMilliseconds * 0.001} seconds.");

            return memoryStream;
        }

        private static RadFixedDocument GenerateSampleDocument(int rowCount, int columnCount)
        {
            var table = CreateTable(rowCount, columnCount);
            var document = new RadFixedDocument();
            using var editor = new RadFixedDocumentEditor(document);

            editor.InsertTable(table);

            return document;
        }

        private static Table CreateTable(int rowCount, int columnCount)
        {
            Table table = new Table();

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                var row = table.Rows.AddTableRow();

                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    row.Cells
                        .AddTableCell().Blocks.AddBlock()
                        .InsertText($"row {rowIndex}, col {columnIndex}");
                }
            }

            return table;
        }
    }
}
