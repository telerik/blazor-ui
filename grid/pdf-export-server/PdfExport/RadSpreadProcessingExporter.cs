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
using Telerik.Windows.Documents.Spreadsheet.Model;

namespace PdfExport
{
    public class RadSpreadProcessingExporter
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

        public byte[] ExportPdf(int rowCount, int columnCount)
        {
            byte[] data = ExportPdfFromExcel(rowCount, columnCount);
            return data;
        }

        private protected byte[] ExportPdfFromExcel(int rowCount, int columnCount)
        {
            Console.WriteLine($"Exporting {rowCount} rows and {columnCount} columns with SpreadProcessing");
            var workbook = new Workbook();
            workbook.Name = "workbook-1";

            // performance
            workbook.History.IsEnabled = false;
            workbook.SuspendLayoutUpdate();

            workbook.Sheets.Add(SheetType.Worksheet);
            Worksheet worksheet = workbook.ActiveWorksheet;

            int totalRowCount = 0;

            var watch1 = Stopwatch.StartNew();

            for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
            {
                worksheet.Cells[0, columnIndex].SetValue($"header {columnIndex + 1}");
            }

            totalRowCount++;

            // content
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    var cellValue = $"cell {rowIndex}-{columnIndex}";
                    SetCellValue(worksheet.Cells[totalRowCount, columnIndex], cellValue);
                }

                totalRowCount++;
            }

            // performance
            workbook.ResumeLayoutUpdate();

            Console.WriteLine($"file generation time: {watch1.ElapsedMilliseconds * 0.001} seconds.");
            Debug.WriteLine($"file generation time: {watch1.ElapsedMilliseconds * 0.001} seconds.");

            var watch2 = Stopwatch.StartNew();
            var pdfFormatProvider = new Telerik.Windows.Documents.Spreadsheet.FormatProviders.Pdf.PdfFormatProvider();

            byte[] fileBytes = null;
            using (MemoryStream ms = new MemoryStream())
            {
                pdfFormatProvider.Export(workbook, ms);
                fileBytes = ms.ToArray();
            }
           
            Console.WriteLine($"export time: {watch2.ElapsedMilliseconds * 0.001} seconds.");
            Debug.WriteLine($"export time: {watch2.ElapsedMilliseconds * 0.001} seconds.");

            return fileBytes;
        }

        private void SetCellValue(CellSelection cell, object value)
        {
            if (value == null)
            {
                value = string.Empty;
            }

            switch (Type.GetTypeCode(value.GetType()))
            {
                case TypeCode.Byte:
                case TypeCode.Char:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64: cell.SetValue(Convert.ToDouble(value)); break;
                case TypeCode.DateTime: cell.SetValue((DateTime)value); break;
                case TypeCode.Boolean: cell.SetValue((bool)value); break;
                default: cell.SetValue(value.ToString()); break;
            }
        }
    }
}
