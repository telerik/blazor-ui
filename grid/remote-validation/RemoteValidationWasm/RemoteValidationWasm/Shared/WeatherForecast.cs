using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteValidationWasm.Shared
{
    public class WeatherForecast
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        private double _tempC { get; set; }
        public double TemperatureC
        {
            get
            {
                return _tempC;
            }
            set
            {
                _tempC = value;
            }
        }

        public double TemperatureF
        {
            get
            {
                return 32 + (_tempC / 0.5556);
            }
            set
            {
                _tempC = (value - 32) * 0.5556;
            }
        }

        public string Summary { get; set; }

        public WeatherForecast()
        {
            Date = DateTime.Now.Date;
        }
    }
}
