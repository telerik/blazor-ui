using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AdjustHeightWithBrowser.Data
{
    /// <summary>
    /// See https://simplemaps.com/data/world-cities for field descriptions
    /// </summary>
    public class City
    {
        public override string ToString()
        {
            return $"{city} - {country}, {population}";
        }

        public string city { get; set; }
        public string city_ascii { get; set; }
        public decimal lat { get; set; }
        public decimal lng { get; set; }
        public string country { get; set; }
        public string iso2 { get; set; }
        public string iso3 { get; set; }
        public string admin_name { get; set; }
        public string capital { get; set; }
        public int population { get; set; }
        public int id { get; set; }

        public static City FromCSV(string[] values)
        {
            try
            {
                // Create City 
                var city = new City();
                city.city = values[0];
                city.city_ascii = values[1];
                city.lat = ConvertToDecimal(values[2]);
                city.lng = ConvertToDecimal(values[3]);
                city.country = values[4];
                city.iso2 = values[5];
                city.iso3 = values[6];
                city.admin_name = values[7];
                city.capital = values[8];
                city.population = ConvertToInt(values[9]);
                city.id = ConvertToInt(values[10]);

                return city;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private static int ConvertToInt(string value)
        {
            // Check value for decimal
            var decimalPos = value.IndexOf('.');
            if(decimalPos != -1)
            {
                value = value.Substring(0, decimalPos - 1);
            }

            int number;
            if (Int32.TryParse(value, out number))
                return number;
            else
                return 0;
        }

        private static decimal ConvertToDecimal(string value)
        {
            decimal number;
            if (Decimal.TryParse(value, out number))
                return number;
            else
                return 0;
        }

    }
}
