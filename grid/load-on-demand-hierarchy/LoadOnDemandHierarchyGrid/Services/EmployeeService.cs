using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoadOnDemandHierarchyGrid.Models;

namespace LoadOnDemandHierarchyGrid.Services
{
    public class EmployeeService
    {
        public static List<Employee> Data { get; set; } = new List<Employee>();
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            if (!Data.Any())
            {
                for (int i = 0; i < 50; i++)
                {
                    Employee employee = new Employee { EmployeeId = i, FirstName = $"Employee {i}", LastName = $"LastName {i}" };
                    Data.Add(employee);
                }
            }
            return await Task.FromResult(Data);
        }
    }
}
