using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RemoteValidationWasm.Shared
{
    public class Person
    {
        [Required(ErrorMessage = "Enter your first name")]
        [StringLength(10, ErrorMessage = "That name is too long")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter your last name")]
        [StringLength(15, ErrorMessage = "That name is too long")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "An email is required")]
        [EmailAddress(ErrorMessage = "Please provide a valid email address.")]
        public string Email { get; set; }

        public int? Gender { get; set; }


        [Required]
        [Range(typeof(DateTime), "1/1/2020", "1/12/2030",
            ErrorMessage = "Value for {0} must be between {1:dd MMM yyyy} and {2:dd MMM yyyy}")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Choose the team and technology you want to work on")]
        public string PreferredTeam { get; set; }
    }
}