using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Blazor.Components;
using TelerikBlazorServerAdmin.Models.Sales;

namespace TelerikBlazorServerAdmin.Pages
{
    public partial class PerformanceAndSales
    {
        public PerformanceAndSales()
        {

        }
        TelerikChart PieChartRef { get; set; } = null!;
        TelerikChart EuropeChartRef { get; set; } = null!;
        TelerikChart WorldChartRef { get; set; } = null!;
        TelerikChart ColumnChartRef { get; set; } = null!;
        TelerikChart AreaChartRef { get; set; } = null!;
        TelerikCircularGauge UserFirstCirclGauge { get; set; } = null!;
        TelerikCircularGauge UserSecondCirclGaugeRef { get; set; } = null!;
        TelerikCircularGauge UserThirdCirclGaugeRef { get; set; } = null!;
        TelerikCircularGauge UserFourthCirclGaugeRef { get; set; } = null!;
        private List<SalesByDateViewModel> sales = new List<SalesByDateViewModel>();
        private List<SalesByDateViewModel> salesPerformance = new List<SalesByDateViewModel>();
        public string[] xAxisItems = new string[] { "Q1", "Q2", "Q3", "Q4" };
        public string[] xAxisItemsBarFirst = new string[] { "Sofia, Bulgaria", "Berlin, Germany", "Paris, France", "Madrid, Spain" };
        public string[] xAxisItemsBarSecond = new string[] { "Moscow, Russia", "Beijing, China", "Dubai, UAE", "Tokyo, Japan" };
        public object[] AxisCrossingValue = new object[] { -10 };

        protected override void OnInitialized()
        {
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

            salesPerformance = _dataService.GetSales().Where(sale => sale.TransactionDate > new DateTime(2019, 12, 30) && sale.TransactionDate < new DateTime(2019, 12, 31))
                .Select(s => new SalesByDateViewModel
                {
                    Sum = s.Amount,
                    SumOne = s.Amount + 100,
                    SumTwo = s.Amount + 200,
                    SumThree = s.Amount + 300,
                    SegmentValue = s.Amount,
                    SegmentValueOne = s.Amount + 1,
                    SegmentValueTwo = s.Amount + 2,
                    SegmentValueThree = s.Amount + 3,
                    Cost = "Product Region- " + s.Region + $" {s.Id}"
                })
                .ToList();
            salesPerformance.RemoveRange(3, 10);
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
