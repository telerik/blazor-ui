using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelerikBlazor.Shared;

namespace TelerikBlazor.Server.DataAccess
{
    public class ProductsDataAccessLayer
    {
        NorthwindContext db = new NorthwindContext();

        public IEnumerable<Product> GetProducts()
        {
            try
            {
                return db.Products.ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
