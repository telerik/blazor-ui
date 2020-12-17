using custom_edit_form.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace custom_edit_form.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        [Range(typeof(DateTime), "1/1/1999", "1/12/2050",
            ErrorMessage = "Value for {0} must be between {1:dd MMM yyyy} and {2:dd MMM yyyy}")]
        [CompareDate(nameof(End), ErrorMessage = "The Start date must be before the End date.")]
        public DateTime Start { get; set; }

        [Required]
        [Range(typeof(DateTime), "1/1/1999", "1/12/2050",
            ErrorMessage = "Value for {0} must be between {1:dd MMM yyyy} and {2:dd MMM yyyy}")]
        public DateTime End { get; set; }

        public bool IsAllDay { get; set; }

        public string Notes { get; set; }

        public Appointment ShallowCopy()
        {
            return (Appointment)this.MemberwiseClone();
        }

        //public Appointment DeepCopy()
        //{
        //    Appointment other = (Appointment)this.MemberwiseClone();
        //    other.Start = new DateTime(this.Start.Ticks);
        //    other.End = new DateTime(this.End.Ticks);
        //    return other;
        //}
    }
}
