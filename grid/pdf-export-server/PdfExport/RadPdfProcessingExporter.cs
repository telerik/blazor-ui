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
using System.Threading.Tasks;
using Telerik.DataSource;
using Telerik.DataSource.Extensions;
using System.Reflection;

namespace PdfExport
{
    public class RadPdfProcessingExporter
    {
        public async Task<byte[]> ExportPdf<T>(IQueryable<T> data, DataSourceRequest gridRequest)
        {
            PdfFormatProvider provider = new PdfFormatProvider();

            var document = await GenerateSampleDocument(data, gridRequest);

            byte[] fileBytes = null;
            using (MemoryStream ms = new MemoryStream())
            {
                provider.Export(document, ms);
                fileBytes = ms.ToArray();
            }

            return await Task.FromResult(fileBytes);
        }

        private async Task<RadFixedDocument> GenerateSampleDocument<T>(IQueryable<T> data, DataSourceRequest gridRequest)
        {
            var table = await CreateTable<T>(data, gridRequest);
            var document = new RadFixedDocument();
            using var editor = new RadFixedDocumentEditor(document);

            editor.InsertTable(table);

            return await Task.FromResult(document);
        }

        private async Task<Table> CreateTable<T>(IQueryable<T> data, DataSourceRequest gridRequest)
        {
            var dataResult = await data.ToDataSourceResultAsync(gridRequest);
            List<T> dataToExport = (dataResult.Data as IEnumerable<T>).ToList();

            int currRow = 0;

            Type typeParameterType = typeof(T);
            var fieldsList = typeParameterType.GetProperties();

            Table table = new Table();

            Border blackBorder = new Border(2, new RgbColor(0, 0, 0));
            table.DefaultCellProperties.Borders = new TableCellBorders(blackBorder, blackBorder, blackBorder, blackBorder);

            var headerRow = table.Rows.AddTableRow();
            for (int i = 0; i < fieldsList.Length; i++)
            {
                TableCell cell = headerRow.Cells.AddTableCell();
                cell.Blocks.AddBlock().InsertText(fieldsList[i].Name);
                cell.Background = new RgbColor(111, 111, 111);
            }

            for (int i = 0; i < dataToExport.Count; i++)
            {
                var row = table.Rows.AddTableRow();
                for (int columnIndex = 0; columnIndex < fieldsList.Length; columnIndex++)
                {
                    var cellValue = GetFieldValue(dataToExport[i], fieldsList[columnIndex].Name);

                    row.Cells
                        .AddTableCell().Blocks.AddBlock()
                        .InsertText(cellValue.ToString());
                }
                currRow++;
            }

            return await Task.FromResult(table);
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
