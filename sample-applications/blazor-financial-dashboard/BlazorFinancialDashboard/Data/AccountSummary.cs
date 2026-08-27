namespace BlazorFinancialDashboard.Data;

public class AccountSummary
{
    public string AccountName { get; set; } = string.Empty;
    public string AccountNumber { get; set; } = string.Empty;
    public string AccountType { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public decimal AvailableCash { get; set; }
    public string Status { get; set; } = string.Empty;
}
