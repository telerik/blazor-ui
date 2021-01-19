using System.ComponentModel.DataAnnotations;

namespace BlazingCoffee.Shared.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Group { get; set; }
        public string Sku { get; set; }
        public double Cost { get; set; }
        public string NutritionFileName { get; set; }
    }
}