using System.ComponentModel.DataAnnotations;

namespace BlazingCoffee.Shared.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public string FullName { get; set; }
        public string JobTitle { get; set; }
        public string Country { get; set; }
        public bool IsOnline { get; set; }
        public int Rating { get; set; }
        public int Target { get; set; }
        public int Budget { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int ImgId { get; set; }
        public string Gender { get; set; }
    }

}

