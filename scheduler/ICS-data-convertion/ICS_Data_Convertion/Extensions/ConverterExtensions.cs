using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ICS_Data_Convertion.Extensions
{
    public static class ConverterExtensions
    {
        public static DateTime? ParseDateFromICalString(this string value)
        {
            var success = DateTime.TryParseExact(value, "yyyyMMddTHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out DateTime date);
            
            return success ? (DateTime?)date : null;
        }
    }
}
