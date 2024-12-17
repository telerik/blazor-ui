using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TelerikBlazorServerAdmin.Models
{
    public class SettingsModel
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Nickname { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Phone { get; set; } = string.Empty;
        [Required]
        public DateTime BirthDate { get; set; }

        public List<MyDropDownListModel>? Country { get; set; }

        public string Website { get; set; } = string.Empty;
    }
}
