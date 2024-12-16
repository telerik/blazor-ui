using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Telerik.Blazor.Components;
using TelerikBlazorWASMAdmin.Shared.Models.Sales;

namespace TelerikBlazorWASMAdmin.Client.Pages
{
    public partial class PerformanceAndSales
    {
        TelerikChart PieChartRef { get; set; } = null!;
        TelerikChart EuropeChartRef { get; set; } = null!;
        TelerikChart WorldChartRef { get; set; } = null!;
        TelerikChart ColumnChartRef { get; set; } = null!;
        TelerikChart AreaChartRef { get; set; } = null!;
        TelerikCircularGauge UserFirstCirclGauge { get; set; } = null!;
        TelerikCircularGauge UserSecondCirclGaugeRef { get; set; } = null!;
        TelerikCircularGauge UserThirdCirclGaugeRef { get; set; } = null!;
        TelerikCircularGauge UserFourthCirclGaugeRef { get; set; } = null!;
        private List<SalesByDateViewModel>? sales = new List<SalesByDateViewModel>();
        private List<SalesByDateViewModel>? salesPerformance = new List<SalesByDateViewModel>();
        public string[] xAxisItems = new string[] { "Q1", "Q2", "Q3", "Q4" };
        public string[] xAxisItemsBarFirst = new string[] { "Sofia, Bulgaria", "Berlin, Germany", "Paris, France", "Madrid, Spain" };
        public string[] xAxisItemsBarSecond = new string[] { "Moscow, Russia", "Beijing, China", "Dubai, UAE", "Tokyo, Japan" };
        public object[] AxisCrossingValue = new object[] { -10 };

        protected override async Task OnInitializedAsync()
        {
            sales = await Http.GetFromJsonAsync<List<SalesByDateViewModel>>("api/sales/getsales");
            salesPerformance = await Http.GetFromJsonAsync<List<SalesByDateViewModel>>("api/sales/getsalesperformance");
        }

        void ItemResize()
        {
            PieChartRef.Refresh();
            EuropeChartRef.Refresh();
            WorldChartRef.Refresh();
            ColumnChartRef.Refresh();
            AreaChartRef.Refresh();
            UserFirstCirclGauge.Refresh();
            UserSecondCirclGaugeRef.Refresh();
            UserThirdCirclGaugeRef.Refresh();
            UserFourthCirclGaugeRef.Refresh();
        }
    }
}
