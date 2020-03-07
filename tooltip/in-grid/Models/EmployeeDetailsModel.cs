using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TooltipForGridElements.Models
{
    public class EmployeeDetailsModel : BasicEmployee
    {
        public DateTime HireDate { get; set; }
        public int ActiveProjects { get; set; }
        public decimal Salary { get; set; }

        public EmployeeDetailsModel(BasicEmployee basicEmployee)
        {
            this.Id = basicEmployee.Id;
            this.Name = basicEmployee.Name;
            this.Team = basicEmployee.Team;
        }
    }
}
