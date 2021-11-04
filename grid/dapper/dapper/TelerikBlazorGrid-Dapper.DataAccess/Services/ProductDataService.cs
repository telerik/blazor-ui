using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.DataSource;
using TelerikBlazorGrid_Dapper.DataAccess.Extensions;
using TelerikBlazorGrid_Dapper.DataAccess.Models;

namespace TelerikBlazorGrid_Dapper.DataAccess.Services
{
    public class ProductDataService : IProductDataService
    {
        private readonly IDataAccess _dataAccess;

        public ProductDataService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<DataSourceResponse<Product>> GetProducts(DataSourceRequest request)
        {
            var templates = request.GenerateTemplates("dbo.Products");

            try
            {
                var products = await _dataAccess.LoadDataQuery<Product, dynamic>(templates.SelectTemplate.RawSql, templates.SelectTemplate.Parameters);
                var count = await _dataAccess.LoadFirstQuery<int, dynamic>(templates.CountTemplate.RawSql, templates.CountTemplate.Parameters);

                return new DataSourceResponse<Product>(products, count);
            }
            catch (Exception e)
            {

            }

            return null;
        }
    }
}
