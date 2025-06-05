using BlazorFinancialDashboard.Data;
using Telerik.Blazor.Components.Grid;

namespace BlazorFinancialDashboard.Services;

public static class CommonUtils
{
    private static readonly Dictionary<string, string> ExportableColumnWiths = new()
    {
        { nameof(Transaction.Amount), "100px" },
        { nameof(Transaction.Category), "120px" },
        { nameof(Transaction.Date), "180px" },
        { nameof(Transaction.Merchant), "140px" },
        { nameof(Transaction.PaymentMethodId), "100px" },
        { nameof(Transaction.Status), "100px" }
    };

    private static readonly string DefaultExportableColumnWidth = "120px";

    public static void SetExportableColumnWidths(List<GridExcelExportColumn> currentColumns)
    {
        foreach (GridExcelExportColumn column in currentColumns)
        {
            if (ExportableColumnWiths.TryGetValue(column.Field, out string? value))
            {
                column.Width = value;
            }
            else
            {
                column.Width = DefaultExportableColumnWidth;
            }
        }
    }

    public static void SetExportableColumnWidths(List<GridPdfExportColumn> currentColumns)
    {
        foreach (GridPdfExportColumn column in currentColumns)
        {
            if (ExportableColumnWiths.TryGetValue(column.Field, out string? value))
            {
                column.Width = value;
            }
            else
            {
                column.Width = DefaultExportableColumnWidth;
            }
        }
    }
}
