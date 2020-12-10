using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appointment_context_menu.Models
{
    public class SchedulerAppointment
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public bool IsAllDay { get; set; }

        public bool IsImportant { get; set; }

        public bool IsImmutable { get; set; }

        public SchedulerAppointment()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
