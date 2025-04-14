using System.ComponentModel.DataAnnotations;

namespace BlazorFinancialDashboard.Data
{
	public class Card
	{
		public int Id { get; set; }

        [Required]
        public string Number { get; set; } = string.Empty;

        [Required]
        public string BankName { get; set; } = string.Empty;

        [Required]
        public DateTime ExpiryDate { get; set; } = DateTime.Today.AddMonths(1);

        [Required]
        public string HolderName { get; set; } = string.Empty;
	}
}
