using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using BlazorFinancePortfolio.Models;
using BlazorFinancePortfolio.Services;
using Microsoft.JSInterop;
using BlazorPro.BlazorSize;

namespace BlazorFinancePortfolio.Client.Pages
{
    public partial class RealTime : IDisposable
    {
        [Inject] RealTimeDataService RealTimeDataService { get; set; }
        [Inject] ResizeListener listener { get; set; }
        [CascadingParameter] public Currency SelectedCurrency { get; set; }
        bool ShowAllColumns { get; set; }
        int LoadDataInterval { get; set; } = 1500;
        List<RealTimeData> GridData { get; set; }
        CancellationTokenSource CancelToken;
        Random rnd = new Random();

        int LastViewPortWidth { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await ToggleColumns(null);
            CancelToken = new CancellationTokenSource();
            GridData = await RealTimeDataService.GetInitialData(SelectedCurrency.Symbol);
            await IntervalDataUpdate();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                listener.OnResized += WindowResizeHandler;
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        async Task IntervalDataUpdate()
        {
            while (CancelToken.Token != null)
            {
                await Task.Delay(LoadDataInterval, CancelToken.Token);
                await RefreshData();
                StateHasChanged();
            }
        }

        void StopTimer()
        {
            if (CancelToken != null)
            {
                CancelToken.Cancel();
            }
        }

        async void WindowResizeHandler(object _, BrowserWindowSize window)
        {
            if (LastViewPortWidth != window.Width)
            {
                LastViewPortWidth = window.Width;
                await ToggleColumns(window.Width);
            }
        }

        protected async Task ToggleColumns(int? windowWidth)
        {
            if (windowWidth == null)
            {
                BrowserWindowSize currSize = await listener.GetBrowserWindowSize();
                windowWidth = currSize.Width;
                LastViewPortWidth = windowWidth.Value;
            }

            if (windowWidth < 992)
            {
                ShowAllColumns = false;
            }
            else
            {
                ShowAllColumns = true;
            }
            StateHasChanged();
        }

        public void Dispose()
        {
            listener.OnResized -= WindowResizeHandler;
            StopTimer();
        }

        async Task RefreshData()
        {
            foreach (RealTimeData item in GridData)
            {
                decimal change = RealTimeDataService.GetRandomChange();
                item.Change = change;
                item.Price = item.Price + change;
            }
        }

        string GetPriceChangeClass(decimal change)
        {
            if (change > 0) return "price-up";
            if (change < 0) return "price-down";
            return "";
        }
    }
}
