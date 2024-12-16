using System.ComponentModel.DataAnnotations;

namespace TelerikBlazorWASMAdmin.Shared.Models.Employee
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public int TeamId { get; set; }
        public Team? Team { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public bool IsOnline { get; set; }
        public int Rating { get; set; }
        public int Target { get; set; }
        public int Budget { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int ImgId { get; set; }
        public string Gender { get; set; } = string.Empty;
    }
}
