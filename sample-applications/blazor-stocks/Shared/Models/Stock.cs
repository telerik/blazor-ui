using System;
using System.Collections.Generic;

namespace BlazorFinancePortfolio.Models
{
    public class Stock
    {
        public string Symbol { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal DayChange { get; set; }

        public decimal ChangePercentage { get; set; }

        public decimal Volume { get; set; }

        public decimal VolumeAvg { get; set; }

        public decimal MarketCap { get; set; }

        public decimal? PricePerEarningRatio { get; set; }

        public bool IsCategorized { get; set; }

        public IEnumerable<decimal> IntraDayChart { get; set; }
    }
}
