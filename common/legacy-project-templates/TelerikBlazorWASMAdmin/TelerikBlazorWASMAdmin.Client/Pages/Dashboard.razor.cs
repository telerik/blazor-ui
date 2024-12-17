using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Telerik.Blazor.Components;
using TelerikBlazorWASMAdmin.Shared.Models.Employee;
using TelerikBlazorWASMAdmin.Shared.Models.Sales;

namespace TelerikBlazorWASMAdmin.Client.Pages
{
    public partial class Dashboard
    {
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

        protected override async Task OnInitializedAsync()
        {
            employees = await Http.GetFromJsonAsync<List<Employee>>("api/employee");
            GridEmployees = employees?.Where(e => e.TeamId == 2).ToList();
            sales = await Http.GetFromJsonAsync<List<SalesByDateViewModel>>("api/sales/getsales");
        }

        void ItemResize()
        {
            StateHasChanged();
            DashboardChartRef.Refresh();
        }
    }
}
