using BlazorFinancialDashboard.Data;

namespace BlazorFinancialDashboard.Services;

public class AccountService
{
    private readonly AccountSummary Account = new()
    {
        AccountName = "Maria Johnson",
        AccountNumber = "•••• 4821",
        AccountType = "Personal investment account",
        Balance = 186_420.75m,
        AvailableCash = 24_680.10m,
        Status = "Active"
    };

    public async Task<AccountSummary> Read()
    {
        await Task.CompletedTask;
        return Account;
    }
}
