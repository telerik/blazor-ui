﻿using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorFinancePortfolio.Models;
using BlazorFinancePortfolio.Helpers;
using BlazorFinancePortfolio.Services;
using Telerik.Blazor.Components;
using Microsoft.JSInterop;
using BlazorPro.BlazorSize;

namespace BlazorFinancePortfolio.Client.Pages
{
    public partial class UserProfile : IDisposable
    {
        [Inject] NavigationManager NavManager { get; set; }
        [Inject] StocksListService StocksListService {get;set;}
        [Inject] ResizeListener listener { get; set; }
        [CascadingParameter] public Currency SelectedCurrency { get; set; }

        [Parameter] public bool IsProfileVisible { get; set; }
        [Parameter] public EventCallback<bool> IsProfileVisibleChanged { get; set; }

        public List<Stock> Stocks { get; set; }
        TelerikChart ChartRef { get; set; }
        bool ChartLabelsVisible { get; set; } = true;

        int LastViewPortWidth { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (IsCurrentPageProfile())
            {
                IsProfileVisible = true;
            }

            Stocks = await StocksListService.GetStocks(true);
            await ResizeChart(null);

            await base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                listener.OnResized += WindowResizeHandler;
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        async void CloseProfile()
        {
            if (IsCurrentPageProfile())
            {
                NavManager.NavigateTo("");
            }
            else
            {
                IsProfileVisible = false;
                await IsProfileVisibleChanged.InvokeAsync(IsProfileVisible);
            }
        }

        bool IsCurrentPageProfile()
        {
            string currPage = NavManager.Uri.Substring(Math.Min(NavManager.Uri.Length, NavManager.BaseUri.Length)).ToLowerInvariant();
            return currPage.StartsWith("profile");
        }

        async void WindowResizeHandler(object _, BrowserWindowSize window)
        {
            if (LastViewPortWidth != window.Width)
            {
                LastViewPortWidth = window.Width;
                await ResizeChart(window.Width);
            }
        }

        async Task ResizeChart(int? windowWidth)
        {
            if(windowWidth == null)
            {
                BrowserWindowSize currSize = await listener.GetBrowserWindowSize();
                windowWidth = currSize.Width;
                LastViewPortWidth = windowWidth.Value;
            }
            if (windowWidth <= 992)
            {
                ChartLabelsVisible = false;
            }
            else
            {
                ChartLabelsVisible = true;
            }
            StateHasChanged();

            if (ChartRef != null)
            {
                ChartRef.Refresh();
            }
        }

        public void Dispose()
        {
            listener.OnResized -= WindowResizeHandler;
        }
    }
}
