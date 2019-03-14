using TelerikBlazor.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelerikBlazor.Server;
using TelerikBlazor.Server.DataAccess;

namespace TelerikBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    public class NorthwindDataController : Controller
    {
        ProductsDataAccessLayer productsDataAccess = new ProductsDataAccessLayer();

        [HttpGet("[action]")]
        public IEnumerable<Product> Products()
        {
            return productsDataAccess.GetProducts();
        }
    }
}
