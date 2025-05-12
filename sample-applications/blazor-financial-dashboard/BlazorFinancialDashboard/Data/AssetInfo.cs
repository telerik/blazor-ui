namespace BlazorFinancialDashboard.Data;

public class AssetInfo
{
    public string AssetName { get; set;} = string.Empty;

    public string Symbol { get; set; } = string.Empty;

    public double DailyChange { get; set; }

    public decimal CurrentValue { get; set; }
}
