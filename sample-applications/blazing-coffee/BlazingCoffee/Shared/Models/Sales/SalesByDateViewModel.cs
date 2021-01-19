using System;
using System.Collections.Generic;
using System.Text;

namespace BlazingCoffee.Shared.Models
{
    public class SalesByDateViewModel
    {
        public string Region { get; set; }
        public DateTime Date { get; set; }
        public double Sum { get; set; }
    }
}
