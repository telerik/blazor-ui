using BlazorFinancialDashboard.Data;

namespace BlazorFinancialDashboard.Services
{
    public class TransactionService
    {
        private List<Transaction> Data { get; set; }

        private readonly List<string> Categories = ["Groceries", "Entertainment", "Shopping", "Travel", "Health", "Other"];

        private readonly List<string> Merchants = ["Shopping World", "Online Market", "eShop", "Best Deal", "Central Mall", "City Mall"];

        public async Task<List<Transaction>> Read()
        {
            await Task.CompletedTask;

            return Data;
        }

        private List<Transaction> GenerateData()
        {
            var rnd = Random.Shared;

            return Enumerable.Range(1, 500).Select(i => {
                int categoryIndex = rnd.Next(0, Categories.Count);
                var t = new Transaction()
                {
                    Id = i,
                    Amount = rnd.Next(20, 1000) * 1.23m * (Categories.Count - categoryIndex),
                    Category = Categories[categoryIndex],
                    Date = DateTime.Now.AddDays(-rnd.Next(1, 365)).AddMinutes(-rnd.Next(1, 24 * 60)),
                    Merchant = Merchants[rnd.Next(0, Merchants.Count)],
                    PaymentMethodId = rnd.Next(1, 4),
                    Status = GetTransactionStatusWithProbability(),
                };

                t.Hash = string.Concat("0x", t.GetHashCode().ToString("X").ToLowerInvariant());
                t.HashFrom = string.Concat("0x", (rnd.Next(10_000, 100_000)).GetHashCode().ToString("X").ToLowerInvariant());
                t.HashTo = string.Concat("0x", (rnd.Next(10_000, 100_000)).GetHashCode().ToString("X").ToLowerInvariant());

                return t;
            }).ToList();
        }

        private TransactionStatus GetTransactionStatusWithProbability()
        {
            int number = Random.Shared.Next(0, 100);

            if (number < 67)
            {
                return TransactionStatus.Published;
            }
            else if (number < 84)
            {
                return TransactionStatus.Pending;
            }
            else
            {
                return TransactionStatus.Postponed;
            }
        }

        public TransactionService()
        {
            Data = GenerateData();
        }
    }
}
