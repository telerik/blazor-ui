using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ICS_Data_Convertion.Services
{
    public class ConvertStringToDateTime
    {
        public DateTime? ConvertStringToDate(string dateTime)
        {
            if (!String.IsNullOrEmpty(dateTime))
            {
                var date = new DateTime();

                //This is a simple datetime parser. According to the iCal standard, a DateTime string ending in 'Z' indicates that the datetime is in UTC rather than local time. This code assumes the date is in UTC.
                if (DateTime.TryParseExact(dateTime.ToLower().Replace("t", " ").Replace("z", ""), "yyyyMMdd HHmmss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out date))
                {
                    return date;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
