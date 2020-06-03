using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using ICS_Data_Convertion.Models;
using ICS_Data_Convertion.Extensions;
using System.Text.RegularExpressions;
using System.Globalization;

namespace ICS_Data_Convertion.Services
{
    public class SchedulerAppointmentsService
    {
        public string line;

        //Replace this path with your actual path.
        //When published this path should be taken from the hostingenvironment
        //https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.hosting.ihostingenvironment.contentrootpath?view=aspnetcore-3.1
        public static string path = Path.Combine(Directory.GetCurrentDirectory(), "Calendar\\myevents.ics");

        public List<CalendarAppointment> GetAppointments()
        {
            return ReadICalAppointments();
        }

        public List<CalendarAppointment> ReadICalAppointments()
        {
            List<CalendarAppointment> calendarAppointments = new List<CalendarAppointment>();

            StreamReader file = new StreamReader(path);

            var data = file.ReadToEnd();
            var appointments = Regex.Matches(data, @"BEGIN:VEVENT([\S\s]*?)END:VEVENT", RegexOptions.Multiline).Select(match => match.Value);
                    
            foreach (var appointment in appointments)
            {
                calendarAppointments.Add(ReadICalAppointment(appointment));
            }

            return calendarAppointments;
        }

        public CalendarAppointment ReadICalAppointment(string appointment)
        {
            CalendarAppointment calendarAppointment = new CalendarAppointment();

            calendarAppointment.Start = (Regex.Match(appointment, @"(?<=DTSTART([\S]*?):).\S*").Value).ParseDateFromICalString();
            calendarAppointment.End = (Regex.Match(appointment, @"(?<=DTEND([\S]*?):).\S*").Value).ParseDateFromICalString();
            calendarAppointment.Title = Regex.Match(appointment, @"(?<=SUMMARY:).*").Value;
            calendarAppointment.Description = Regex.Match(appointment, @"(?<=DESCRIPTION:).*").Value;
            calendarAppointment.RecurrenceRule = Regex.Match(appointment, @"(?<=RRULE:).*").Value;

            return calendarAppointment;
        }
    }
}
