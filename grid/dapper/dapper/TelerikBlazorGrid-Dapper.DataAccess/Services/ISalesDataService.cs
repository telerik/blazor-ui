using System.Threading.Tasks;
using Telerik.DataSource;
using TelerikBlazorGrid_Dapper.DataAccess.Models;

namespace TelerikBlazorGrid_Dapper.DataAccess.Services
{
    public interface ISalesDataService
    {
        Task<DataSourceResponse<Sale>> GetSales(DataSourceRequest request);
        Task<DataSourceResponse<Sale>> GetSalesForProduct(DataSourceRequest request, int productId);
    }
}