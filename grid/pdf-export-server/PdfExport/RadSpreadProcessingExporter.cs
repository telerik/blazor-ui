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
using Telerik.DataSource;
using Telerik.DataSource.Extensions;
using System.Threading.Tasks;
using System.Reflection;
using Telerik.Documents.Common.Model;

namespace PdfExport
{
    public class RadSpreadProcessingExporter
    {
        public async Task<byte[]> ExportPdf<T>(IQueryable<T> data, DataSourceRequest gridRequest)
        {
            var workbook = new Workbook();
            workbook.Name = "workbook-1";

            // performance
            workbook.History.IsEnabled = false;
            workbook.SuspendLayoutUpdate();

            workbook.Sheets.Add(SheetType.Worksheet);
            Worksheet worksheet = workbook.ActiveWorksheet;

            var dataResult = await data.ToDataSourceResultAsync(gridRequest);
            List<T> dataToExport = (dataResult.Data as IEnumerable<T>).ToList();

            int currRow = 0;

            Type typeParameterType = typeof(T);
            var fieldsList = typeParameterType.GetProperties();

            //some styling for the cells - borders in this example
            ThemableColor black = new ThemableColor(Telerik.Documents.Media.Color.FromArgb(0, 0, 0, 0));
            CellBorders desiredBorders = new CellBorders(
                    new CellBorder(CellBorderStyle.Medium, black),   // Left border 
                    new CellBorder(CellBorderStyle.Medium, black),   // Top border 
                    new CellBorder(CellBorderStyle.Medium, black),   // Right border 
                    new CellBorder(CellBorderStyle.Medium, black),   // Bottom border 
                    new CellBorder(CellBorderStyle.Thin, black),       // Inside horizontal border 
                    new CellBorder(CellBorderStyle.Thin, black),       // Inside vertical border 
                    new CellBorder(CellBorderStyle.None, black),     // Diagonal up border 
                    new CellBorder(CellBorderStyle.None, black)    // Diagonal down border 
                );

            for (int i = 0; i < fieldsList.Length; i++)
            {
                CellSelection currCell = worksheet.Cells[0, i];
                currCell.SetValue(fieldsList[i].Name);
                currCell.SetBorders(desiredBorders);
            }

            currRow++;


            // content
            for (int i = 0; i < dataToExport.Count; i++)
            {
                for (int columnIndex = 0; columnIndex < fieldsList.Length; columnIndex++)
                {
                    var cellValue = GetFieldValue(dataToExport[i], fieldsList[columnIndex].Name);
                    CellSelection currCell = worksheet.Cells[currRow, columnIndex];
                    SetCellValue(currCell, cellValue);
                    currCell.SetBorders(desiredBorders);
                }
                currRow++;
            }

            //column sizes
            for (int i = 0; i < fieldsList.Length; i++)
            {
                worksheet.Columns[i].AutoFitWidth();
            }

            // performance
            workbook.ResumeLayoutUpdate();

            //convert the excel workbook to a pdf
            var pdfFormatProvider = new Telerik.Windows.Documents.Spreadsheet.FormatProviders.Pdf.PdfFormatProvider();

            byte[] fileBytes = null;
            using (MemoryStream ms = new MemoryStream())
            {
                pdfFormatProvider.Export(workbook, ms);
                fileBytes = ms.ToArray();
            }

            return await Task.FromResult(fileBytes);
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

        private object GetFieldValue(object item, string fieldName)
        {
            PropertyInfo propertyInfo = item.GetType().GetProperty(fieldName);
            if (propertyInfo != null)
            {
                return propertyInfo.GetValue(item);
            }
            return null;
        }
    }
}
