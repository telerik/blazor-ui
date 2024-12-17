using System.Collections.Generic;
using TelerikBlazorServerAdmin.Models.Employee;
using TelerikBlazorServerAdmin.Models.Sales;

namespace TelerikBlazorServerAdmin.Data
{
    public interface IDataService
    {
        List<Employee> GetEmployees();
        IEnumerable<Sale> GetSales();
        List<Team> GetTeams();
    }
}
