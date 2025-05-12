using System.ComponentModel.DataAnnotations;

namespace BlazorFinancialDashboard.Data
{
    public class User
    {
        public int Id { get; set; }

        public string Tag { get; set; } = string.Empty;

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public DateTime? BirthDate { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string PostalCode { get; set; } = string.Empty;

        [Required]
        public string Country { get; set; } = string.Empty;
    }
}
