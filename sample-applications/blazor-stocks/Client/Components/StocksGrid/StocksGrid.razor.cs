using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorFinancePortfolio.Models;
using BlazorFinancePortfolio.Helpers;
using BlazorFinancePortfolio.Services;
using Microsoft.JSInterop;
using BlazorPro.BlazorSize;

namespace BlazorFinancePortfolio.Client.Components.StocksGrid
{
    public partial class StocksGrid : IDisposable
    {
        [Inject] StocksListService StocksListService { get; set; }
        [Inject] ResizeListener listener { get; set; }
        [Parameter] public Stock SelectedStock { get; set; }
        IEnumerable<Stock> SelectedStocks
        {
            get
            {
                if (SelectedStock != null)
                {
                    return new List<Stock>() { SelectedStock };
                }
                return Enumerable.Empty<Stock>();
            }
        }
        [Parameter] public EventCallback<Stock> SelectedStockChanged { get; set; }
        [Parameter] public List<Stock> Data { get; set; }
        [Parameter] public List<Stock> UncategorizedStocks { get; set; }
        [CascadingParameter] public Currency SelectedCurrency { get; set; }

        string SelectedValue { get; set; }

        bool LargerThanPhone { get; set; }
        bool LargerThanTablet { get; set; }
        int LastViewPortWidth { get; set; }

        async Task OnSelect(IEnumerable<Stock> selectedStocks)
        {
            SelectedStock = selectedStocks.FirstOrDefault();
            await SelectedStockChanged.InvokeAsync(SelectedStock);
        }

        async Task OnAdd(object selectedSymbol)
        {
            string symbol = selectedSymbol.ToString();
            if (!string.IsNullOrWhiteSpace(symbol))
            {
                var stock = UncategorizedStocks.FirstOrDefault(s => s.Symbol == symbol);
                if (stock != null && Data.All(s => s.Symbol != stock.Symbol))
                {
                    Stock addedStock = await StocksListService.AddStock(stock);
                    Data = await StocksListService.GetStocks(true);

                    UncategorizedStocks.Remove(stock);
                    var newUncategorizedStocks = new List<Stock>(UncategorizedStocks);
                    UncategorizedStocks = newUncategorizedStocks;

                    SelectedValue = string.Empty;
                }
            }
        }

        async Task OnRemoveConfirm()
        {
            if (SelectedStock == null)
            {
                return;
            }

            var stockForRemove = Data.FirstOrDefault(c => c.Symbol == SelectedStock.Symbol);
            await StocksListService.RemoveStock(stockForRemove);
            Data = await StocksListService.GetStocks(true);
            UncategorizedStocks = await StocksListService.GetStocks(false);

            SelectedStock = Data.FirstOrDefault();
            await SelectedStockChanged.InvokeAsync(SelectedStock);
        }

        protected override async Task OnInitializedAsync()
        {
            await ToggleColumnsInitial();

            Data = await StocksListService.GetStocks(true);

            UncategorizedStocks = await StocksListService.GetStocks(false);

            SelectedStock = Data.FirstOrDefault();
            await SelectedStockChanged.InvokeAsync(SelectedStock);

            await base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                listener.OnResized += ToggleColumnsOnResize;
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        async void ToggleColumnsOnResize(object _, BrowserWindowSize window)
        {
            if (LastViewPortWidth != window.Width)
            {
                LastViewPortWidth = window.Width;
                ToggleColumnsFlags(window.Width);
            }
        }

        async Task ToggleColumnsInitial()
        {
            BrowserWindowSize currSize = await listener.GetBrowserWindowSize();
            LastViewPortWidth = currSize.Width;
            ToggleColumnsFlags(currSize.Width);
        }

        void ToggleColumnsFlags(int browserWidth)
        {
            LargerThanPhone = browserWidth > 768;
            LargerThanTablet = browserWidth > 992;

            StateHasChanged();
        }

        public void Dispose()
        {
            listener.OnResized -= ToggleColumnsOnResize;
        }
    }
}
