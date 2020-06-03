using System;
using ICS_Data_Convertion.Extensions;
using ICS_Data_Convertion.Services;

namespace ICS_Data_Convertion.Models
{
    public class CalendarAppointment
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string RecurrenceRule { get; set; }
        public Guid? RecurrenceId { get; set; }
        public bool IsAllDay { get; set; }

        public CalendarAppointment()
        {
            Id = new Guid();
        }
    }
}
