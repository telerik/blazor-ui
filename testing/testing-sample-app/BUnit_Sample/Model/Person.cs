using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BUnit_Sample.Model
{
    public class Person
    {
        public Person()
        {
        }

        public int? EmployeeId { get; set; }

        public string Name { get; set; }

        public int? AgeInYears { get; set; }

        public decimal? GraduateGrade { get; set; }

        public DateTime HireDate { get; set; }
    }
}
