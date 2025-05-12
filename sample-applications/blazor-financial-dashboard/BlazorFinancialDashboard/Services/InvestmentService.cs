using BlazorFinancialDashboard.Data;

namespace BlazorFinancialDashboard.Services;

public class InvestmentService
{
    private List<TotalInvestment> TotalInvestments { get; set; } = new();
    private List<AssetInfo> TopMovers { get; set; } = new();

    private readonly string[] InvestmentCategories = [ "Stocks", "Real Estates", "Bonds", "Mutual Funds", "Crypto Currency", "Commodities" ];
    private readonly Dictionary<string, string> Assets = new()
    {
        { "BTC", "Bitcoin" },
        { "ETH", "Etherium" },
        { "XRP", "Ripple" },
        { "TTH", "Theter" },
        { "UNI", "Unicorn" }
    };

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
        for (var i = 0; i < InvestmentCategories.Length; i++)
        {
            TotalInvestments.Add(new TotalInvestment()
            {
                Category = InvestmentCategories[i],
                Value = Random.Shared.Next(10_000, 100_000)
            });
        }

        for (var i = 0; i < Assets.Count; i++)
        {
            TopMovers.Add(new AssetInfo()
            {
                Symbol = Assets.ElementAt(i).Key,
                AssetName = Assets.ElementAt(i).Value,
                CurrentValue = Random.Shared.Next(10_000, 100_000) * 1.23m,
                DailyChange = Random.Shared.Next(-33, 33) * 0.01
            });
        }
    }
}
