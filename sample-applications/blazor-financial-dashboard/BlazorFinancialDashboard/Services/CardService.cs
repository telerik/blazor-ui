using BlazorFinancialDashboard.Data;

namespace BlazorFinancialDashboard.Services
{
    public class CardService
    {
        private List<Card> Data { get; set; } = [];

        private Card DefaultCard { get; set; } = new()
        {
            Id = 1,
            BankName = "First Bank of USA",
            ExpiryDate = DateTime.Today.AddDays(5).AddMonths(1).AddYears(1),
            HolderName = "Maria Johnson",
            Number = "4165123498761234"
        };

        public async Task<Card> Read(int cardId)
        {
            await Task.CompletedTask;

            PopulateDummyData();

            return Data.First(x => x.Id == cardId);
        }

        public async Task<bool> Update(Card updatedCard)
        {
            await Task.CompletedTask;

            DefaultCard = updatedCard;

            return true;
        }

        private void PopulateDummyData()
        {
            Data = new List<Card>()
            {
                new Card()
                {
                    BankName = DefaultCard.BankName,
                    ExpiryDate = DefaultCard.ExpiryDate,
                    HolderName = DefaultCard.HolderName,
                    Id = DefaultCard.Id,
                    Number = DefaultCard.Number
                }
            };
        }
    }
}
