using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace load_appointments_on_demand.Models
{
    public class SchedulerAppointment
    {
        //basic fields
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public bool IsAllDay { get; set; }

        //recurrence

        public string RecurrenceRule { get; set; }

        public List<DateTime> RecurrenceExceptions { get; set; }

        public Guid? RecurrenceId { get; set; }

        //resources
        public string Room { get; set; }

        public string Manager { get; set; }

        public string Department { get; set; }

        //unique id

        public SchedulerAppointment()
        {
            Id = Guid.NewGuid();
        }
    }
}
