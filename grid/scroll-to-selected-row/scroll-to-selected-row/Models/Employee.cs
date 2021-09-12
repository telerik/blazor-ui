using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scroll_to_selected_row.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }

        // needed for the virtualization example only, remove it otherwise
        public override bool Equals(object obj)
        {
            if (obj is Employee)
            {
                return this.EmployeeId == (obj as Employee).EmployeeId;
            }
            return false;
        }
    }
}
