using BlazorFinancePortfolio.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telerik.Blazor;

namespace BlazorFinancePortfolio.Models
{
    public class IntervalFilter
    {
        public string Name { get; set; }
        public Interval Interval { get; set; }
        public long Duration { get; set; }

        public static List<IntervalFilter> GetIntervalFilters()
        {
            return new List<IntervalFilter>()
                {
                    new IntervalFilter { Name = "5M",  Interval = new Interval { Unit = ChartCategoryAxisBaseUnit.Minutes, Step = 5 }, Duration = Constants.MS_5_MINUTES },
                    new IntervalFilter { Name = "15M", Interval = new Interval { Unit = ChartCategoryAxisBaseUnit.Minutes, Step = 15 }, Duration = Constants.MS_15_MINUTES },
                    new IntervalFilter { Name = "30M", Interval = new Interval { Unit = ChartCategoryAxisBaseUnit.Minutes, Step = 30 }, Duration = Constants.MS_30_MINUTES },
                    new IntervalFilter { Name = "1H",  Interval = new Interval { Unit = ChartCategoryAxisBaseUnit.Hours, Step = 1 }, Duration = Constants.MS_1_HOUR },
                    new IntervalFilter { Name = "4H",  Interval = new Interval { Unit = ChartCategoryAxisBaseUnit.Hours, Step = 4 }, Duration = Constants.MS_4_HOURS },
                    new IntervalFilter { Name = "1D",  Interval = new Interval { Unit = ChartCategoryAxisBaseUnit.Days, Step = 1 }, Duration = Constants.MS_1_DAY },
                    new IntervalFilter { Name = "1W",  Interval = new Interval { Unit = ChartCategoryAxisBaseUnit.Weeks, Step = 1 }, Duration = Constants.MS_1_WEEK }
                };
        }
    }
}
