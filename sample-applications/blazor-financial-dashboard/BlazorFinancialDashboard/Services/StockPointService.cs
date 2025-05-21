using BlazorFinancialDashboard.Data;

namespace BlazorFinancialDashboard.Services;

public class StockPointService
{
    public async Task<List<StockPoint>> Read()
    {
        await Task.CompletedTask;

        return GenerateData();
    }

    private List<StockPoint> GenerateData()
    {
        var rnd = Random.Shared;
        int minRnd = 10;
        int maxRnd = 50;

        return Enumerable.Range(1, 365).Select(i =>
        {
            int monthlyRnd = DateTime.Today.AddDays(-i).Month % 5 + 2;
            decimal baseDailyValue = rnd.Next(minRnd, maxRnd) * 1.123m + monthlyRnd;
            decimal lowValue = baseDailyValue - rnd.Next(monthlyRnd, monthlyRnd * 2) * 1.12m;
            decimal openValue = baseDailyValue - rnd.Next(0, monthlyRnd) * 1.12m;
            decimal closeValue = baseDailyValue + rnd.Next(0, monthlyRnd) * 1.12m;
            decimal highValue = baseDailyValue + rnd.Next(monthlyRnd, monthlyRnd * 2) * 1.12m;
            decimal volumeValue = rnd.Next(0, 10_000) * 1.2345m;

            var sp = new StockPoint(DateTime.Today.AddDays(-i), openValue, closeValue, highValue, lowValue, volumeValue);

            return sp;
        }).ToList();
    }
}
