using BlazorFinancialDashboard.Data;

namespace BlazorFinancialDashboard.Services;

public class InvestmentService
{
    private List<TotalInvestment> TotalInvestments { get; set; } = new();
    private List<AssetInfo> TopMovers { get; set; } = new();

    public async Task<List<TotalInvestment>> ReadTotalInvestments()
    {
        await Task.CompletedTask;

        return TotalInvestments;
    }

    public async Task<List<AssetInfo>> ReadTopMovers()
    {
        await Task.CompletedTask;

        return TopMovers;
    }

    public InvestmentService()
    {
        TotalInvestments = new List<TotalInvestment>
        {
            new() { Category = "Stocks", Value = 68_200 },
            new() { Category = "Real estate", Value = 42_500 },
            new() { Category = "Bonds", Value = 28_000 },
            new() { Category = "Mutual funds", Value = 31_500 },
            new() { Category = "Cryptocurrency", Value = 14_200 },
            new() { Category = "Commodities", Value = 18_000 }
        };

        TopMovers = new List<AssetInfo>
        {
            new AssetInfo { Symbol = "BTC", AssetName = "Bitcoin", CurrentValue = 68_420.25m, DailyChange = 0.032 },
            new AssetInfo { Symbol = "ETH", AssetName = "Ethereum", CurrentValue = 12_840.50m, DailyChange = 0.018 },
            new AssetInfo { Symbol = "XRP", AssetName = "Ripple", CurrentValue = 4_280.10m, DailyChange = -0.009 },
            new AssetInfo { Symbol = "TTH", AssetName = "Tether", CurrentValue = 2_120.00m, DailyChange = 0.001 },
            new AssetInfo { Symbol = "UNI", AssetName = "Uniswap", CurrentValue = 1_860.75m, DailyChange = -0.014 }
        };
    }
}
