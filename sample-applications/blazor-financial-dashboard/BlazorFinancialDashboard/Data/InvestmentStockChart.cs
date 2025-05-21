using Telerik.Blazor.Components;

namespace BlazorFinancialDashboard.Data;

public class InvestmentStockChart
{
    public string Name { get; set; } = string.Empty;

    public List<StockPoint> StockChartData { get; set; } = new();

    public TelerikStockChart? StockChartRef { get; set;  }
}
