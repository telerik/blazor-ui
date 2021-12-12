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
    public class SalesDataService : ISalesDataService
    {
        private readonly IDataAccess _dataAccess;

        public SalesDataService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<DataSourceResponse<Sale>> GetSales(DataSourceRequest request)
        {
            var templates = request.GenerateTemplates("dbo.Sales");

            try
            {
                var sales = await _dataAccess.LoadDataQuery<Sale, dynamic>(templates.SelectTemplate.RawSql, templates.SelectTemplate.Parameters);
                var count = await _dataAccess.LoadFirstQuery<int, dynamic>(templates.CountTemplate.RawSql, templates.CountTemplate.Parameters);

                return new DataSourceResponse<Sale>(sales, count);
            }
            catch (Exception e)
            {

            }

            return null;
        }

        public async Task<DataSourceResponse<Sale>> GetSalesForProduct(DataSourceRequest request, int productId)
        {
            var templates = request.GenerateTemplates("dbo.Sales",
                wheres: new List<SqlBuilderAppendage>
                {
                    new SqlBuilderAppendage("a.[ProductId] = @ProductId", new { ProductId = productId })
                });

            if (templates.SelectTemplate is null || templates.CountTemplate is null)
            {
                throw new Exception("At least one SQL template was null and unable to be created.");
            }

            var sales = await _dataAccess.LoadDataQuery<Sale, dynamic>(templates.SelectTemplate.RawSql, templates.CountTemplate.Parameters);
            var count = await _dataAccess.LoadFirstQuery<int, dynamic>(templates.CountTemplate.RawSql, templates.CountTemplate.Parameters);

            return new DataSourceResponse<Sale>(sales, count);
        }
    }
}
