using System.Threading.Tasks;
using Telerik.DataSource;
using TelerikBlazorGrid_Dapper.DataAccess.Models;

namespace TelerikBlazorGrid_Dapper.DataAccess.Services
{
    public interface IProductDataService
    {
        Task<DataSourceResponse<Product>> GetProducts(DataSourceRequest request);
        Task<DataSourceResponse<Product>> GetRelatedProducts(DataSourceRequest request, int productId);
    }
}