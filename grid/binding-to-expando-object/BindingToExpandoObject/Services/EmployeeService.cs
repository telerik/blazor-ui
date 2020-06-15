using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace BindingToExpandoObject.Services
{
    public class EmployeeService
    {
        public static List<ExpandoObject> Data { get; set; } = new List<ExpandoObject>();
        public async Task<List<ExpandoObject>> GetEmployeesAsync()
        {
            if (!Data.Any())
            {
                for (int i = 0; i < 50; i++)
                {
                    ExpandoObject employee = new ExpandoObject();
                    employee.TryAdd("EmployeeId", i);
                    employee.TryAdd("FirstName", $"Employee {i}");
                    employee.TryAdd("LastName", $"Employee {i}");
                    employee.TryAdd("IsActive", i % 2 == 0);
                    employee.TryAdd("HireDate", DateTime.Now.AddMonths(-i));
                    Data.Add(employee);
                }
            }
            return await Task.FromResult(Data);
        }
    }
}
