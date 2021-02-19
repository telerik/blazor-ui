using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace custom_popup_form.Data
{
    public class Employee
    {
        [Editable(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter a name")]
        [StringLength(10, ErrorMessage = "That name is too long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter a last name")]
        [StringLength(10, ErrorMessage = "That name is too long")]
        public string LastName { get; set; }
        [Required]
        [Range(typeof(DateTime), "1/1/1999", "1/12/2019",
            ErrorMessage = "Value for {0} must be between {1:dd MMM yyyy} and {2:dd MMM yyyy}")]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }
        public bool OnLeave { get; set; }
    }
}
