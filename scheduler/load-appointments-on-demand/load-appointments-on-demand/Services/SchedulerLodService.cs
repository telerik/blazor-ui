using load_appointments_on_demand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telerik.Blazor;

namespace load_appointments_on_demand.Services
{
    public class SchedulerLodService
    {
        // helper method to get prettier UI for the appointment generation
        // that is also independent of when you run the sample
        public DateTime GetCurrentWeekStartTime()
        {
            return GetCurrentWeekStartTime(DateTime.Now);
        }

        public DateTime GetCurrentWeekStartTime(DateTime currTime)
        {
            DateTime now = currTime;
            int diff = (7 + (now.DayOfWeek - DayOfWeek.Monday)) % 7;
            DateTime lastMonday = now.AddDays(-1 * diff);
            // return 8 AM on today's date for better visualization of the demos
            return new DateTime(lastMonday.Year, lastMonday.Month, lastMonday.Day, 8, 0, 0);
        }

        // translate UI knowledge (scheduler view and start date) into
        // date range for filtering at the actual data source level
        // you can add more arguments, such as current user, permissions, sets of calendars to look at, and so on
        public async Task<List<SchedulerAppointment>> GetAppointmentsAsync(DateTime startDateFromUI, SchedulerView currentView, int multiDayDaysCount)
        {
            // translate UI to date range
            DateTime startDate = startDateFromUI;
            DateTime endDate = startDateFromUI;
            switch (currentView)
            {
                case SchedulerView.Day:
                    break;
                case SchedulerView.MultiDay:
                    endDate = endDate.AddDays(multiDayDaysCount);
                    break;
                case SchedulerView.Week:
                    startDate = GetCurrentWeekStartTime(startDate);
                    endDate = startDate.AddDays(7);
                    break;
                case SchedulerView.Month:
                    // if adjacent months are visible, it is up to +/- 6 days
                    // to optimize futher you'd have to write a lot of calendar logic to find
                    // what day of the week the 1st of the month is, and how many days from the previous
                    // and next month are visible, which can make for convoluted and complex code
                    startDate = new DateTime(startDate.Year, startDate.Month, 1).AddDays(-6);
                    // make it even simpler - no months are shorter than 28 days, none is longer than 31
                    // so adding 9 adds at least 6 to the longest possible for the case where most days are seen
                    endDate = new DateTime(startDate.Year, startDate.Month, 28).AddDays(9);
                    break;
                default:
                    throw new ArgumentException("the service does not know how to handle this scheduler view yet");
            }

            // get appointments from the database
            return await GetFilteredAppointmentsPerRangeFromDataBaseAsync(startDate, endDate);
        }

        private async Task<List<SchedulerAppointment>> GetFilteredAppointmentsPerRangeFromDataBaseAsync(DateTime startDate, DateTime endDate)
        {
            // filter appointments by the time required range 
            // optimize this query as required by your data source
            // for example, pass arguments to the method, use stored procedures and so on
            // this here showcases the basic concept of filtering the data on the server, not in the UI
            // you need to implement it according to your actual optimization techniques and project
            // in the real app you should filter and optimize here, this is not implemented in this sample
            List<SchedulerAppointment> appointments = await GetDummyAppointments();
            // here we just filter in memory for demonstration purposes because it is easy to follow in the example
            // do NOT do this in the real app - this is the equivalend of selecting all rows, getting them to the app and filtering here
            appointments = appointments.Where(a =>
                (a.Start.Date < endData.Date && a.End.Date > startDate.Date)     //OR ends in the current range
            ).ToList();

            // always add all recurring ones if you don't want to expand and
            // test them against the date range in your own code - you can let the scheduler expand them
            // you can optimize this as needed as well, but usually there shouldn't be too many recurring appointments
            List<SchedulerAppointment> recurringOnes = await GetRecurringAppointments();

            // make the final list of appointments for the current view and range
            appointments.AddRange(recurringOnes);
            return await Task.FromResult(appointments);
        }

        // mimics some sort of database that fetches appointments. Here we just hardcode some
        private async Task<List<SchedulerAppointment>> GetDummyAppointments()
        {
            List<SchedulerAppointment> data = new List<SchedulerAppointment>();
            DateTime baselineTime = GetCurrentWeekStartTime();

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
            DateTime baselineTime = GetCurrentWeekStartTime();

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
    }
}
