using System;

namespace BlazorFinancialDashboard.Data;

public class SearchablePage
{
    public string Title { get; set; }

    public string Keywords { get; set; }

    public SearchablePage(string title, string keywords)
    {
        Title = title;
        Keywords = keywords;
    }
}
