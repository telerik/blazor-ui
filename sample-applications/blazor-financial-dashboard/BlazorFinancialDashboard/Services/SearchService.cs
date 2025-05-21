using BlazorFinancialDashboard.Data;
using Telerik.DataSource;
using Telerik.DataSource.Extensions;

namespace BlazorFinancialDashboard.Services;

public class SearchService
{
    private readonly List<SearchablePage> Data = new()
    {
        new SearchablePage("AI Assistant", "ai assist help chat roby faq related topics panelbar aiprompt prompt"),
        new SearchablePage("Analytics", "money cashflow flow chart personal transactions grid purchases merchants"),
        new SearchablePage("Investments", "total investment invest chart stocks bonds real estate mutual funds crypto currency commodities today top movers btc bitcoin eth ethereum xrp ripple tth theter unicornlistview stock chart stockchart"),
        new SearchablePage("Overview", "drawer earnings spendings investments savings budget utilization arcgauge gauge transactions grid"),
        new SearchablePage("Settings", "personal information user account form calendar bank card information mask maskedtextbox notification"),
        new SearchablePage("Transactions", "personal transactions grid badge transaction details form textbox purchase history"),
    };

    public async Task<List<SearchablePage>> Read()
    {
        await Task.CompletedTask;

        return Data;
    }

    public async Task<DataSourceResult> Read(DataSourceRequest request)
    {
        string filterString = request.Filters.OfType<FilterDescriptor>().FirstOrDefault()?.Value.ToString()?.Trim().ToLowerInvariant() ?? string.Empty;

        if (!string.IsNullOrEmpty(filterString))
        {
            List<SearchablePage> filteredPages = Data.Where(x =>
            {
                string title = x.Title.ToLowerInvariant();

                return title.Contains(filterString) ||
                    filterString.Contains(title) ||
                    x.Keywords.Contains(filterString);
            }).ToList();

            return new DataSourceResult()
            {
                Data = filteredPages,
                Total = filteredPages.Count
            };
        }
        else
        {
            return await Data.ToDataSourceResultAsync(request);
        }
    }
}
