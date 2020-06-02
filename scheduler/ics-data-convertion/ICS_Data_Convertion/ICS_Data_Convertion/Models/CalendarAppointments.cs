using System;
using ICS_Data_Convertion.Services;

namespace ICS_Data_Convertion.Models
{
    public class CalendarAppointments
    {
        ConvertStringToDateTime Converter = new ConvertStringToDateTime();
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
                Start = Converter.ConvertStringToDate(value);
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
                End = Converter.ConvertStringToDate(value);
            }
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
    }
}
