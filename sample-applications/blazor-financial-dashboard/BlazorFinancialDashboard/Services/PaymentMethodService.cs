using BlazorFinancialDashboard.Data;

namespace BlazorFinancialDashboard.Services
{
	public class PaymentMethodService
	{
        private List<PaymentMethod> Data { get; set; }

        public async Task<List<PaymentMethod>> Read()
        {
            await Task.CompletedTask;

            return Data;
        }

        private List<PaymentMethod> GenerateData()
        {
            var rnd = Random.Shared;

            return new List<PaymentMethod>()
            {
                new PaymentMethod() { Id = 1, Name = "Credit Card" },
                new PaymentMethod() { Id = 2, Name = "Debit Card" },
                new PaymentMethod() { Id = 3, Name = "Bank Transfer" }
            };
        }

        public PaymentMethodService()
		{
            Data ??= GenerateData();
        }
    }
}
