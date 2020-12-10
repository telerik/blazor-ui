using appointment_context_menu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appointment_context_menu.Services
{
    public class AppointmentService
    {
        static List<SchedulerAppointment> _appointments { get; set; }
        public DateTime GetStartTime()
        {
            DateTime now = DateTime.Now;
            int diff = (7 + (now.DayOfWeek - DayOfWeek.Monday)) % 7;
            DateTime lastMonday = now.AddDays(-1 * diff);
            // return 8 AM on today's date for better visualization of the demo
            return new DateTime(lastMonday.Year, lastMonday.Month, lastMonday.Day, 8, 0, 0);
        }

        public async Task<List<SchedulerAppointment>> GetAppointmentsAsync()
        {
            EnsureAppointments();
            return await Task.FromResult(_appointments);
        }

        public async Task UpdateAsync(SchedulerAppointment apptToUpdate)
        {
            var index = _appointments.FindIndex(i => i.Id == apptToUpdate.Id);
            if (index != -1)
            {
                _appointments[index] = apptToUpdate;
            }
        }

        public async Task InsertAsync(SchedulerAppointment apptToInsert)
        {
            apptToInsert.Id = Guid.NewGuid();
            _appointments.Insert(0, apptToInsert);
        }

        public async Task DeleteAsync(SchedulerAppointment apptToDelete)
        {
            // if you have recurrences and exceptions you may want to clean them up here too
            // see https://docs.telerik.com/blazor-ui/components/scheduler/edit-appointments#example
            _appointments.Remove(apptToDelete);
        }

        private void EnsureAppointments()
        {
            if(_appointments != null)
            {
                return;
            }

            _appointments = new List<SchedulerAppointment>();
            DateTime baselineTime = GetStartTime();

            _appointments.Add(new SchedulerAppointment
            {
                Title = "Vet visit",
                IsImportant = true,
                Description = "The cat needs vaccinations and her teeth checked.",
                Start = baselineTime.AddHours(2),
                End = baselineTime.AddHours(2).AddMinutes(30),
            });

            _appointments.Add(new SchedulerAppointment
            {
                Title = "Trip to Hawaii",
                Description = "An unforgettable holiday!",
                IsAllDay = true,
                Start = baselineTime.AddDays(-10),
                End = baselineTime.AddDays(-2),
            });

            _appointments.Add(new SchedulerAppointment
            {
                Title = "Jane's birthday party",
                Description = "Make sure to get her fresh flowers in addition to the gift.",
                Start = baselineTime.AddDays(5).AddHours(10),
                End = baselineTime.AddDays(5).AddHours(18),
            });

            _appointments.Add(new SchedulerAppointment
            {
                Title = "Brunch with HR",
                Description = "Performance evaluation of the new recruit.",
                Start = baselineTime.AddDays(3).AddHours(3),
                End = baselineTime.AddDays(3).AddHours(3).AddMinutes(45),
            });

            _appointments.Add(new SchedulerAppointment
            {
                Title = "Interview with new recruit",
                Description = "See if John will be a suitable match for our team.",
                Start = baselineTime.AddDays(3).AddHours(1).AddMinutes(30),
                End = baselineTime.AddDays(3).AddHours(2).AddMinutes(30),
            });

            _appointments.Add(new SchedulerAppointment
            {
                Title = "New Project Kickoff",
                Description = "Everyone assemble! We will also have clients on the call from a later time zone.",
                Start = baselineTime.AddDays(3).AddHours(8).AddMinutes(30),
                End = baselineTime.AddDays(3).AddHours(11).AddMinutes(30),
            });

            _appointments.Add(new SchedulerAppointment
            {
                Title = "Get photos",
                Description = "Get the printed photos from last week's holiday. It's on the way from the vet to work.",
                Start = baselineTime.AddHours(2).AddMinutes(15),
                End = baselineTime.AddHours(2).AddMinutes(30),
            });

            _appointments.Add(new SchedulerAppointment
            {
                Title = "Conference",
                IsImmutable = true,
                IsImportant = true,
                Description = "The big important work conference. Don't forget to practice your presentation.",
                Start = baselineTime.AddDays(6),
                End = baselineTime.AddDays(11),
                IsAllDay = true,
            });
        }
    }
}
