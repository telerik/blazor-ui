using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TelerikBlazorWASMAdmin.Client.Pages
{
    public partial class Settings
    {
        int selectedValue { get; set; }
        bool switchValue { get; set; } = true;

        private DateTime min = new DateTime(2015, 1, 1);
        private DateTime max = new DateTime(2025, 12, 31);
        private DateTime theDate { get; set; } = DateTime.Now;
        private string selectedDate { get; set; } = string.Empty;
        public bool WindowVisible { get; set; }

        private void MyValueChangeHandler(DateTime newValue)
        {
            selectedDate = newValue.ToString("dd MMM yyyy");
        }
        public void WindowButtonClicked()
        {
            navManager.NavigateTo("/", true);
        }

        SettingsModel settingsModel { get; set; } = new SettingsModel()
        {
            Username = "JaxonWhite",
            Nickname = "Jax",
            Email = "jaxon.white@gmail.com",
            Phone = "(+1) 8373-837-93-02",
            Website = "jxnss.com",
            Country = new List<MyDdlModel>
            {
            new MyDdlModel() { MyValueField = 1, MyTextField = "USA"},
            new MyDdlModel() { MyValueField = 2, MyTextField = "Bulgaria"},
            new MyDdlModel() { MyValueField = 3, MyTextField = "Argentina"}
        },

        };

        public class MyDdlModel
        {
            public int MyValueField { get; set; }
            public string MyTextField { get; set; } = string.Empty;
        }

        public EditContext? EditContext { get; set; }

        protected override void OnInitialized()
        {
            EditContext = new EditContext(settingsModel);
            selectedValue = 3;
            base.OnInitialized();
        }

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

            public List<MyDdlModel>? Country { get; set; }

            public string Website { get; set; } = string.Empty;
        }
    }
}
