using gRPCsample.Server.Data;
using gRPCsample.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telerik.DataSource;
using Telerik.DataSource.Extensions;

namespace gRPCsample.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestGridJSONController : ControllerBase
    {
        public TestGridJSONController(ITestEntities dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]

        public async Task<DataEnvelope<TestGridJSONModel>> Post([FromBody] DataSourceRequest gridRequest)
        {
            // Get the generated data
            // Note: There is currently an issue with grouping and EF Core 5.0. Adding ToList() fixes it but impacts performance on large datasets
            var data = from t in _dataContext.TestData
                       select new TestGridJSONModel()
                       {
                           Id = t.Id,
                           ColumInt32 = t.ColumnInt32,
                           ColumnDouble = t.ColumnDouble,
                           ColumnFloat = (float)t.ColumnFloat,
                           ColumnBool = t.ColumnBool,
                           ColumnString = t.ColumnString,
                           ColumnBytes = t.ColumnBytes,
                           ColumnTestObject = new TestObjectJSONModel() { Id = t.ObjectId, Description = t.ObjectDescription },
                           Created = t.Created,
                           Modified = t.Modified
                       };

            // use the Telerik DataSource Extensions to perform the query on the data
            // the Telerik extension methods can also work on "regular" collections like List<T> and IQueriable<T>
            DataSourceResult processedData = await data.ToDataSourceResultAsync(gridRequest);

            DataEnvelope<TestGridJSONModel> dataToReturn;
            if (gridRequest.Groups.Count > 0)
            {
                // If there is grouping, use the field for grouped data
                // The app must be able to serialize and deserialize it
                // Example helper methods for this are available in this project
                // See the GroupDataHelper.DeserializeGroups and JsonExtensions.Deserialize methods
                dataToReturn = new DataEnvelope<TestGridJSONModel>
                {
                    GroupedData = processedData.Data.Cast<AggregateFunctionsGroup>().ToList(),
                    TotalItemCount = processedData.Total
                };
            }
            else
            {
                // When there is no grouping, the simplistic approach of 
                // just serializing and deserializing the flat data is enough
                dataToReturn = new DataEnvelope<TestGridJSONModel>
                {
                    CurrentPageData = processedData.Data.Cast<TestGridJSONModel>().ToList(),
                    TotalItemCount = processedData.Total
                };
            }

            return dataToReturn;
        }

        private ITestEntities _dataContext;
    }
}
