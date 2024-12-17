using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Blazor.Components;
using TelerikBlazorServerAdmin.Models.Employee;
using TelerikBlazorServerAdmin.Models.Sales;

namespace TelerikBlazorServerAdmin.Pages
{
    public partial class Dashboard
    {
        public Dashboard()
        {

        }

        TelerikChart DashboardChartRef { get; set; } = null!;
        private List<Employee>? employees = new List<Employee>();
        private List<Employee>? GridEmployees = new List<Employee>();
        private List<SalesByDateViewModel>? sales = new List<SalesByDateViewModel>();
        public List<int?> PageSizes = new List<int?> { 5, 10, 15, 20, null };
        public string[] Categories = new string[] { "2002", "2003", "2004", "2005", "2006", "2007", "2008", "2009", "2010", "2011", "2012", "2013", "2014", "2015" };
        int PageSize = 10;
        int CurrentPage = 1;
        public int ArcGaugeValue { get; set; } = 50;

        bool FirstSelectedBtn { get; set; } = true;
        bool SecondGroupBtn { get; set; }

        bool ThirdSelectedBtn { get; set; } = true;
        bool FourthdGroupBtn { get; set; }

        public object[] AxisCrossingValue = new object[] { -10 };

        bool ExportAllPages { get; set; }

        protected override void OnInitialized()
        {
            employees = _dataService.GetEmployees();
            GridEmployees = employees?.Where(e => e.TeamId == 2).ToList();
            sales = _dataService.GetSales().Where(sale => sale.TransactionDate > new DateTime(2019, 12, 30) && sale.TransactionDate < new DateTime(2019, 12, 31))
                .Select(s => new SalesByDateViewModel
                {
                    Sum = s.Amount,
                    SumOne = s.Amount + 100,
                    SumTwo = s.Amount + 200,
                    SumThree = s.Amount + 300,
                    X = s.Id + 500,
                    Y = (int)s.Amount + 250,
                    Size = (int)s.Amount + 600,
                })
                .ToList();
        }

        void ItemResize()
        {
            StateHasChanged();
            DashboardChartRef.Refresh();
        }
    }
}
