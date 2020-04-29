using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace export_to_xlsx_hierarchy.Models
{
    public class Product
    {
        [Display(AutoGenerateField = false)]
        public int ProductId { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(AutoGenerateField = false)]
        public int SupplierId { get; set; }

        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Units in stock")]
        public short UnitsInStock { get; set; }

        [Display(Name = "Discontinued")]
        public bool Discontinued { get; set; }

        [Display(Name = "Date created")]
        public DateTime CreatedAt { get; set; }

        [Display(AutoGenerateField = false)]
        public List<OrderDetails> OrderDetails { get; set; }
    }
}