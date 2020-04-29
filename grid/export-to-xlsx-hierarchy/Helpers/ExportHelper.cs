using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.JSInterop;
using Telerik.Documents.SpreadsheetStreaming;
using System.Threading.Tasks;
using export_to_xlsx_hierarchy.Models;
using System.Collections;
using System.Reflection;

namespace export_to_xlsx_hierarchy.Helpers
{
    public class ExportHelper : IDisposable
    {
        private IJSRuntime _JsRuntime;
        private IEnumerable<dynamic> _data;
        private string _filename;
        private readonly FileFormats.Formats _format;

        private bool disposedValue = false;

        public ExportHelper(IJSRuntime JsRuntime, IEnumerable<dynamic> data, string filename = "GridExport", FileFormats.Formats format = FileFormats.Formats.XLSX)
        {
            _JsRuntime = JsRuntime;
            _data = data;
            _filename = filename;
            _format = format;
        }

        public async Task<bool> ExportCurrentData()
        {
            byte[] fileData = GenerateDocument();

            if (fileData is null)
                return false;

            await Save(
                _JsRuntime,
                fileData,
                Enum.GetName(typeof(FileFormats.Formats), _format),
                $"{_filename}.{_format.ToString().ToLower()}"
            );

            return true;
        }

        public static async Task Save(IJSRuntime jsRuntime, byte[] byteData, string mimeType, string fileName)
        {
            await jsRuntime.InvokeVoidAsync("saveFile", Convert.ToBase64String(byteData), mimeType, fileName);
        }

        private byte[] GenerateDocument()
        {
            MemoryStream documentStream = new MemoryStream();
            var documentFormat = _format is FileFormats.Formats.XLSX ? SpreadDocumentFormat.Xlsx : SpreadDocumentFormat.Csv;

            using (IWorkbookExporter workbookExporter = SpreadExporter.CreateWorkbookExporter(documentFormat, documentStream))
            {
                using IWorksheetExporter worksheetExporter = workbookExporter.CreateWorksheetExporter("Sheet Name");
                //Export data to excel
                ExportGrid(worksheetExporter, _data, false);
            }

            return documentStream.ToArray();
        }

        private void ExportGrid(IWorksheetExporter worksheetExporter, IEnumerable<dynamic> data, bool isDetailGrid)
        {
            //Get Columns From Class
            string[] columnHeaders = GetColumnHeaders(data);

            if (columnHeaders.Length <= 0)
                return;

            //Add Columns to WorkBook
            ExportHeaderRows(worksheetExporter, data, columnHeaders, isDetailGrid);
            //Add Rows to WorkBook
            ExportBodyRows(worksheetExporter, data, columnHeaders, isDetailGrid);
        }

        private string[] GetColumnHeaders(IEnumerable<dynamic> data)
        {
            var propertyList = data.PropertiesFromType();

            return propertyList.ToArray();
        }

        private void ExportHeaderRows(IWorksheetExporter worksheetExporter, IEnumerable<dynamic> data, string[] columnHeaders, bool isDetailGrid)
        {
            using IRowExporter rowExporter = worksheetExporter.CreateRowExporter();
            rowExporter.SetHeightInPoints(20 /*you can change this to suite your needs*/);

            //Add Column Formatting
            SpreadCellFormat format = new SpreadCellFormat
            {
                IsBold = true,
                Fill = SpreadPatternFill.CreateSolidFill(new SpreadColor(142, 196, 65)),
                ForeColor = new SpreadThemableColor(new SpreadColor(255, 255, 255)),
                HorizontalAlignment = SpreadHorizontalAlignment.Center,
                VerticalAlignment = SpreadVerticalAlignment.Center
            };

            //If the current exported grid is a detail grid leave a blank cell
            if (isDetailGrid)
            {
                using ICellExporter cellExporter = rowExporter.CreateCellExporter();
                cellExporter.SetValue(string.Empty);
            }

            var columnName = GetDetailGridColumn(data);
            //Add Columns to Excel
            for (int i = 0; i < columnHeaders.Length; i++)
            {
                //Ignore the column that is our detail grid
                if (columnHeaders[i] == columnName)
                    continue;

                using ICellExporter cellExporter = rowExporter.CreateCellExporter();
                cellExporter.SetFormat(format);
                cellExporter.SetValue(columnHeaders[i]);
            }
        }

        private void ExportBodyRows(IWorksheetExporter worksheetExporter, IEnumerable<dynamic> data, string[] columnHeaders, bool isDetailGrid)
        {
            //Add Cell Formatting
            SpreadCellFormat format = new SpreadCellFormat
            {
                FontSize = 10,
                VerticalAlignment = SpreadVerticalAlignment.Center,
                HorizontalAlignment = SpreadHorizontalAlignment.Center,
                Fill = SpreadPatternFill.CreateSolidFill(new SpreadColor(50, 190, 255)),
            };

            SpreadCellFormat detailFormat = new SpreadCellFormat
            {
                FontSize = 10,
                VerticalAlignment = SpreadVerticalAlignment.Center,
                HorizontalAlignment = SpreadHorizontalAlignment.Center
            };

            //Loop through data rows
            foreach (var item in data)
            {
                //Create a new row
                using IRowExporter rowExporter = worksheetExporter.CreateRowExporter();
                rowExporter.SetHeightInPoints(20 /*you can change this to suite your needs*/);

                //If the current exported grid is a detail grid leave a blank cell
                if (isDetailGrid)
                {
                    using ICellExporter cellExporter = rowExporter.CreateCellExporter();
                    cellExporter.SetValue(string.Empty);
                    cellExporter.SetFormat(detailFormat);
                }

                //Add value to each column key
                foreach (var key in columnHeaders)
                {
                    try
                    {
                        //Get Type of current datasource
                        Type type = data.FirstOrDefault().GetType();
                        var prop = type.GetProperty(key);

                        var cellValue = prop.GetValue(item, null);
                        if (cellValue is null)
                            continue;
                        //check if the model has a List, which means it has a detail grid attached to it.
                        else if (cellValue is IList detailGrid)
                        {
                            //Dispose current rowExporter instance
                            rowExporter.Dispose();
                            ExportGrid(worksheetExporter, detailGrid.Cast<dynamic>(), true);
                        }

                        //Add value to Excel cell
                        using ICellExporter cellExporter = rowExporter.CreateCellExporter();
                        cellExporter.SetValue(cellValue.ToString());
                        cellExporter.SetFormat(isDetailGrid ? detailFormat : format);
                    }
                    catch (NullReferenceException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            }
        }

        private string GetDetailGridColumn(IEnumerable<dynamic> data)
        {
            //Check if the grid has a detail grid of type IList

            var item = data.FirstOrDefault();
            foreach (PropertyInfo property in item?.GetType().GetProperties())
            {
                //if this properties type is of type List, we assume that the value is a detail grid
                if (property.PropertyType.GetTypeInfo().IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                    return property.Name;
            }

            return string.Empty;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _JsRuntime = null;
                    _data = null;
                    _filename = null;
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }
    }
}