using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormValidation.Models
{
    public class JobApplicationForm
    {
        [Required(ErrorMessage = "Enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter your email")]
        [EmailAddress(ErrorMessage = "Please provide a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please upload a resume - PDF or DOCX files only")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Please upload a resume - PDF or DOCX files only")]
        public bool IsResumeValid { get; set; }
    }
}
