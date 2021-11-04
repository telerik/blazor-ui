using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikBlazorGrid_Dapper.DataAccess.Enums;

namespace TelerikBlazorGrid_Dapper.DataAccess.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool OnSale { get; set; }
        public ProductCategory Category { get; set; }
        public DateTime Created { get; set; }
    }
}
