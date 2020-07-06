using BlazorFinancePortfolio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorFinancePortfolio.Services
{
    public class CurrenciesService
    {
        public Task<List<Currency>> GetCurrenciesAsync()
        {
            var data = new List<Currency>();
            data.Add(new Currency { Multiplier = 1, Name = "United States Dollar", Symbol = "USD", Sign = "$" });
            data.Add(new Currency { Multiplier = 0.9m, Name = "Euro", Symbol = "EUR", Sign = "€" });
            data.Add(new Currency { Multiplier = 0.76m, Name = "Pound sterling", Symbol = "GBP", Sign = "£" });

            return Task.FromResult(data);
        }
    }
}
