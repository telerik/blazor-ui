using scroll_to_selected_row.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scroll_to_selected_row.Services
{
    public class GridDataService
    {
        public async Task<List<Employee>> GenerateData()
        {
            List<Employee> data = new List<Employee>();
            for (int i = 1; i <= 100; i++)
            {
                data.Add(new Employee()
                {
                    EmployeeId = i,
                    Name = "Employee " + i.ToString(),
                    Team = "Team " + i % 3
                });
            }
            return await Task.FromResult(data);
        }
    }
}
