using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorFinancePortfolio.Models;
using BlazorFinancePortfolio.Helpers;
using BlazorFinancePortfolio.Services;
using Telerik.Blazor;
using Telerik.Blazor.Components;

namespace BlazorFinancePortfolio.Client.Components.StocksChart
{
    public partial class TopAreaContainer
    {
        [Inject] internal StocksListService stocksService { get; set; }
        [Parameter] public Stock SelectedStock { get; set; }

        public DateTime MinDate { get; set; } = Constants.GetMinDate();
        public DateTime MaxDate { get; set; } = Constants.GetMaxDate();

        //parameters
        List<StockIntervalDetails> CurrentChartData { get; set; }
        DateTime Start { get; set; }
        DateTime End { get; set; } = DateTime.Now;
        public IntervalFilter SelectedInterval { get; set; }
        ChartSeriesType MainChartType { get; set; } = ChartSeriesType.Candlestick;
        long? ActiveTimeFilterDuration { get; set; }
        long SelectedFilterInterval { get; set; }

        //data sources
        List<ChartTypeList> AvailableChartTypes { get; set; } = ChartTypeList.GetAvailableSeriesTypes();
        List<TimeFilter> TimeFilters { get; set; } = TimeFilter.GetFilters();
        public List<IntervalFilter> IntervalFilters { get; set; } = IntervalFilter.GetIntervalFilters();

        IDictionary<long, long> TimeFilterDefaultIntervalsMapping { get; set; } =
            new Dictionary<long, long>
            {
            {Constants.MS_1_HOUR, Constants.MS_5_MINUTES },
            {Constants.MS_4_HOURS, Constants.MS_15_MINUTES },
            {Constants.MS_12_HOURS, Constants.MS_30_MINUTES },
            {Constants.MS_1_DAY, Constants.MS_30_MINUTES },
            {Constants.MS_4_DAYS, Constants.MS_1_HOUR },
            {Constants.MS_1_WEEK, Constants.MS_4_HOURS },
            };

        protected override void OnInitialized()
        {
            SelectedInterval = IntervalFilter.GetIntervalFilters()[3];
            SelectedFilterInterval = IntervalFilter.GetIntervalFilters()[3].Duration;
            ActiveTimeFilterDuration = TimeFilter.GetFilters()[4].Duration;

            Start = End.AddDays(-4);
            FilterIntervals(ActiveTimeFilterDuration.Value);

            TimeFilters.Add(new TimeFilter() { Name = "MAX", Duration = (long)(MaxDate - MinDate).TotalMilliseconds });

            base.OnInitialized();
        }

        protected override void OnParametersSet()
        {
            FilterCurrentChartData(SelectedFilterInterval);

            base.OnParametersSet();
        }

        async Task StartValueChangedHandler(DateTime currStart)
        {
            Start = currStart;
            if(End < Start)
            {
                End = Start;
            }
            DatesChanged();
        }

        async Task EndValueChangedHandler(DateTime currEnd)
        {
            End = currEnd;

            if (currEnd != default(DateTime))
            {
                End = currEnd;
            }
            else
            {
                End = Start;
            }
            DatesChanged();
        }

        void DatesChanged()
        {
            var dateRangeIntervalInMs = (long)(End - Start).TotalMilliseconds;

            ActiveTimeFilterDuration = null;

            FilterIntervals(dateRangeIntervalInMs);
            SetDefaultInterval(dateRangeIntervalInMs);

            FilterCurrentChartData(SelectedFilterInterval);
        }

        void OnTimeFilterClick(long FilterDuration)
        {
            if (this.ActiveTimeFilterDuration == FilterDuration)
            {
                return;
            }

            ActiveTimeFilterDuration = FilterDuration;

            End = MaxDate;
            Start = End.AddMilliseconds(-ActiveTimeFilterDuration.Value);

            FilterIntervals(FilterDuration);
            SetDefaultInterval(FilterDuration);

            FilterCurrentChartData(SelectedFilterInterval);
        }

        void FilterCurrentChartData(long intervalInMilliseconds)
        {
            var intervalInMinutes = intervalInMilliseconds / (1000 * 60);

            if (SelectedStock != null)
            {
                CurrentChartData = stocksService.GenerateStockIntervals(SelectedStock, (int)intervalInMinutes, Start, End);
            }
            else
            {
                CurrentChartData = null;
            }
        }

        void OnIntervalChange(long IntervalDuration)
        {
            SelectedInterval = IntervalFilter.GetIntervalFilters().Where(i => i.Duration == IntervalDuration).FirstOrDefault();
            SelectedFilterInterval = IntervalDuration;

            FilterCurrentChartData(IntervalDuration);
        }

        void FilterIntervals(long filterDuration)
        {
            IntervalFilters = IntervalFilter.GetIntervalFilters().Where(i => i.Duration < filterDuration && filterDuration / i.Duration < 200).ToList();
        }

        void SetDefaultInterval(long filterDuration)
        {
            if (!IntervalFilters.Any(i => i.Duration == SelectedFilterInterval))
            {
                SelectedFilterInterval = TimeFilterDefaultIntervalsMapping.ContainsKey(filterDuration)
                    ? TimeFilterDefaultIntervalsMapping[filterDuration]
                    : Constants.MS_1_DAY;
                SelectedInterval = IntervalFilters.Where(i => i.Duration == SelectedFilterInterval).FirstOrDefault();
            }
        }
    }
}
