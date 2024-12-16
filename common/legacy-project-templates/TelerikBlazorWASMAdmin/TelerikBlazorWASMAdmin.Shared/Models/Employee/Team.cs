using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TelerikBlazorWASMAdmin.Shared.Models.Employee
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public string TeamName { get; set; } = string.Empty;
        public string TeamColor { get; set; } = string.Empty;

        [JsonIgnore]
        // ^^^^^^^
        // System.Text.Json does not identify circular references.
        // We need to ignore the employees reference otherwise it will loop.
        public List<Employee>? Employees { get; set; }
    }
}
