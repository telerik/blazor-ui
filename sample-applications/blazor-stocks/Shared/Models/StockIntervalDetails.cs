using System;

namespace BlazorFinancePortfolio.Models
{
    public class StockIntervalDetails
    {
        public DateTime Date { get; set; }

        public decimal Open { get; set; }

        public decimal Close { get; set; }

        public decimal High { get; set; }

        public decimal Low { get; set; }

        public decimal Volume { get; set; }

        public string ColumnColor { get; set; } // return currentLargerThenPrev ? '#5CB85C' : '#FF6358';

        public StockIntervalDetails Clone()
        {
            return new StockIntervalDetails
            {
                Date = new DateTime(this.Date.Ticks),
                Close = this.Close,
                ColumnColor = this.ColumnColor,
                High = this.High,
                Low = this.Low,
                Open = this.Open,
                Volume = this.Volume
            };
        }
    }
}
