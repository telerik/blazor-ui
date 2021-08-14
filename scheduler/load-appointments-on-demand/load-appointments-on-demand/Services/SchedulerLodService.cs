using load_appointments_on_demand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace load_appointments_on_demand.Services
{
    public class SchedulerLodService
    {
        public async Task<List<SchedulerAppointment>> GetAppointmentsAsync()
        {

            // filter appointments by the time required range
            // optimize this query as required by your data source
            // for example, pass arguments to the method, use stored procedures and so on
            // this here showcases the basic concept of filtering the data on the server, not in the UI
            // you need to implement it according to your actual optimization techniques and project
            List<SchedulerAppointment> appointments = await GetDummyAppointments();
            //appointments = appointments.Where();

            // always add all recurring ones if you don't want to expand and
            // test them against the date range - let the scheduler expand them
            // you can optimize this as needed as well
            List<SchedulerAppointment> recurringOnes = await GetRecurringAppointments();

            // make the final list of appointments for the current view and range
            appointments.AddRange(recurringOnes);
            return appointments;
        }

        private async Task<List<SchedulerAppointment>> GetDummyAppointments()
        {
            List<SchedulerAppointment> data = new List<SchedulerAppointment>();
            DateTime baselineTime = GetStartTime();

            data.Add(new SchedulerAppointment
            {
                Title = "Vet visit",
                Description = "The cat needs vaccinations and her teeth checked.",
                Start = baselineTime.AddHours(2),
                End = baselineTime.AddHours(2).AddMinutes(30),
                Room = "1",
                Manager = "2"
            });

            data.Add(new SchedulerAppointment
            {
                Title = "Trip to Hawaii",
                Description = "An unforgettable holiday!",
                IsAllDay = true,
                Start = baselineTime.AddDays(-30),
                End = baselineTime.AddDays(-20),
                Room = "2",
                Manager = "1"
            });

            data.Add(new SchedulerAppointment
            {
                Title = "Jane's birthday party",
                Description = "Make sure to get her fresh flowers in addition to the gift.",
                Start = baselineTime.AddDays(5).AddHours(10),
                End = baselineTime.AddDays(5).AddHours(18),
                Room = "1",
                Manager = "2"
            });

            data.Add(new SchedulerAppointment
            {
                Title = "Brunch with HR",
                Description = "Performance evaluation of the new recruit.",
                Start = baselineTime.AddDays(30).AddHours(3),
                End = baselineTime.AddDays(30).AddHours(3).AddMinutes(45),
                Room = "1",
                Manager = "3"
            });

            data.Add(new SchedulerAppointment
            {
                Title = "Interview with new recruit",
                Description = "See if John will be a suitable match for our team.",
                Start = baselineTime.AddDays(3).AddHours(1).AddMinutes(30),
                End = baselineTime.AddDays(3).AddHours(2).AddMinutes(30),
                Room = "2",
                Manager = "1"
            });

            data.Add(new SchedulerAppointment
            {
                Title = "Conference",
                Description = "The big important work conference. Don't forget to practice your presentation.",
                Start = baselineTime.AddDays(6),
                End = baselineTime.AddDays(11),
                IsAllDay = true,
                Room = "1",
                Manager = "1"
            });

            data.Add(new SchedulerAppointment
            {
                Title = "New Project Kickoff",
                Description = "Everyone assemble! We will also have clients on the call from a later time zone.",
                Start = baselineTime.AddDays(4).AddHours(8).AddMinutes(30),
                End = baselineTime.AddDays(4).AddHours(11).AddMinutes(30),
                Room = "2",
                Manager = "2"
            });

            data.Add(new SchedulerAppointment
            {
                Title = "Get photos",
                Description = "Get the printed photos from last week's holiday. It's on the way from the vet to work.",
                Start = baselineTime.AddDays(-30).AddHours(2).AddMinutes(15),
                End = baselineTime.AddDays(-30).AddHours(2).AddMinutes(30),
                Room = "2",
                Manager = "3"
            });

            return await Task.FromResult(data);
        }

        private async Task<List<SchedulerAppointment>> GetRecurringAppointments()
        {
            List<SchedulerAppointment> data = new List<SchedulerAppointment>();
            DateTime baselineTime = GetStartTime();

            data.Add(new SchedulerAppointment
            {
                Title = "One-on-one with the manager",
                Start = baselineTime.AddHours(3).AddMinutes(30),
                End = baselineTime.AddHours(3).AddMinutes(45),
                Room = "1",
                Manager = "3",
                RecurrenceRule = "FREQ=MONTHLY;BYDAY=MO;BYSETPOS=2"
            });

            data.Add(new SchedulerAppointment
            {
                Title = "Team breakfast",
                Description = "Have breakfast with teammates every couple of days",
                Start = baselineTime.AddDays(-7).AddHours(1),
                End = baselineTime.AddDays(-7).AddHours(1).AddMinutes(30),
                RecurrenceRule = "FREQ=WEEKLY;BYDAY=TU,TH"
            });

            data.Add(new SchedulerAppointment
            {
                Title = "Monthly doctor checkup",
                Description = "Visit the doctor and make sure all vitals are good",
                Start = baselineTime.AddHours(4),
                End = baselineTime.AddHours(5),
                RecurrenceRule = $"FREQ=MONTHLY;BYMONTHDAY={baselineTime.Day}"
            });

            data.Add(new SchedulerAppointment
            {
                Title = "Tim's birthday",
                Description = "Don't forget brother's b-day",
                Start = baselineTime.AddDays(2).AddHours(8),
                End = baselineTime.AddDays(2).AddHours(9),
                RecurrenceRule = $"FREQ=YEARLY;BYMONTH={baselineTime.AddDays(2).Month};BYMONTHDAY={baselineTime.AddDays(2).Day}"
            });

            return await Task.FromResult(data);
        }

        public DateTime GetStartTime()
        {
            DateTime now = DateTime.Now;
            int diff = (7 + (now.DayOfWeek - DayOfWeek.Monday)) % 7;
            DateTime lastMonday = now.AddDays(-1 * diff);
            // return 8 AM on today's date for better visualization of the demos
            return new DateTime(lastMonday.Year, lastMonday.Month, lastMonday.Day, 8, 0, 0);
        }
    }
}
