using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appointment_tooltips.Models
{
    public class SchedulerAppointment
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public bool IsAllDay { get; set; }

        public string RecurrenceRule { get; set; }

        public List<DateTime> RecurrenceExceptions { get; set; }

        public Guid? RecurrenceId { get; set; }
    }
}
