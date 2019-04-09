using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TelerikBlazor.Shared
{
    public class Person
    {
        [Required(ErrorMessage = "Must Have Employee Id")]
        public int? EmployeeId { get; set; }

        [Required(ErrorMessage = "Enter a name")]
        [StringLength(10, ErrorMessage = "That name is too long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter an int age")]
        [Range(0, 200, ErrorMessage = "Nobody is that old")]
        public int? AgeInYears { get; set; }
        
        [Required(ErrorMessage = "Enter a graduate grade.")]
        [Range(3, 6, ErrorMessage = "Grades vary between 3 and 6.")]
        public decimal? GraduateGrade { get; set; }

        [Required(ErrorMessage = "Enter a hire date")]
        [Range(typeof(DateTime), "10/10/2016", "10/10/2018", ErrorMessage = "Hire Date must be between 10/10/2016 and 10/10/2018")]
        public DateTime HireDate { get; set; }

        [Required(ErrorMessage = "Enter interview meeting")]
        [Range(typeof(DateTime), "03/03/2019", "03/10/2019", ErrorMessage = "Interview meeting should be between 03/03/2019 and 03/10/2019")]
        public DateTime MeetingDate { get; set; }
    }
}
