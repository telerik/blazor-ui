using System;
using ICS_Data_Convertion.Extensions;
using ICS_Data_Convertion.Services;

namespace ICS_Data_Convertion.Models
{
    public class CalendarAppointment
    {
        private string _dtStart { get; set; }
        private string _dtEnd { get; set; }
        public string DTStart 
        {
            get
            {
                return _dtStart;
            }
            set
            {
                _dtStart = value;
                //The ParseDateFromICalString extension method can be observed under the Extensions folder.
                Start = value.ParseDateFromICalString();
            }
        }
        public string DTEnd
        {
            get
            {
                return _dtEnd;
            }
            set
            {
                _dtEnd = value;
                //The ParseDateFromICalString extension method can be observed under the Extensions folder.
                End = value.ParseDateFromICalString();
            }
        }

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
