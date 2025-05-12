using Telerik.Blazor;

namespace BlazorFinancialDashboard.Data
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Merchant { get; set; } = string.Empty;
        public int PaymentMethodId { get; set; }
        public TransactionStatus Status { get; set; }
        public string Hash { get; set; } = string.Empty;
        public string HashFrom { get; set; } = string.Empty;
        public string HashTo { get; set; } = string.Empty;

        public string GetStatusThemeColor()
        {
            switch (Status)
            {
                case TransactionStatus.Published:
                    return ThemeConstants.Chip.ThemeColor.Success;
                case TransactionStatus.Postponed:
                    return ThemeConstants.Chip.ThemeColor.Error;
                default:
                    return ThemeConstants.Chip.ThemeColor.Warning;
            }
        }
    }
}
