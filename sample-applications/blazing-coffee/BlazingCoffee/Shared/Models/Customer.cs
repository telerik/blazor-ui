using System.ComponentModel.DataAnnotations;

namespace BlazingCoffee.Shared.Models
{
    public class Customer
    {
        [Key]
        public string CustomerID { get; set; }
        public string EmployeeID { get; set; }
        public int OrderID { get; set; }
        public int TeamID { get; set; }
        public string CustomerCompanyName { get; set; }
        public string CustomerContactName { get; set; }
        public float OrderTotal { get; set; }
        public long OrderDate { get; set; }
        public long RequiredDate { get; set; }
        public long ShippedDate { get; set; }
        public long RequiredDateStart { get; set; }
        public long RequiredDateEnd { get; set; }
        public int ShipVia { get; set; }
        public float Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
    }


}

