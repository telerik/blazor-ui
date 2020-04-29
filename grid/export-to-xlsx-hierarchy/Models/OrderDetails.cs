using System.ComponentModel.DataAnnotations;

namespace export_to_xlsx_hierarchy.Models
{
    public class OrderDetails
    {
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }

        [Display(Name = "Price")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Quantity")]
        public short Quantity { get; set; }

        [Display(Name = "Discount")]
        public float Discount { get; set; }

        [Display(AutoGenerateField = false)]
        public int ProductId { get; set; }
    }
}