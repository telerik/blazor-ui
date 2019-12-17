using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using custom_edit_form.Models;

namespace custom_edit_form.Data
{
    public class AppointmentService
    {
        public List<Appointment> GetAppointments()
        {
            return AppointmentsList;
        }

        public void UpdateAppointment(Appointment appt)
        {
            var matchingItem = AppointmentsList.Find(a => a.Id == appt.Id);
            if(matchingItem != null)
            {
                InternalUpdateAppointment(appt);
            }
            else
            {
                appt.Id = AppointmentsList.Count + 1;
                AppointmentsList.Add(appt);
            }
        }

        public void DeleteAppointment(Appointment appt)
        {
            var matchingItem = AppointmentsList.Find(a => a.Id == appt.Id);
            if (matchingItem != null)
            {
                AppointmentsList.Remove(matchingItem);
            }
        }

        private void InternalUpdateAppointment(Appointment appt)
        {
            var matchingItem = AppointmentsList.FirstOrDefault(a => a.Id == appt.Id);
            if (matchingItem != null)
            {
                matchingItem.Title = appt.Title;
                matchingItem.Description = appt.Description;
                matchingItem.Start = appt.Start;
                matchingItem.End = appt.End;
                matchingItem.IsAllDay = appt.IsAllDay;
                matchingItem.Notes = appt.Notes;
            }
        }

        private List<Appointment> AppointmentsList { get; set; } = new List<Appointment>()
        {
            new Appointment
            {
                Id = 1,
                Title = "Board meeting",
                Description = "Q4 is coming to a close, review the details.",
                Start = new DateTime(2019, 12, 5, 10, 00, 0),
                End = new DateTime(2019, 12, 5, 11, 30, 0)
            },

            new Appointment
            {
                Id = 2,
                Title = "Vet visit",
                Description = "The cat needs vaccinations and her teeth checked.",
                Start = new DateTime(2019, 12, 2, 11, 30, 0),
                End = new DateTime(2019, 12, 2, 12, 0, 0)
            },

            new Appointment
            {
                Id = 3,
                Title = "Planning meeting",
                Description = "Kick off the new project.",
                Start = new DateTime(2019, 12, 6, 9, 30, 0),
                End = new DateTime(2019, 12, 6, 12, 45, 0)
            },

            new Appointment
            {
                Id = 4,
                Title = "Trip to Hawaii",
                Description = "An unforgettable holiday!",
                IsAllDay = true,
                Start = new DateTime(2019, 11, 27),
                End = new DateTime(2019, 12, 05)
            }
        };
    }
}
