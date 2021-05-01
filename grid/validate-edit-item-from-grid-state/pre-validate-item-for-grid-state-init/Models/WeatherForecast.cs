using System;
using System.ComponentModel.DataAnnotations;

namespace pre_validate_item_for_grid_state_init.Models
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

        [Required(ErrorMessage = "Your forecast requires a summary")]
        [StringLength(255, ErrorMessage = "Summaries can be no more than 255 characters")]
        public string Summary { get; set; }

        public WeatherForecast()
        {
            Date = DateTime.Now.Date;
        }
    }
}
