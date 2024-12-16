using System.Collections.Generic;
using TelerikBlazorWASMAdmin.Shared.Models.Employee;
using TelerikBlazorWASMAdmin.Shared.Models.Sales;

namespace TelerikBlazorWASMAdmin.Server.Data
{
    public interface IDataService
    {
        List<Employee> GetEmployees();
        IEnumerable<Sale> GetSales();
        List<Team> GetTeams();
    }
}
