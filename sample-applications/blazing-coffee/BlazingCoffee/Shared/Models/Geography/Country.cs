using System.ComponentModel.DataAnnotations;

namespace BlazingCoffee.Shared.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Region { get; set; }
        public string Continent { get; set; }
    }

}

