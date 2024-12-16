using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelerikBlazorWASMAdmin.Server.Data;
using TelerikBlazorWASMAdmin.Shared.Models.Sales;

namespace TelerikBlazorWASMAdmin.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IDataService _dataService;
        public SalesController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public Task<List<SalesByDateViewModel>> GetSales()
        {
            var result = _dataService.GetSales()
                .Where(sale => sale.TransactionDate > new DateTime(2019, 12, 30) && sale.TransactionDate < new DateTime(2019, 12, 31))
                .Select(s => new SalesByDateViewModel
                {
                    Sum = s.Amount,
                    SumOne = s.Amount + 100,
                    SumTwo = s.Amount + 200,
                    SumThree = s.Amount + 300,
                    X = s.Id + 500,
                    Y = (int)s.Amount + 250,
                    Size = (int)s.Amount + 600,
                })
                .ToList();
            return Task.FromResult(result);
        }

        [HttpGet]
        public Task<List<SalesByDateViewModel>> GetSalesPerformance()
        {
            var result = _dataService.GetSales()
                .Where(sale => sale.TransactionDate > new DateTime(2019, 12, 30) && sale.TransactionDate < new DateTime(2019, 12, 31))
                .Select(s => new SalesByDateViewModel
                {
                    Sum = s.Amount,
                    SumOne = s.Amount + 100,
                    SumTwo = s.Amount + 200,
                    SumThree = s.Amount + 300,
                    SegmentValue = s.Amount,
                    SegmentValueOne = s.Amount + 1,
                    SegmentValueTwo = s.Amount + 2,
                    SegmentValueThree = s.Amount + 3,
                    Cost = "Product Region- " + s.Region + $" {s.Id}"
                })
                .ToList();
            result.RemoveRange(3, 10);
            return Task.FromResult(result);
        }
    }
}
