using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorFinancePortfolio.Models;

namespace BlazorFinancePortfolio.Services
{
    public class RealTimeDataService
    {
        private static Random Rnd { get; set; } = new Random();

        public decimal GetRandomChange()
        {
            double currRandom = Rnd.NextDouble();
            double change = currRandom > 0.5 ? currRandom > 0.75 ? -Rnd.NextDouble() * 2 : Rnd.NextDouble() * 2 : 0;
            return (decimal)change;
        }

        private string GetSymbol()
        {
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string symbol = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                symbol += letters[(int)Math.Floor(Rnd.NextDouble() * 26)];
            }

            return symbol;
        }

        public Task<List<RealTimeData>> GetInitialData(string currency)
        {
            List<RealTimeData> data = new List<RealTimeData>();
            decimal price = (decimal)(Rnd.NextDouble() * 100 + 10);

            for (int i = 1; i < 1001; i++)
            {
                string symbol = GetSymbol();
                data.Add(new RealTimeData
                {
                    Id = i,
                    Symbol = symbol,
                    Name = symbol + " Inc.",
                    Currency = currency,
                    Price = price,
                    Change = GetRandomChange(),
                    StockExchangeLong = "New York Stock Exchange",
                    StockExchangeShort = "NYSE",
                    TimeZone = "EDT",
                    TimeZoneName = "America/New_York",
                    YearHigh = price + price / 3,
                    YearLow = price - price / 3,
                    Volume = (decimal)(21774241 * Rnd.NextDouble() * 50),
                    MarketCap = (decimal)(229956956 * Rnd.NextDouble() * 50)
                });
            }

            return Task.FromResult(data);
        }
    }
}
