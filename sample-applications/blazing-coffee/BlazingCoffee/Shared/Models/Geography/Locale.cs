using System.ComponentModel.DataAnnotations;

namespace BlazingCoffee.Shared.Models
{
    public class Locale
    {
        [Key]
        public int Id { get; set; }
        public string LocaleId { get; set; }
        public string Name { get; set; }
    }


}

