namespace TelerikBlazorServerAdmin.Models.Sales
{
    public class SalesImportDTO
    {
        public string Region { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string StoreId { get; set; } = string.Empty;
        public string TransactionHour { get; set; } = string.Empty;
        public string TransactionDate { get; set; } = string.Empty;
        public int TransactionId { get; set; }
        public string ProductGroup { get; set; } = string.Empty;
        public string Product { get; set; } = string.Empty;
        public double Amount { get; set; }
        public int PromotionId { get; set; }
        public int CustomerInfo { get; set; }
        public string PaymentType { get; set; } = string.Empty;
    }
}
