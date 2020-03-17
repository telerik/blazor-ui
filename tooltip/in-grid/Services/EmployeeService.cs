using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TooltipForGridElements.Models;

namespace TooltipForGridElements.Services
{
    public class EmployeeService
    {
        private static Random rnd { get; set; } = new Random();

        private static List<BasicEmployee> data {get;set;}

        public async Task<List<BasicEmployee>> GetEmployees()
        {
            if (data == null)
            {
                // in this sample, we have 90 images
                data = Enumerable.Range(1, 90).Select(x => new BasicEmployee
                {
                    Id = x,
                    Name = "name " + x,
                    Team = "team " + x % 5,
                }).ToList();
            }

            return await Task.FromResult(data);
        }

        public async Task<EmployeeDetailsModel> GetEmplyeeDetails(int employeeId)
        {
            // you can implement a dictionary here with the requests that have come in and their data
            // and perhaps a time stamp. So, when a request comes along, you can check if it was alrady
            // cached and if it was recently enough - skip calling the database and return from memory
            // the data caching and retrieval is entirely up to the application and its practices/needs
            BasicEmployee employee = data.Where(empl => empl.Id == employeeId).FirstOrDefault();
            EmployeeDetailsModel details = new EmployeeDetailsModel(employee);
            details.Salary = rnd.Next(1000, 5000);
            details.ActiveProjects = rnd.Next(2, 10);
            details.HireDate = DateTime.Now.AddYears(-rnd.Next(1, 10)).AddMonths(-rnd.Next(0, 10)).AddDays(-rnd.Next(0, 10));

            await Task.Delay(800); // simulate real life delay. Remove this in a real app

            return details;
        }
    }
}
