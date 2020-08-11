using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telerik.Blazor;

namespace BlazorFinancePortfolio.Models
{
    public class ChartTypeList
    {
        public ChartSeriesType Value { get; set; }
        public string Text { get { return Value.ToString(); } }

        public static List<ChartTypeList> GetAvailableSeriesTypes()
        {
            return new List<ChartTypeList>()
                {
                    new ChartTypeList { Value = ChartSeriesType.Candlestick },
                    new ChartTypeList { Value = ChartSeriesType.Area },
                    new ChartTypeList { Value = ChartSeriesType.Line }
                };
        }
    }
}
