using BlazorFinancePortfolio.Helpers;
using BlazorFinancePortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorFinancePortfolio.Services
{
    public class StocksListService
    {
        private List<Stock> UserStocks { get; set; }

        public Task<List<Stock>>GetStocks(bool isCategorized)
        {
            if (UserStocks == null)
            {
                UserStocks = GetInitialStocks();
            }

            var categorizedStocks = UserStocks.Where(s => s.IsCategorized == isCategorized).ToList();

            return Task.FromResult(categorizedStocks);
        }

        public List<StockIntervalDetails> GenerateStockIntervals(Stock stock, int intervalInMinutes, DateTime start, DateTime end)
        {
            DateTime minStart = Constants.GetMinDate();
            DateTime maxEnd = Constants.GetMaxDate();
            if(start < minStart)
            {
                start = minStart;
            }
            if(end > maxEnd)
            {
                end = maxEnd;
            }

            var stocks = new List<StockIntervalDetails>
            {
                new StockIntervalDetails
                {
                    Open = stock.Price - 0.1m,
                    Close = stock.Price,
                    ColumnColor = "#5CB85C",
                    Date = start,
                    High = stock.Price + 1.1m,
                    Low = stock.Price - 2.2m,
                    Volume = stock.Price * 10000
                }
            };
            var startIterator = start.AddMinutes(intervalInMinutes);

            var random = new Random();

            var counter = 1;
            while (startIterator < end)
            {
                var prevInterval = stocks[counter - 1];
                // get random volatility from -3% to 3% for each N(intervalInMinutes) minutes 
                var randomVolatility = random.Next(-30, 30) * 0.001m;

                var randomVolume = random.Next(100, 10000);
                var randomHighPercentage = random.Next(101, 105) * 0.01m;
                var randomLowPercentage = random.Next(95, 99) * 0.01m;

                var change = prevInterval.Close * randomVolatility;
                var newPrice = prevInterval.Close + change;
                var high = newPrice * randomHighPercentage;
                var low = newPrice * randomLowPercentage;

                low = Lowest(low, newPrice, prevInterval.Close, high);
                high = Highest(low, newPrice, prevInterval.Close, high);

                var stockToAdd = new StockIntervalDetails
                {
                    Close = newPrice,
                    Date = startIterator,
                    Open = prevInterval.Close,
                    High = high,
                    Low = low,
                    Volume = newPrice * randomVolume
                };

                stockToAdd.ColumnColor = stockToAdd.Volume >= prevInterval.Volume ? "#5CB85C" : "#FF6358";
                stocks.Add(stockToAdd);

                counter++;
                startIterator = startIterator.AddMinutes(intervalInMinutes);
            }

            return stocks;
        }

        private decimal Lowest(params decimal[] inputs)
        {
            return inputs.Min();
        }

        private decimal Highest(params decimal[] inputs)
        {
            return inputs.Max();
        }

        public async Task<Stock> RemoveStock(Stock stockToRemove)
        {
            var matchingItem = UserStocks.FirstOrDefault(s => s.Symbol == stockToRemove.Symbol);
            if (matchingItem != null)
            {
                matchingItem.IsCategorized = false;
                return await Task.FromResult(matchingItem);
            }

            return await Task.FromResult(matchingItem);
        }

        public async Task<Stock> AddStock(Stock stockToAdd)
        {
            var matchingItem = UserStocks.FirstOrDefault(s => s.Symbol == stockToAdd.Symbol);
            if (matchingItem != null)
            {
                matchingItem.IsCategorized = true;
            }

            return await Task.FromResult(matchingItem);
        }

        private List<Stock> GetInitialStocks()
        {
            var stockList = new List<Stock>();

            stockList.Add(new Stock
            {
                Symbol = "AAN",
                Name = "Aaron's, Inc.",
                Price = 76.61m,
                DayChange = -1.18m,
                ChangePercentage = -1.52m,
                Volume = 710442,
                VolumeAvg = 837114,
                MarketCap = 5174814208,
                IsCategorized = true,
                PricePerEarningRatio = 25.94m,
                IntraDayChart = new List<decimal> { 77.77m, 77.48m, 77.47m, 77.22m, 77.29m, 76.9m, 76.69m, 76.65m, 76.69m, 76.82m, 76.75m, 76.81m, 76.87m, 76.84m, 76.7m, 76.65m, 76.44m, 76.29m, 76.42m, 76.32m, 76.2m, 75.94m, 75.87m, 75.8m, 75.99m, 76.09m, 75.8m, 75.82m, 75.91m, 75.84m, 75.85m, 76.01m, 75.99m, 75.92m, 75.99m, 76.06m, 76.06m, 76.11m, 76.17m, 76.18m, 76.17m, 76.13m, 76.04m, 75.88m, 75.72m, 75.69m, 75.92m, 75.99m, 76.04m, 76.07m, 76.03m, 75.95m, 75.75m, 75.58m, 75.8m, 75.87m, 75.93m, 76.08m, 75.95m, 76.01m, 76.05m, 76.07m, 76.16m, 76.21m, 76.2m, 76.38m, 76.41m, 76.43m, 76.38m, 76.51m, 76.7m, 76.65m, 76.71m, 76.68m, 76.65m, 76.46m, 76.53m, 76.59m }
            });

            stockList.Add(new Stock
            {
                Symbol = "AAPL",
                Name = "Apple Inc.",
                Price = 246.58m,
                DayChange = 2.49m,
                ChangePercentage = 1.02m,
                Volume = 15827692,
                VolumeAvg = 20028962,
                MarketCap = 1114344259584,
                IsCategorized = true,
                PricePerEarningRatio = 20.94m,
                IntraDayChart = new List<decimal> { 243.75m, 243.54m, 243.32m, 243.47m, 243.74m, 243.43m, 243.34m, 243.39m, 243.47m, 243.66m, 243.68m, 244.43m, 244.53m, 244.25m, 244.16m, 243.93m, 244.41m, 244.69m, 244.52m, 244.52m, 244.62m, 244.88m, 245.07m, 245.7m, 245.31m, 245.34m, 245.48m, 245.54m, 245.28m, 245.43m, 245.41m, 245.2m, 245.33m, 245.31m, 245.34m, 245.56m, 245.59m, 245.47m, 245.1m, 245.18m, 245.29m, 245.24m, 245.35m, 245.26m, 245.16m, 245.38m, 245.31m, 245.3m, 245.3m, 245.25m, 245.39m, 245.45m, 245.38m, 245.37m, 245.25m, 244.81m, 245.05m, 245.07m, 245.1m, 245.2m, 245.18m, 245.13m, 245.18m, 245.35m, 245.34m, 245.31m, 245.39m, 245.46m, 245.57m, 245.65m, 245.67m, 245.76m, 245.68m, 245.77m, 245.79m, 245.86m, 245.9m, 246.24m }

            });

            stockList.Add(new Stock
            {

                Symbol = "ACN",
                Name = "Accenture plc",
                Price = 183.07m,
                DayChange = -0.77m,
                ChangePercentage = -0.42m,
                Volume = 1369124,
                VolumeAvg = 1892150,
                MarketCap = 116597284864,
                IsCategorized = true,
                PricePerEarningRatio = 24.87m,
                IntraDayChart = new List<decimal> { 184.08m, 184.36m, 183.49m, 183.77m, 183.74m, 183.57m, 183.62m, 183.76m, 184.13m, 183.95m, 183.99m, 184.16m, 184.05m, 183.85m, 183.81m, 183.84m, 184.4m, 184.34m, 184.4m, 184.32m, 184.24m, 184.45m, 184.5m, 184.54m, 184.52m, 184.55m, 184.58m, 184.71m, 184.63m, 184.74m, 184.58m, 184.29m, 184.13m, 184.12m, 184.1m, 184.11m, 184.21m, 184.21m, 184.11m, 184.05m, 184.06m, 184m, 183.94m, 183.9m, 183.89m, 183.9m, 183.94m, 183.83m, 183.9m, 183.75m, 183.73m, 183.78m, 183.78m, 183.92m, 183.9m, 183.75m, 183.87m, 183.87m, 183.83m, 183.81m, 183.7m, 183.4m, 183.42m, 183.53m, 183.53m, 183.6m, 183.64m, 183.5m, 183.46m, 183.51m, 183.54m, 183.62m, 183.59m, 183.66m, 183.54m, 183.4m, 183.24m, 183.31m }
            });

            stockList.Add(new Stock
            {
                Symbol = "ADBE",
                Name = "Adobe Inc.",
                Price = 270.98m,
                DayChange = 2.93m,
                ChangePercentage = 1.09m,
                Volume = 1511852,
                VolumeAvg = 3342325,
                MarketCap = 131175735296,
                IsCategorized = true,
                PricePerEarningRatio = 48.22m,
                IntraDayChart = new List<decimal> { 267.66m, 267.8m, 268.63m, 269.04m, 269.44m, 269.13m, 269.3m, 269.95m, 270.13m, 269.81m, 269.9m, 270.2m, 270.35m, 270.2m, 270.14m, 270.33m, 271.13m, 270.73m, 270.55m, 270.31m, 270.46m, 271.06m, 271.54m, 271.31m, 270.86m, 270.97m, 271.18m, 271.33m, 271.16m, 271.29m, 271.11m, 270.73m, 270.61m, 270.82m, 271.02m, 270.95m, 271.18m, 271.07m, 270.96m, 271.03m, 271.02m, 270.95m, 270.91m, 270.93m, 270.88m, 271.06m, 271.03m, 270.89m, 271.02m, 270.95m, 271.04m, 270.74m, 270.86m, 270.57m, 270.85m, 270.68m, 270.63m, 270.59m, 270.59m, 270.7m, 270.82m, 270.35m, 270.53m, 270.73m, 270.76m, 271m, 271.06m, 270.64m, 270.65m, 270.79m, 270.88m, 270.88m, 270.9m, 271.02m, 270.77m, 270.72m, 270.68m, 270.59m }
            });

            stockList.Add(new Stock
            {
                Symbol = "AGM",
                Name = "Federal Agricultural Mortgage Corporation",
                Price = 84.57m,
                DayChange = 0.17m,
                ChangePercentage = 0.2m,
                Volume = 22444,
                VolumeAvg = 22114,
                MarketCap = 890445952,
                IsCategorized = true,
                PricePerEarningRatio = 9.46m,
                IntraDayChart = new List<decimal> { 84.42m, 84.87m, 84.87m, 84.02m, 84.02m, 84.18m, 84.11m, 83.5m, 82.7m, 82.7m, 82.97m, 82.97m, 82.97m, 83.08m, 83.08m, 83.29m, 83.29m, 83.01m, 83.01m, 83.21m, 83.21m, 83.18m, 83.38m, 83.08m, 83.08m, 83.34m, 83.34m, 83.39m, 83.39m, 83.35m, 83.35m, 83.32m, 83.32m, 83.28m, 83.28m, 83.28m, 83.58m, 83.58m, 83.58m, 83.26m, 83.26m, 83.49m, 83.49m, 84.52m, 84.52m, 84.1m, 84.1m, 84.1m, 83.41m, 84.77m, 83.53m, 83.53m, 83.92m, 83.92m, 83.76m, 83.76m, 84.44m, 84.44m, 84.44m, 84.33m, 84.72m, 84.59m }
            });

            stockList.Add(new Stock
            {
                Symbol = "AMZN",
                Name = "Amazon.com, Inc.",
                Price = 1779.99m,
                DayChange = 17.78m,
                ChangePercentage = 1.01m,
                Volume = 2173743,
                VolumeAvg = 3771314,
                MarketCap = 882513674240,
                IsCategorized = true,
                PricePerEarningRatio = 78.87m,
                IntraDayChart = new List<decimal> { 1762.22m, 1762m, 1763.11m, 1768.61m, 1768.02m, 1766.44m, 1764.64m, 1766.46m, 1767.14m, 1768.17m, 1767.75m, 1769.02m, 1768.68m, 1771.99m, 1771.46m, 1774.6m, 1778.5m, 1778.76m, 1776.4m, 1773.73m, 1774.49m, 1771.65m, 1772.55m, 1773.22m, 1773.5m, 1770.94m, 1769.19m, 1770.69m, 1771.39m, 1772.2m, 1770.41m, 1771.65m, 1769.62m, 1769.5m, 1769.54m, 1768.72m, 1768.31m, 1767.99m, 1767.33m, 1766.14m, 1765.66m, 1765.45m, 1765.79m, 1765.99m, 1767.82m, 1767.14m, 1768.4m, 1768.29m, 1767.83m, 1767.51m, 1769.12m, 1767.93m, 1768.07m, 1768.5m, 1769.81m, 1769.46m, 1775.4m, 1774.97m, 1772.7m, 1771m, 1768.94m, 1769.56m, 1774.53m, 1775.34m, 1778.57m, 1779.69m, 1780.34m, 1779.24m, 1778.32m, 1780m, 1781m, 1779.16m, 1778.02m, 1777.22m, 1777.04m, 1778.57m, 1780.24m, 1780m }
            });

            stockList.Add(new Stock
            {
                Symbol = "ASML",
                Name = "ASML Holding N.V.",
                Price = 263.99m,
                DayChange = 1.26m,
                ChangePercentage = 0.48m,
                Volume = 549797,
                VolumeAvg = 1164687,
                MarketCap = 110834614272,
                IsCategorized = true,
                PricePerEarningRatio = 37.94m,
                IntraDayChart = new List<decimal> { 262.8m, 262.63m, 262.18m, 261.98m, 262.34m, 262.23m, 262.23m, 262.21m, 262.78m, 262.62m, 262.75m, 262.74m, 262.88m, 262.85m, 263.11m, 263m, 263.38m, 263.45m, 263.63m, 263.23m, 263.45m, 263.16m, 263.29m, 263.48m, 263.52m, 263.89m, 264.08m, 264.5m, 264.54m, 264.38m, 263.95m, 263.82m, 263.78m, 263.93m, 264.13m, 264.16m, 263.97m, 263.94m, 264m, 263.84m, 263.98m, 263.95m, 264.11m, 264.15m, 264.26m, 264.06m, 264.49m, 264.02m, 264.08m, 264.6m, 264.65m, 264.27m, 264.36m, 263.92m, 263.75m, 264.29m, 264.09m, 264.24m, 264.33m, 263.92m, 263.77m, 263.74m, 264.02m, 263.88m, 263.82m, 263.79m, 263.6m, 263.43m, 263.58m, 263.57m, 263.61m, 263.55m, 263.57m, 263.41m, 264.06m }
            });

            stockList.Add(new Stock
            {
                Symbol = "AVGO",
                Name = "Broadcom Inc.",
                Price = 289.82m,
                DayChange = 5.87m,
                ChangePercentage = 2.07m,
                Volume = 1987976,
                VolumeAvg = 1691400,
                MarketCap = 114963193856,
                IsCategorized = true,
                PricePerEarningRatio = 40.79m,
                IntraDayChart = new List<decimal> { 283.88m, 284.32m, 284.93m, 284.65m, 285.68m, 285.99m, 286.07m, 285.96m, 286.29m, 286.21m, 286.29m, 286.64m, 286.62m, 286.22m, 286.17m, 285.92m, 286.8m, 286.83m, 287.17m, 287.14m, 287.66m, 287.87m, 287.92m, 288.42m, 288.4m, 288.42m, 288.8m, 288.9m, 289.24m, 289.27m, 288.96m, 288.16m, 288.27m, 288.4m, 288.8m, 288.8m, 289.16m, 288.92m, 288.97m, 289.09m, 289.16m, 288.75m, 288.88m, 289.1m, 289.4m, 290.08m, 290.01m, 290.26m, 290.67m, 290.22m, 290.47m, 290.91m, 290.79m, 291.15m, 291.27m, 290.16m, 290.1m, 289.79m, 290.02m, 290.05m, 290.03m, 289.9m, 289.92m, 290.29m, 290.22m, 290.28m, 290.24m, 290.46m, 290.64m, 290.62m, 290.67m, 290.61m, 290.63m, 290.19m, 290.01m, 290.2m, 289.89m, 289.75m }
            });

            stockList.Add(new Stock
            {
                Symbol = "BNPQY",
                Name = "BNP Paribas SA",
                Price = 26.43m,
                DayChange = 0.43m,
                ChangePercentage = 1.65m,
                Volume = 103645,
                VolumeAvg = 193571,
                MarketCap = 66021871616,
                IsCategorized = true,
                PricePerEarningRatio = null,
                IntraDayChart = new List<decimal> { 26m, 25.97m, 25.97m, 25.98m, 25.95m, 25.95m, 25.89m, 25.91m, 25.89m, 25.85m, 25.91m, 25.93m, 25.89m, 25.94m, 25.94m, 25.94m, 25.94m, 25.91m, 25.9m, 25.89m, 25.92m, 25.97m, 25.97m, 25.94m, 25.94m, 25.94m, 25.94m, 25.99m, 26.07m, 26.07m, 26.01m, 26.01m, 26.04m, 26.03m, 26.03m, 26.03m, 25.99m, 25.99m, 26.08m, 26.08m, 26.06m, 26.05m, 26.05m, 26.05m, 25.99m, 25.99m, 25.99m, 26.06m, 25.99m, 26.02m, 26.05m, 26.05m, 26m, 26m, 26m, 25.98m, 26m, 26m, 26.03m, 26.11m, 26.22m, 26.26m, 26.36m, 26.41m, 26.41m, 26.29m, 26.41m, 26.4m, 26.35m, 26.35m, 26.42m, 26.43m, 26.43m }
            });

            stockList.Add(new Stock
            {
                Symbol = "CACC",
                Name = "Credit Acceptance Corporation",
                Price = 439.2m,
                DayChange = -0.69m,
                ChangePercentage = -0.16m,
                Volume = 57324,
                VolumeAvg = 84857,
                MarketCap = 8255554560,
                IsCategorized = true,
                PricePerEarningRatio = 13.4m,
                IntraDayChart = new List<decimal> { 439.4m, 438.08m, 438.08m, 438.57m, 438.57m, 439.86m, 439.86m, 440.89m, 440.89m, 439.95m, 439.95m, 440m, 440.8m, 440.58m, 439.52m, 439.03m, 438.46m, 437.69m, 437.29m, 438.59m, 437.05m, 437.25m, 437.34m, 438.89m, 438.89m, 438.89m, 440m, 438.22m, 437.41m, 438.13m, 438.14m, 437.57m, 437.14m, 436.77m, 436.77m, 437.89m, 437.31m, 437.31m, 437.09m, 437.09m, 436.91m, 436.91m, 437.43m, 437.43m, 437.22m, 437.22m, 436.83m, 436.47m, 436.47m, 436.82m, 436.82m, 438.84m, 438.84m, 437.4m, 437.4m, 438.35m, 438.35m, 438.2m, 439.57m, 440.49m, 438.99m, 438.67m, 440.14m, 439.22m, 439.77m, 439.77m, 439.25m, 439.43m, 438.9m, 439.24m, 438.69m, 438.71m }
            });
            stockList.Add(new Stock
            {
                Symbol = "CAI",
                Name = "CAI International, Inc.",
                Price = 23.77m,
                DayChange = -1.23m,
                ChangePercentage = -4.92m,
                Volume = 184691,
                VolumeAvg = 114114,
                MarketCap = 414063904,
                PricePerEarningRatio = 12.99m,
                IsCategorized = false,
                IntraDayChart = new List<decimal> { 25m, 25.5m, 24.95m, 24.99m, 25.19m, 25m, 24.69m, 24.55m, 24.31m, 24.32m, 24.22m, 24.15m, 23.97m, 23.77m, 24.13m, 24m, 24m, 24.07m, 23.91m, 24.06m, 23.91m, 23.71m, 23.59m, 23.57m, 23.72m, 23.56m, 23.47m, 23.32m, 23.68m, 23.68m, 23.65m, 23.65m, 23.65m, 23.63m, 23.67m, 23.67m, 23.62m, 23.77m, 23.67m, 23.56m, 23.44m, 23.69m, 23.69m, 23.85m, 23.84m, 23.79m, 23.79m, 23.58m, 23.58m, 23.58m, 23.78m, 23.84m, 23.66m, 23.67m, 24.15m, 23.98m, 23.98m, 23.81m, 23.8m, 23.8m, 23.77m, 23.91m, 23.91m, 23.83m, 23.98m, 23.95m, 23.88m, 23.91m, 23.84m, 23.78m, 23.92m, 23.7m, 23.93m, 23.76m, 23.7m, 23.76m, 23.76m, 23.77m }
            });

            stockList.Add(new Stock
            {
                Symbol = "CBTX",
                Name = "CBTX, Inc.",
                Price = 28.71m,
                DayChange = 0.04m,
                ChangePercentage = 0.14m,
                Volume = 43506,
                VolumeAvg = 26514,
                MarketCap = 746933696,
                IsCategorized = false,
                PricePerEarningRatio = 13.87m,
                IntraDayChart = new List<decimal> { 28.58m, 28.58m, 28.55m, 28.55m, 28.55m, 28.43m, 28.43m, 28.33m, 28.33m, 28.43m, 28.43m, 28.43m, 28.45m, 28.45m, 28.46m, 28.46m, 28.75m, 28.64m, 28.7m, 28.7m, 28.55m, 28.55m, 28.55m, 28.55m, 28.55m, 28.49m, 28.49m, 28.46m, 28.46m, 28.47m, 28.43m, 28.43m, 28.41m, 28.39m, 28.39m, 28.5m, 28.51m, 28.48m, 28.23m, 28.23m, 28.41m, 28.41m, 28.45m, 28.45m, 28.55m, 28.5m, 28.55m, 28.55m, 28.75m, 28.75m, 28.74m, 28.74m, 28.9m, 28.9m, 28.82m, 28.82m, 28.79m, 28.85m, 28.62m }
            });

            stockList.Add(new Stock
            {
                Symbol = "CMA",
                Name = "Comerica Incorporated",
                Price = 66.52m,
                DayChange = 0.28m,
                ChangePercentage = 0.42m,
                Volume = 1407582,
                VolumeAvg = 1229371,
                MarketCap = 9587926016,
                IsCategorized = false,
                PricePerEarningRatio = 8.42m,
                IntraDayChart = new List<decimal> { 66.25m, 66.08m, 66.16m, 66.01m, 65.99m, 65.83m, 65.75m, 65.89m, 65.83m, 65.75m, 65.76m, 65.8m, 65.67m, 65.61m, 65.69m, 65.9m, 66.02m, 65.95m, 65.96m, 65.91m, 65.93m, 65.99m, 65.9m, 65.88m, 65.79m, 65.9m, 65.86m, 65.92m, 65.91m, 65.95m, 65.97m, 66.1m, 66.06m, 65.92m, 65.96m, 65.98m, 66.11m, 66.15m, 66.2m, 66.15m, 66.24m, 66.31m, 66.35m, 66.3m, 66.25m, 66.26m, 66.23m, 66.18m, 66.22m, 66.22m, 66.22m, 66.13m, 66.2m, 66.25m, 66.49m, 66.36m, 66.53m, 66.59m, 66.56m, 66.63m, 66.63m, 66.92m, 67.06m, 67.06m, 67.1m, 67.23m, 67.23m, 66.94m, 66.89m, 66.81m, 66.9m, 66.84m, 66.78m, 66.71m, 66.63m, 66.47m, 66.63m, 66.53m }
            });

            stockList.Add(new Stock
            {
                Symbol = "CRM",
                Name = "salesforce.com, inc.",
                Price = 150.49m,
                DayChange = 3.21m,
                ChangePercentage = 2.18m,
                Volume = 4814264,
                VolumeAvg = 5236950,
                MarketCap = 131979730944,
                IsCategorized = false,
                PricePerEarningRatio = 124.99m,
                IntraDayChart = new List<decimal> { 147.19m, 147.16m, 147.29m, 147.91m, 147.87m, 147.83m, 147.8m, 147.78m, 148.08m, 148.2m, 148.04m, 148.39m, 148.23m, 148.01m, 147.88m, 148.18m, 148.77m, 148.51m, 148.4m, 148.32m, 148.33m, 148.69m, 148.79m, 148.83m, 148.79m, 148.89m, 148.89m, 148.89m, 148.95m, 149.04m, 148.96m, 148.76m, 148.61m, 148.61m, 148.69m, 148.63m, 148.73m, 148.79m, 148.69m, 148.72m, 148.71m, 148.79m, 148.75m, 148.79m, 148.79m, 149.03m, 149.08m, 149.15m, 149.2m, 149.11m, 149.34m, 149.55m, 149.63m, 149.58m, 149.63m, 149.64m, 149.78m, 149.89m, 149.93m, 149.95m, 149.97m, 149.6m, 149.74m, 149.73m, 149.94m, 149.99m, 149.96m, 149.98m, 150.05m, 150.1m, 150.17m, 150.23m, 150.24m, 150.41m, 150.32m, 150.4m, 150.23m, 150.4m }
            });

            stockList.Add(new Stock
            {
                Symbol = "CSCO",
                Name = "Cisco Systems, Inc.",
                Price = 46.9m,
                DayChange = 0.31m,
                ChangePercentage = 0.67m,
                Volume = 12554651,
                VolumeAvg = 16144737,
                MarketCap = 196328095744,
                IsCategorized = false,
                PricePerEarningRatio = 17.97m,
                IntraDayChart = new List<decimal> { 46.59m, 46.67m, 46.74m, 46.77m, 46.79m, 46.76m, 46.79m, 46.78m, 46.78m, 46.82m, 46.77m, 46.79m, 46.82m, 46.79m, 46.74m, 46.67m, 46.76m, 46.77m, 46.74m, 46.74m, 46.74m, 46.8m, 46.88m, 46.96m, 46.96m, 46.94m, 46.95m, 46.96m, 46.94m, 46.95m, 46.91m, 46.86m, 46.88m, 46.87m, 46.88m, 46.86m, 46.9m, 46.94m, 46.92m, 46.93m, 46.94m, 46.92m, 46.92m, 46.89m, 46.87m, 46.91m, 46.89m, 46.88m, 46.88m, 46.85m, 46.89m, 46.9m, 46.85m, 46.87m, 46.83m, 46.86m, 46.86m, 46.78m, 46.8m, 46.81m, 46.78m, 46.72m, 46.72m, 46.78m, 46.8m, 46.83m, 46.86m, 46.87m, 46.88m, 46.86m, 46.88m, 46.92m, 46.96m, 46.94m, 46.94m, 46.94m, 46.88m, 46.9m }
            });

            stockList.Add(new Stock
            {
                Symbol = "ECPG",
                Name = "Encore Capital Group, Inc.",
                Price = 33.79m,
                DayChange = -0.76m,
                ChangePercentage = -2.2m,
                Volume = 233014,
                VolumeAvg = 189114,
                MarketCap = 1049429568,
                IsCategorized = false,
                PricePerEarningRatio = 6.82m,
                IntraDayChart = new List<decimal> { 34.56m, 34.45m, 34.45m, 34.53m, 34.38m, 34.26m, 34.17m, 34.17m, 34.13m, 34.19m, 34.21m, 34.27m, 34.27m, 34.17m, 34.17m, 34.17m, 34.12m, 34.17m, 34.18m, 34.18m, 34.14m, 34.1m, 34.12m, 34.09m, 34.09m, 34.03m, 33.99m, 33.97m, 33.98m, 33.97m, 34.02m, 33.99m, 33.99m, 34m, 33.96m, 34.01m, 34.01m, 34.03m, 34.05m, 34.1m, 34.04m, 34.06m, 34.01m, 34.01m, 34.01m, 33.9m, 33.88m, 33.88m, 33.85m, 33.85m, 33.86m, 33.88m, 33.88m, 33.89m, 33.92m, 33.96m, 33.94m, 33.94m, 33.91m, 33.88m, 33.89m, 33.87m, 33.9m, 33.9m, 33.87m, 33.87m, 33.89m, 33.86m, 33.85m, 33.87m, 33.76m, 33.85m, 33.79m, 33.81m, 33.9m, 33.86m, 33.8m }
            });

            stockList.Add(new Stock
            {
                Symbol = "EPRT",
                Name = "Essential Properties Realty Trust, Inc.",
                Price = 25.58m,
                DayChange = 0.04m,
                ChangePercentage = 0.16m,
                Volume = 894983,
                VolumeAvg = 909457,
                MarketCap = 1952475392,
                IsCategorized = false,
                PricePerEarningRatio = 49.57m,
                IntraDayChart = new List<decimal> { 25.54m, 25.43m, 25.4m, 25.29m, 25.21m, 25.24m, 25.26m, 25.32m, 25.3m, 25.23m, 25.33m, 25.39m, 25.41m, 25.3m, 25.37m, 25.36m, 25.36m, 25.43m, 25.45m, 25.43m, 25.37m, 25.46m, 25.48m, 25.49m, 25.48m, 25.5m, 25.51m, 25.55m, 25.53m, 25.54m, 25.56m, 25.6m, 25.53m, 25.51m, 25.5m, 25.53m, 25.51m, 25.54m, 25.56m, 25.55m, 25.55m, 25.5m, 25.47m, 25.47m, 25.45m, 25.47m, 25.5m, 25.53m, 25.48m, 25.49m, 25.43m, 25.38m, 25.45m, 25.46m, 25.4m, 25.42m, 25.34m, 25.37m, 25.36m, 25.34m, 25.35m, 25.33m, 25.42m, 25.41m, 25.48m, 25.44m, 25.46m, 25.48m, 25.5m, 25.49m, 25.49m, 25.45m, 25.52m, 25.56m, 25.57m, 25.58m, 25.59m, 25.58m }
            });

            stockList.Add(new Stock
            {
                Symbol = "FB",
                Name = "Facebook, Inc.",
                Price = 187.89m,
                DayChange = 2.09m,
                ChangePercentage = 1.12m,
                Volume = 6979273,
                VolumeAvg = 12925912,
                MarketCap = 536040767488,
                IsCategorized = false,
                PricePerEarningRatio = 31.78m,
                IntraDayChart = new List<decimal> { 185.81m, 185.25m, 185.73m, 185.74m, 185.93m, 186.33m, 186.08m, 186.03m, 186.39m, 186.33m, 186.44m, 186.87m, 187.51m, 187.11m, 187.29m, 187.43m, 187.83m, 187.96m, 188.27m, 188.29m, 188.25m, 188.5m, 188.76m, 188.93m, 188.54m, 188.44m, 188.52m, 188.55m, 188.33m, 188.35m, 188.21m, 187.93m, 188.05m, 188.29m, 188.36m, 188.5m, 188.57m, 188.47m, 188.43m, 188.63m, 188.66m, 188.66m, 188.57m, 188.57m, 188.43m, 188.57m, 188.52m, 188.4m, 188.29m, 188.26m, 188.44m, 188.24m, 188.28m, 188.36m, 188.24m, 187.91m, 188.05m, 188.12m, 187.77m, 187.85m, 187.83m, 187.62m, 187.74m, 187.93m, 187.96m, 187.96m, 188.04m, 188.17m, 188.18m, 188.18m, 188.05m, 188.19m, 188.1m, 188.19m, 188.07m, 188.02m, 187.93m, 187.9m }
            });

            stockList.Add(new Stock
            {
                Symbol = "FOR",
                Name = "Forestar Group Inc.",
                Price = 18.5m,
                DayChange = -0.32m,
                ChangePercentage = -1.7m,
                Volume = 77837,
                VolumeAvg = 88428,
                MarketCap = 887951872,
                IsCategorized = false,
                PricePerEarningRatio = 6.72m,
                IntraDayChart = new List<decimal> { 18.8m, 18.8m, 18.43m, 18.43m, 18.48m, 18.48m, 18.38m, 18.38m, 18.43m, 18.43m, 18.35m, 18.4m, 18.32m, 18.32m, 18.33m, 18.33m, 18.3m, 18.26m, 18.26m, 18.21m, 18.21m, 18.12m, 18.13m, 18.13m, 18.12m, 18.13m, 18.13m, 18.19m, 18.17m, 18.16m, 18.16m, 18.17m, 18.2m, 18.17m, 18.16m, 18.16m, 18.14m, 18.16m, 18.19m, 18.19m, 18.16m, 18.16m, 18.16m, 18.17m, 18.17m, 18.19m, 18.19m, 18.17m, 18.17m, 18.17m, 18.18m, 18.18m, 18.16m, 18.18m, 18.17m, 18.17m, 18.17m, 18.17m, 18.16m, 18.16m, 18.2m, 18.29m, 18.29m, 18.35m, 18.35m, 18.35m, 18.39m, 18.36m, 18.5m, 18.49m, 18.45m, 18.47m, 18.5m, 18.48m }
            });

            stockList.Add(new Stock
            {
                Symbol = "GATX",
                Name = "GATX Corporation",
                Price = 80.2m,
                DayChange = -1.39m,
                ChangePercentage = -1.7m,
                Volume = 144502,
                VolumeAvg = 283171,
                MarketCap = 2815019776,
                IsCategorized = false,
                PricePerEarningRatio = 14.51m,
                IntraDayChart = new List<decimal> { 81.6m, 81.53m, 81.64m, 81.64m, 81.26m, 81.26m, 80.63m, 80.89m, 80.91m, 80.98m, 81.06m, 81.09m, 80.93m, 80.89m, 80.8m, 80.85m, 80.65m, 80.68m, 80.58m, 80.46m, 80.6m, 80.38m, 80.24m, 80.01m, 79.79m, 80.02m, 80.01m, 80.08m, 80.3m, 80.4m, 80.46m, 80.6m, 80.6m, 80.32m, 80.37m, 80.44m, 80.61m, 80.49m, 80.49m, 80.58m, 80.58m, 80.59m, 80.64m, 80.52m, 80.49m, 80.3m, 80.45m, 80.36m, 80.29m, 80.35m, 80.45m, 80.36m, 80.41m, 80.4m, 79.86m, 79.41m, 79.56m, 79.64m, 80.03m, 80.16m, 80.17m, 80.22m, 80.18m, 80.25m, 80.46m, 80.56m, 80.55m, 80.59m, 80.47m, 80.42m, 80.57m, 80.41m, 80.39m, 80.24m, 80.23m, 80.09m, 80.26m, 80.21m }
            });

            stockList.Add(new Stock
            {
                Symbol = "GOOGL",
                Name = "Alphabet Inc.",
                Price = 1264.3m,
                DayChange = 12.77m,
                ChangePercentage = 1.02m,
                Volume = 1243991,
                VolumeAvg = 1160087,
                MarketCap = 877319290880,
                IsCategorized = false,
                PricePerEarningRatio = 25.52m,
                IntraDayChart = new List<decimal> { 1250.64m, 1251.31m, 1254.55m, 1256.5m, 1255.41m, 1254.68m, 1252.91m, 1254.09m, 1256.22m, 1256.61m, 1257.85m, 1260.42m, 1260.15m, 1259.65m, 1261.1m, 1261.26m, 1263.52m, 1264m, 1264.86m, 1264.52m, 1264.04m, 1264.98m, 1266.85m, 1267.93m, 1265.79m, 1266.83m, 1266.93m, 1267.49m, 1266.84m, 1266.75m, 1265.67m, 1264.12m, 1263.36m, 1264.1m, 1263.71m, 1264.6m, 1265m, 1265m, 1264.28m, 1264.64m, 1265.52m, 1265.67m, 1265.46m, 1265.36m, 1265.49m, 1265.6m, 1265.38m, 1265.37m, 1264.68m, 1263.98m, 1264.75m, 1265.1m, 1266m, 1266.34m, 1266.22m, 1264.06m, 1263.03m, 1263.04m, 1261.88m, 1262.14m, 1261.77m, 1261m, 1260.89m, 1260.72m, 1263.04m, 1263.1m, 1262.93m, 1262.81m, 1263.68m, 1263.31m, 1262.4m, 1263.43m, 1263.6m, 1264.01m, 1264.16m, 1263.89m, 1263.45m, 1263.41m }
            });

            stockList.Add(new Stock
            {
                Symbol = "IBM",
                Name = "International Business Machines Corporation",
                Price = 135.44m,
                DayChange = 0.91m,
                ChangePercentage = 0.68m,
                Volume = 2543592,
                VolumeAvg = 5996562,
                MarketCap = 119982915584,
                IsCategorized = false,
                PricePerEarningRatio = 14.23m,
                IntraDayChart = new List<decimal> { 134.52m, 134.76m, 134.94m, 134.59m, 134.44m, 134.35m, 134.45m, 134.42m, 134.39m, 134.52m, 134.84m, 135.26m, 134.93m, 134.77m, 134.82m, 134.88m, 135.34m, 135.29m, 135.45m, 135.43m, 135.36m, 135.7m, 135.72m, 135.89m, 135.9m, 135.75m, 135.72m, 135.82m, 135.74m, 135.76m, 135.65m, 135.5m, 135.46m, 135.55m, 135.64m, 135.59m, 135.55m, 135.59m, 135.51m, 135.4m, 135.46m, 135.44m, 135.46m, 135.49m, 135.48m, 135.49m, 135.48m, 135.37m, 135.37m, 135.3m, 135.3m, 135.32m, 135.31m, 135.35m, 135.36m, 135.18m, 135.25m, 135.43m, 135.55m, 135.5m, 135.43m, 135.32m, 135.29m, 135.28m, 135.28m, 135.4m, 135.4m, 135.34m, 135.38m, 135.37m, 135.35m, 135.39m, 135.44m, 135.43m, 135.48m, 135.43m, 135.41m, 135.43m }
            });

            stockList.Add(new Stock
            {
                Symbol = "INTC",
                Name = "Intel Corporation",
                Price = 56.46m,
                DayChange = 1.99m,
                ChangePercentage = 3.64m,
                Volume = 56704514,
                VolumeAvg = 16469900,
                MarketCap = 252583968768,
                IsCategorized = false,
                PricePerEarningRatio = 13.11m,
                IntraDayChart = new List<decimal> { 54.61m, 55.48m, 55.38m, 55.4m, 55.68m, 55.71m, 55.87m, 55.93m, 55.85m, 55.9m, 55.96m, 55.94m, 55.94m, 55.94m, 55.85m, 55.58m, 55.92m, 55.9m, 55.99m, 55.98m, 55.93m, 56.11m, 56.15m, 56.4m, 56.33m, 56.2m, 55.97m, 56.17m, 56.34m, 56.17m, 56.21m, 56.18m, 56.14m, 56.14m, 56.22m, 56.19m, 56.25m, 56.07m, 56.1m, 56.19m, 56.14m, 56.09m, 56.03m, 56.08m, 56.13m, 56.22m, 56.24m, 56.22m, 56.23m, 56.15m, 56.26m, 56.37m, 56.31m, 56.31m, 56.23m, 56.19m, 56.22m, 56.29m, 56.34m, 56.33m, 56.35m, 56.25m, 56.22m, 56.18m, 56.19m, 56.22m, 56.19m, 56.25m, 56.28m, 56.39m, 56.41m, 56.46m, 56.53m, 56.45m, 56.43m, 56.37m, 56.4m, 56.6m }
            });

            stockList.Add(new Stock
            {
                Symbol = "INTU",
                Name = "Intuit Inc.",
                Price = 257.67m,
                DayChange = -1.99m,
                ChangePercentage = -0.77m,
                Volume = 1038001,
                VolumeAvg = 1170162,
                MarketCap = 67013271552,
                IsCategorized = false,
                PricePerEarningRatio = 43.75m,
                IntraDayChart = new List<decimal> { 259.8m, 258.72m, 258.6m, 259.23m, 259.13m, 258.44m, 258.75m, 259.33m, 259.71m, 259.47m, 259.68m, 259.95m, 259.79m, 259.05m, 259.1m, 258.85m, 259.25m, 258.8m, 258.9m, 258.83m, 258.99m, 259.42m, 259.41m, 259.01m, 258.94m, 258.98m, 259.07m, 258.93m, 258.87m, 258.76m, 258.64m, 258.04m, 257.73m, 257.94m, 258.08m, 257.92m, 258.15m, 258.01m, 257.96m, 258.01m, 258.18m, 258.07m, 258.07m, 257.97m, 257.9m, 258.01m, 258.01m, 257.83m, 257.77m, 257.46m, 257.64m, 257.78m, 257.74m, 257.58m, 257.5m, 257.19m, 257.26m, 257.2m, 257.13m, 257.06m, 257.22m, 256.83m, 256.94m, 257.04m, 256.81m, 257.05m, 257.08m, 256.97m, 256.86m, 257.14m, 257.15m, 257.2m, 257.29m, 257.47m, 257.39m, 257.56m, 257.4m, 257.81m }
            });

            stockList.Add(new Stock
            {
                Symbol = "JPM",
                Name = "JPMorgan Chase & Co.",
                Price = 125.73m,
                DayChange = -0.11m,
                ChangePercentage = -0.09m,
                Volume = 7792212,
                VolumeAvg = 10052585,
                MarketCap = 394352164864,
                IsCategorized = false,
                PricePerEarningRatio = 12.41m,
                IntraDayChart = new List<decimal> { 125.86m, 125.75m, 126.07m, 125.8m, 125.74m, 125.78m, 125.52m, 125.68m, 125.78m, 125.78m, 125.69m, 125.68m, 125.47m, 125.29m, 125.35m, 125.44m, 125.52m, 125.57m, 125.6m, 125.57m, 125.56m, 125.52m, 125.29m, 125.31m, 125.22m, 125.34m, 125.24m, 125.05m, 124.98m, 125.07m, 125.08m, 125.11m, 125.07m, 125.14m, 125.26m, 125.36m, 125.45m, 125.35m, 125.45m, 125.44m, 125.44m, 125.54m, 125.64m, 125.51m, 125.43m, 125.4m, 125.49m, 125.46m, 125.48m, 125.49m, 125.44m, 125.39m, 125.49m, 125.45m, 125.57m, 125.28m, 125.44m, 125.46m, 125.59m, 125.62m, 125.65m, 125.74m, 126m, 126.05m, 126.08m, 126.03m, 125.96m, 125.79m, 125.75m, 125.69m, 125.93m, 125.82m, 125.82m, 125.73m, 125.67m, 125.51m, 125.72m, 125.75m }
            });

            stockList.Add(new Stock
            {
                Symbol = "MSFT",
                Name = "Microsoft Corporation",
                Price = 140.73m,
                DayChange = 1.04m,
                ChangePercentage = 0.75m,
                Volume = 20464765,
                VolumeAvg = 26070562,
                MarketCap = 1094723174400,
                IsCategorized = false,
                PricePerEarningRatio = 26.55m,
                IntraDayChart = new List<decimal> { 139.48m, 139.56m, 139.57m, 139.89m, 140.3m, 140.12m, 140.35m, 140.58m, 140.98m, 140.71m, 140.77m, 140.77m, 140.69m, 140.61m, 140.65m, 140.62m, 140.82m, 140.82m, 140.82m, 140.84m, 140.62m, 140.92m, 141.1m, 141.08m, 140.78m, 140.83m, 141.07m, 141.01m, 140.97m, 141.02m, 140.84m, 140.72m, 140.69m, 140.7m, 140.77m, 140.71m, 140.73m, 140.62m, 140.55m, 140.65m, 140.69m, 140.66m, 140.68m, 140.66m, 140.68m, 140.79m, 140.84m, 140.71m, 140.57m, 140.51m, 140.58m, 140.65m, 140.66m, 140.68m, 140.59m, 140.51m, 140.45m, 140.48m, 140.46m, 140.44m, 140.39m, 140.26m, 140.29m, 140.26m, 140.25m, 140.36m, 140.41m, 140.35m, 140.41m, 140.38m, 140.47m, 140.54m, 140.49m, 140.52m, 140.43m, 140.42m, 140.38m, 140.52m }
            });

            stockList.Add(new Stock
            {
                Symbol = "NVDA",
                Name = "NVIDIA Corporation",
                Price = 204.54m,
                DayChange = 3,
                ChangePercentage = 1.49m,
                Volume = 10357677,
                VolumeAvg = 8645212,
                MarketCap = 122178895872,
                IsCategorized = false,
                PricePerEarningRatio = 46.12m,
                IntraDayChart = new List<decimal> { 201.49m, 202.51m, 202.97m, 201.91m, 202.82m, 202.28m, 201.87m, 201.42m, 202.09m, 202.28m, 201.57m, 202.62m, 202.68m, 202.38m, 202.45m, 202.53m, 203.34m, 203.21m, 203.85m, 204.02m, 204.29m, 204.48m, 204.57m, 204.88m, 204.4m, 204.41m, 204.4m, 204.63m, 204.89m, 205.22m, 204.87m, 204.64m, 204.23m, 204.36m, 204.67m, 204.61m, 204.59m, 204.07m, 204.16m, 204.2m, 204.29m, 203.85m, 203.76m, 203.75m, 204m, 204.4m, 204.45m, 204.57m, 204.75m, 204.55m, 204.51m, 204.9m, 204.9m, 204.62m, 204.52m, 203.82m, 203.72m, 203.82m, 203.87m, 203.81m, 203.77m, 203.35m, 203.47m, 203.75m, 203.87m, 203.93m, 203.73m, 203.69m, 203.86m, 203.84m, 204.38m, 204.71m, 204.8m, 204.66m, 204.52m, 204.57m, 204.33m, 204.49m }
            });

            stockList.Add(new Stock
            {
                Symbol = "ORCL",
                Name = "Oracle Corporation",
                Price = 54.17m,
                DayChange = 0.09m,
                ChangePercentage = 0.17m,
                Volume = 5741404,
                VolumeAvg = 9189612,
                MarketCap = 177814110208,
                IsCategorized = false,
                PricePerEarningRatio = 17.73m,
                IntraDayChart = new List<decimal> { 54.04m, 54.27m, 54.25m, 54.19m, 54.23m, 54.24m, 54.24m, 54.29m, 54.35m, 54.34m, 54.35m, 54.36m, 54.28m, 54.24m, 54.18m, 54.13m, 54.22m, 54.21m, 54.21m, 54.21m, 54.18m, 54.28m, 54.34m, 54.38m, 54.38m, 54.36m, 54.38m, 54.38m, 54.38m, 54.42m, 54.39m, 54.28m, 54.3m, 54.28m, 54.27m, 54.26m, 54.27m, 54.23m, 54.22m, 54.23m, 54.25m, 54.2m, 54.2m, 54.26m, 54.27m, 54.28m, 54.26m, 54.26m, 54.24m, 54.19m, 54.22m, 54.22m, 54.22m, 54.2m, 54.2m, 54.13m, 54.16m, 54.15m, 54.14m, 54.1m, 54.08m, 54.01m, 54.04m, 54.05m, 54.04m, 54.1m, 54.12m, 54.1m, 54.12m, 54.12m, 54.13m, 54.16m, 54.18m, 54.19m, 54.15m, 54.15m, 54.13m, 54.13m }
            });

            stockList.Add(new Stock
            {
                Symbol = "PRGS",
                Name = "Progress Software Corporation",
                Price = 40.31m,
                DayChange = 0.43m,
                ChangePercentage = 1.08m,
                Volume = 119189,
                VolumeAvg = 166171,
                MarketCap = 1805307648,
                IsCategorized = false,
                PricePerEarningRatio = 33.76m,
                IntraDayChart = new List<decimal> { 39.86m, 39.69m, 39.69m, 39.72m, 39.74m, 39.68m, 39.5m, 39.45m, 39.55m, 39.55m, 39.65m, 39.65m, 39.63m, 39.76m, 39.79m, 39.89m, 39.87m, 39.86m, 39.85m, 39.85m, 39.85m, 39.85m, 39.85m, 39.86m, 39.87m, 39.92m, 39.88m, 39.86m, 39.83m, 39.82m, 39.83m, 39.83m, 39.95m, 39.94m, 39.9m, 39.94m, 39.94m, 39.94m, 39.95m, 39.97m, 39.96m, 39.94m, 39.93m, 39.91m, 39.89m, 39.92m, 39.93m, 39.96m, 39.95m, 39.93m, 39.92m, 39.93m, 39.9m, 39.96m, 39.88m, 39.9m, 39.88m, 39.94m, 39.98m, 39.95m, 39.91m, 39.9m, 39.93m, 39.97m, 40.18m, 40.18m, 40.19m, 40.19m, 40.19m, 40.24m, 40.35m, 40.28m, 40.3m, 40.27m, 40.33m, 40.3m, 40.33m, 40.29m }
            });

            stockList.Add(new Stock
            {
                Symbol = "QCOM",
                Name = "QUALCOMM Incorporated",
                Price = 80.17m,
                DayChange = 0.94m,
                ChangePercentage = 1.19m,
                Volume = 5950509,
                VolumeAvg = 5573175,
                MarketCap = 97459462144,
                IsCategorized = false,
                PricePerEarningRatio = 29.34m,
                IntraDayChart = new List<decimal> { 79.2m, 79.12m, 79.34m, 79.07m, 79.09m, 79.15m, 79.1m, 79.08m, 79.15m, 79.21m, 79.22m, 79.32m, 79.35m, 79.28m, 79.24m, 79.13m, 79.31m, 79.33m, 79.39m, 79.43m, 79.55m, 79.55m, 79.6m, 79.82m, 79.83m, 79.89m, 79.91m, 79.96m, 80m, 80.08m, 80.06m, 80.02m, 79.98m, 80m, 80.03m, 79.98m, 80.01m, 79.87m, 79.95m, 79.97m, 79.99m, 79.91m, 79.94m, 79.9m, 79.92m, 79.98m, 79.99m, 79.98m, 79.99m, 79.9m, 79.91m, 79.98m, 79.92m, 79.92m, 79.95m, 79.85m, 80.01m, 80.1m, 80.15m, 80.11m, 80.07m, 79.93m, 79.84m, 79.84m, 79.82m, 79.95m, 79.93m, 79.83m, 79.82m, 79.95m, 79.98m, 80.14m, 80.16m, 80.1m, 80.1m, 80.12m, 80.14m, 80.14m }
            });

            stockList.Add(new Stock
            {
                Symbol = "SAP",
                Name = "SAP SE",
                Price = 131.87m,
                DayChange = 0.34m,
                ChangePercentage = 0.26m,
                Volume = 558142,
                VolumeAvg = 1046450,
                MarketCap = 162669559808,
                IsCategorized = false,
                PricePerEarningRatio = 31.86m,
                IntraDayChart = new List<decimal> { 131.43m, 131.37m, 131.06m, 131.03m, 131.23m, 131.25m, 131.32m, 131.33m, 131.59m, 131.67m, 131.72m, 131.82m, 131.79m, 131.81m, 131.76m, 131.78m, 131.85m, 131.84m, 131.95m, 131.79m, 131.77m, 131.83m, 131.92m, 132.02m, 131.95m, 132.08m, 131.99m, 132.05m, 131.96m, 131.94m, 131.75m, 131.73m, 131.73m, 131.72m, 131.71m, 131.78m, 131.73m, 131.67m, 131.73m, 131.74m, 131.82m, 131.79m, 131.83m, 131.83m, 131.82m, 131.79m, 131.77m, 131.75m, 131.7m, 131.72m, 131.77m, 131.74m, 131.73m, 131.67m, 131.65m, 131.61m, 131.62m, 131.65m, 131.62m, 131.63m, 131.55m, 131.56m, 131.6m, 131.58m, 131.69m, 131.69m, 131.65m, 131.61m, 131.65m, 131.66m, 131.7m, 131.7m, 131.71m, 131.68m, 131.66m, 131.67m, 131.77m }
            });

            stockList.Add(new Stock
            {
                Symbol = "SNAP",
                Name = "Snap Inc.",
                Price = 13.52m,
                DayChange = 0.29m,
                ChangePercentage = 2.19m,
                Volume = 54048642,
                VolumeAvg = 44871025,
                MarketCap = 18647865344,
                IsCategorized = false,
                PricePerEarningRatio = null,
                IntraDayChart = new List<decimal> { 13.22m, 12.93m, 12.94m, 12.94m, 13.03m, 13.06m, 13.06m, 13.02m, 13.06m, 13.08m, 13.07m, 13.09m, 13.1m, 13.15m, 13.16m, 13.27m, 13.2m, 13.33m, 13.44m, 13.52m, 13.58m, 13.6m, 13.48m, 13.54m, 13.53m, 13.6m, 13.55m, 13.56m, 13.58m, 13.65m, 13.58m, 13.6m, 13.58m, 13.51m, 13.54m, 13.58m, 13.54m, 13.54m, 13.55m, 13.54m, 13.56m, 13.61m, 13.61m, 13.55m, 13.55m, 13.52m, 13.48m, 13.47m, 13.47m, 13.38m, 13.42m, 13.44m, 13.43m, 13.39m, 13.42m, 13.41m, 13.4m, 13.41m, 13.38m, 13.4m, 13.39m, 13.41m, 13.44m, 13.43m, 13.49m, 13.51m, 13.51m, 13.54m, 13.56m, 13.59m, 13.58m, 13.58m, 13.57m, 13.53m, 13.51m, 13.49m, 13.48m, 13.51m }
            });

            stockList.Add(new Stock
            {
                Symbol = "SNE",
                Name = "Sony Corporation",
                Price = 58.51m,
                DayChange = 0.47m,
                ChangePercentage = 0.81m,
                Volume = 670753,
                VolumeAvg = 757475,
                MarketCap = 71632035840,
                IsCategorized = false,
                PricePerEarningRatio = 12.3m,
                IntraDayChart = new List<decimal> { 58.11m, 58.09m, 58.15m, 58.11m, 58.19m, 58.17m, 58.16m, 58.2m, 58.27m, 58.24m, 58.24m, 58.25m, 58.29m, 58.25m, 58.28m, 58.34m, 58.41m, 58.38m, 58.4m, 58.35m, 58.35m, 58.38m, 58.47m, 58.48m, 58.47m, 58.52m, 58.53m, 58.59m, 58.58m, 58.57m, 58.52m, 58.5m, 58.48m, 58.48m, 58.48m, 58.45m, 58.47m, 58.39m, 58.38m, 58.39m, 58.42m, 58.43m, 58.43m, 58.39m, 58.42m, 58.4m, 58.39m, 58.43m, 58.46m, 58.42m, 58.47m, 58.45m, 58.43m, 58.46m, 58.47m, 58.4m, 58.45m, 58.46m, 58.5m, 58.5m, 58.47m, 58.44m, 58.46m, 58.48m, 58.5m, 58.49m, 58.5m, 58.52m, 58.52m, 58.55m, 58.53m, 58.54m, 58.54m, 58.58m, 58.57m, 58.58m, 58.56m, 58.58m }
            });

            stockList.Add(new Stock
            {
                Symbol = "TSM",
                Name = "Taiwan Semiconductor Manufacturing Company Limited",
                Price = 51.13m,
                DayChange = 0.36m,
                ChangePercentage = 0.71m,
                Volume = 5965678,
                VolumeAvg = 9484987,
                MarketCap = 250063552512,
                IsCategorized = false,
                PricePerEarningRatio = 22.93m,
                IntraDayChart = new List<decimal> { 50.79m, 50.85m, 50.92m, 50.9m, 50.92m, 50.91m, 50.86m, 50.78m, 50.73m, 50.82m, 50.85m, 50.87m, 50.85m, 50.88m, 50.97m, 50.95m, 51.05m, 51.06m, 50.99m, 51.01m, 51.03m, 50.93m, 50.92m, 51m, 51m, 50.92m, 50.97m, 50.98m, 50.97m, 50.94m, 50.93m, 50.9m, 50.92m, 50.92m, 50.96m, 50.99m, 51m, 50.97m, 51.04m, 51.03m, 51.01m, 51.05m, 51.05m, 51.06m, 51.06m, 51.06m, 51.05m, 51.03m, 51.03m, 51.01m, 50.99m, 51.03m, 51.04m, 51.04m, 51.04m, 50.97m, 50.96m, 50.96m, 50.99m, 51m, 51m, 50.97m, 50.99m, 51.01m, 51.03m, 51.06m, 51.04m, 51.03m, 51.07m, 51.03m, 51.04m, 51.12m, 51.14m, 51.1m, 51.11m, 51.09m, 51.1m, 51.15m }
            });

            stockList.Add(new Stock
            {
                Symbol = "TWTR",
                Name = "Twitter, Inc.",
                Price = 30.75m,
                DayChange = -0.64m,
                ChangePercentage = -2.07m,
                Volume = 105075360,
                VolumeAvg = 10571275,
                MarketCap = 23770302464,
                IsCategorized = false,
                PricePerEarningRatio = 10.16m,
                IntraDayChart = new List<decimal> { 30.95m, 30.53m, 30.56m, 30.64m, 30.53m, 30.39m, 30.26m, 30.13m, 30.03m, 29.99m, 30.11m, 30.16m, 30.14m, 30.02m, 30.01m, 30m, 30.11m, 30.16m, 30.22m, 30.17m, 30.15m, 30.2m, 30.23m, 30.33m, 30.35m, 30.3m, 30.39m, 30.44m, 30.48m, 30.55m, 30.34m, 30.47m, 30.37m, 30.42m, 30.44m, 30.47m, 30.51m, 30.56m, 30.48m, 30.52m, 30.53m, 30.63m, 30.58m, 30.51m, 30.45m, 30.52m, 30.52m, 30.49m, 30.33m, 30.34m, 30.29m, 30.3m, 30.31m, 30.26m, 30.31m, 30.2m, 30.25m, 30.15m, 30.1m, 30.07m, 30.08m, 30.06m, 30.07m, 30.14m, 30.17m, 30.13m, 30.14m, 30.13m, 30.15m, 30.18m, 30.2m, 30.24m, 30.21m, 30.32m, 30.31m, 30.33m, 30.33m, 30.31m }
            });

            stockList.Add(new Stock
            {
                Symbol = "TXN",
                Name = "Texas Instruments Incorporated",
                Price = 120.51m,
                DayChange = 1.21m,
                ChangePercentage = 1.01m,
                Volume = 4106890,
                VolumeAvg = 6018987,
                MarketCap = 112698302464,
                IsCategorized = false,
                PricePerEarningRatio = 22.37m,
                IntraDayChart = new List<decimal> { 119.32m, 119.08m, 119.2m, 118.7m, 118.93m, 119.07m, 118.95m, 118.92m, 118.99m, 118.98m, 119.1m, 118.98m, 118.92m, 118.8m, 118.84m, 118.81m, 119.13m, 119.21m, 119.36m, 119.32m, 119.32m, 119.34m, 119.31m, 119.61m, 119.58m, 119.79m, 119.85m, 119.97m, 120m, 119.92m, 119.78m, 119.71m, 119.78m, 119.97m, 120.08m, 120.07m, 120.22m, 120.14m, 120.18m, 120.25m, 120.25m, 120.13m, 120.28m, 120.32m, 120.38m, 120.46m, 120.55m, 120.52m, 120.59m, 120.37m, 120.39m, 120.56m, 120.43m, 120.51m, 120.43m, 120.24m, 120.29m, 120.23m, 120.21m, 120.22m, 120.24m, 120.03m, 120.12m, 120.17m, 120.24m, 120.28m, 120.32m, 120.33m, 120.25m, 120.29m, 120.35m, 120.5m, 120.5m, 120.5m, 120.39m, 120.46m, 120.37m, 120.53m }
            });

            stockList.Add(new Stock
            {
                Symbol = "XOM",
                Name = "Exxon Mobil Corporation",
                Price = 67.72m,
                DayChange = -0.54m,
                ChangePercentage = -0.79m,
                Volume = 11995831,
                VolumeAvg = 10012842,
                MarketCap = 286530764800,
                IsCategorized = false,
                PricePerEarningRatio = 16.32m,
                IntraDayChart = new List<decimal> { 68.28m, 68.18m, 68.1m, 68.04m, 68.04m, 68.03m, 68m, 68.1m, 68.11m, 68.02m, 68.07m, 68.01m, 68m, 68.07m, 67.97m, 68m, 67.98m, 67.99m, 67.93m, 67.88m, 67.85m, 67.82m, 67.81m, 67.82m, 67.77m, 67.81m, 67.77m, 67.72m, 67.71m, 67.64m, 67.71m, 67.78m, 67.71m, 67.71m, 67.68m, 67.67m, 67.7m, 67.61m, 67.62m, 67.59m, 67.62m, 67.61m, 67.7m, 67.71m, 67.7m, 67.62m, 67.6m, 67.63m, 67.6m, 67.57m, 67.57m, 67.5m, 67.47m, 67.5m, 67.46m, 67.36m, 67.41m, 67.4m, 67.43m, 67.51m, 67.39m, 67.31m, 67.3m, 67.36m, 67.43m, 67.5m, 67.55m, 67.54m, 67.54m, 67.53m, 67.54m, 67.56m, 67.53m, 67.5m, 67.51m, 67.49m, 67.64m, 67.74m }
            });

            return stockList;
        }
    }
}
