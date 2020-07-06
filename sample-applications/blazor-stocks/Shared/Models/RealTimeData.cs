using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorFinancePortfolio.Models
{
    public class RealTimeData
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public decimal Price { get; set; }
        public decimal Change { get; set; }
        public string StockExchangeLong { get; set; }
        public string StockExchangeShort { get; set; }
        public string TimeZone { get; set; }
        public string TimeZoneName { get; set; }
        public decimal YearHigh { get; set; }
        public decimal YearLow { get; set; }
        public decimal Volume { get; set; }
        public decimal MarketCap { get; set; }
    }
}

