using BlazingCoffee.Shared;
using BlazingCoffee.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telerik.DataSource;
using Telerik.DataSource.Extensions;

namespace BlazingCoffee.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly CoffeeContext _context;

        public SalesController(CoffeeContext context)
        {
            _context = context;
        }

        // GET: api/Sales
        [HttpPost]
        public async Task<ActionResult<DataEnvelope<Sale>>> GetSales([FromBody] DataSourceRequest request)
        {
            DataSourceResult result = await _context.Sales.ToDataSourceResultAsync(request);
            var data = new DataEnvelope<Sale>
            {
                CurrentPageData = result.Data.OfType<Sale>().ToList(),
                TotalItemCount = result.Total

            };
            return data;
        }

        [HttpGet]
        [Route("RegionalSalesByDate/{startDate:datetime}/{endDate:datetime}")]
        public async Task<ActionResult<IEnumerable<SalesByDateViewModel>>> GetRegionalSalesByDate(DateTime startDate, DateTime endDate)
        {
            var salesByRegion = _context.Sales
                                .Where(sale=> sale.TransactionDate > startDate)
                                .Where(sale=> sale.TransactionDate < endDate)
                                .GroupBy(sale => new { sale.Region, sale.TransactionDate.Year, sale.TransactionDate.Month })
                                .Select(group => new SalesByDateViewModel
                                {
                                    Date = new DateTime(group.Key.Year, group.Key.Month, 1),
                                    Region = group.Key.Region,
                                    Sum = group.Sum(sale => sale.Amount)
                                });

            return await salesByRegion.ToListAsync();
        }

        // GET: api/Sales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSale(int id)
        {
            var sale = await _context.Sales.FindAsync(id);

            if (sale == null)
            {
                return NotFound();
            }

            return sale;
        }


        private bool SaleExists(int id)
        {
            return _context.Sales.Any(e => e.Id == id);
        }
    }
}
