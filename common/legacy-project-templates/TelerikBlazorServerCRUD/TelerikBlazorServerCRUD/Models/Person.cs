using System;
using System.ComponentModel.DataAnnotations;

namespace TelerikBlazorServerCRUD.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Enter your first name")]
        [StringLength(10, ErrorMessage = "That name is too long")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter your last name")]
        [StringLength(15, ErrorMessage = "That name is too long")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "An email is required")]
        [EmailAddress(ErrorMessage = "Please provide a valid email address.")]
        public string Email { get; set; } = string.Empty;

        public int? Gender { get; set; }


        [Required]
        [Range(typeof(DateTime), "1/1/2020", "1/12/2030",
            ErrorMessage = "Value for {0} must be between {1:dd MMM yyyy} and {2:dd MMM yyyy}")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Choose the team and technology you want to work on")]
        public string PreferredTeam { get; set; } = string.Empty;
    }
}