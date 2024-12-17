using System;
using System.ComponentModel.DataAnnotations;

namespace TelerikBlazorServerAdmin.Models.Sales
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        public string Region { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string StoreId { get; set; } = string.Empty;
        public DateTime TransactionDate { get; set; }
        public int TransactionId { get; set; }
        public string ProductGroup { get; set; } = string.Empty;
        public string Sku { get; set; } = string.Empty;
        public double Amount { get; set; }
        public int PromotionId { get; set; }
        public int CustomerInfo { get; set; }
        public string PaymentType { get; set; } = string.Empty;
    }
}
