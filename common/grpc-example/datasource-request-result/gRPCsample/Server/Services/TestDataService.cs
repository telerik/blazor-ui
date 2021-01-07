using gRPCsample.Shared;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telerik.DataSource;
using Telerik.DataSource.Extensions;
using gRPCsample.Server.Helpers;
using gRPCsample.Server.Data;
using gRPCsample.Shared.Helpers;
using static gRPCsample.Shared.UpdateTypeModel.Types;

namespace gRPCsample.Server.Services
{
    public class TestDataService : gRPCsample.Shared.TestDataService.TestDataServiceBase
    {
        #region Constructor

        public TestDataService(ITestEntities dataContext)
        {
            _dataContext = dataContext;
        }

        #endregion

        #region Get the List for the Grid

        public override async Task<DataListResponse> GetTestData(DataSourceProtoRequest dataSourceProtoRequest, ServerCallContext context)
        {
            // Deserialise the Telerik DataSourceRequest object
            DataSourceRequest dataSourceRequest = dataSourceProtoRequest.FromProto();

            // Create the Protobuf object that is sent back to the client
            var response = new DataListResponse() { Result = new ResultModel() };

            try
            {
                // Get the generated data
                // Note: There is currently an issue with grouping and EF Core 5.0. Adding ToList() fixes it but impacts performance on large datasets
                var data = from t in _dataContext.TestData
                           select new TestDataModel()
                           {
                               Id = t.Id,
                               ColumnInt32 = t.ColumnInt32,
                               ColumnDouble = t.ColumnDouble,
                               ColumnFloat = (float)t.ColumnFloat,
                               ColumnBool = t.ColumnBool,
                               ColumnString = t.ColumnString,
                               ColumnBytes = ByteString.CopyFrom(t.ColumnBytes),
                               ColumnTestObject = new TestObjectModel() { Id = t.ObjectId, Description = t.ObjectDescription },
                               Created = t.Created,
                               Modified = t.Modified
                           };

                // Add filtering, paging and grouping
                DataSourceResult dataSourceResult = await data.ToList().ToDataSourceResultAsync(dataSourceRequest);

                // Convert the result. The grouped object structure needs some processing and utilises the callback function below 
                ControllerHelper.ConvertDataSourceResult(response, dataSourceResult, new DataGroupModelCallBack(CreateDataGroupModel));
            }
            catch (Exception ex)
            {
                response.Result.ErrorMessage = $"Error in GetTestData: {ex.Message}";
            }

            return response;
        }

        /// <summary>
        /// This is the call back function to process the grouped data structure
        /// </summary>
        /// <param name="records"></param>
        /// <param name="dataGroupModel"></param>
        private void CreateDataGroupModel(object records, DataGroupModel dataGroupModel)
        {
            TestDataListModel list = new TestDataListModel();
            list.Records.AddRange(records as IEnumerable<TestDataModel>);
            dataGroupModel.GridRows = Google.Protobuf.WellKnownTypes.Any.Pack(list);
        }

        #endregion

        #region Update the Database

        public override Task<ResultResponse> UpdateDataRecord(UpdateDataRequest request, ServerCallContext context)
        {
            ResultResponse response = new ResultResponse() { Result = new ResultModel() };

            switch (request.UpdateType.Type)
            {
                case UpdateTypeEnum.Add:
                    response.Result.ErrorMessage = AddNewRecord(request.Project);
                    break;

                case UpdateTypeEnum.Edit:
                    response.Result.ErrorMessage = EditRecord(request.Project);
                    break;

                case UpdateTypeEnum.Delete:
                    response.Result.ErrorMessage = DeleteRecord(request.Project);
                    break;
            }

            return Task.FromResult<ResultResponse>(response);
        }


        #endregion

        #region Private 

        #region Add Record

        private string AddNewRecord(TestDataModel addRecord)
        {
            string errorMessage = null;
            try
            {
                var newRecord = new DataModel()
                {
                    Id = _dataContext.TestData.Count + 1,
                    ColumnInt32 = addRecord.ColumnInt32,
                    ColumnDouble = addRecord.ColumnDouble,
                    ColumnFloat = (float)addRecord.ColumnFloat,
                    ColumnBool = addRecord.ColumnBool,
                    ColumnString = addRecord.ColumnString,
                    ColumnBytes = addRecord.ColumnBytes?.ToArray() ?? new byte[] { 0x20, 0x21, 0x22 },
                    ObjectId = addRecord.ColumnTestObject?.Id ?? 99, 
                    ObjectDescription = addRecord.ColumnTestObject?.Description ?? "Add some Text",
                    Created = DateTime.Now,
                    Modified = DateTime.Now
                };

                _dataContext.TestData.Add(newRecord);

                _dataContext.SaveChanges();
            }
            catch (Exception ex)
            {
                errorMessage = $"AddRecord error: {ExHelper.GetExceptionText(ex)}";
            }

            return errorMessage;
        }

        #endregion

        #region Edit Record

        private string EditRecord(TestDataModel editRecord)
        {
            string errorMessage = null;
            try
            {
                var dbRecord = GetRecord(editRecord.Id);
                dbRecord.ColumnInt32 = editRecord.ColumnInt32;
                dbRecord.ColumnDouble = editRecord.ColumnDouble;
                dbRecord.ColumnFloat = (float)editRecord.ColumnFloat;
                dbRecord.ColumnBool = editRecord.ColumnBool;
                dbRecord.ColumnString = editRecord.ColumnString;
                dbRecord.ColumnBytes = editRecord.ColumnBytes.ToArray();
                dbRecord.ObjectId = editRecord.ColumnTestObject.Id;
                dbRecord.ObjectDescription = editRecord.ColumnTestObject.Description;
                dbRecord.Modified = DateTime.Now;
                _dataContext.SaveChanges();
            }
            catch (Exception ex)
            {
                errorMessage = $"EditRecord error: {ExHelper.GetExceptionText(ex)}";
            }

            return errorMessage;
        }

        #endregion

        #region Delete Record

        private string DeleteRecord(TestDataModel deleteRecord)
        {
            string errorMessage = null;
            try
            {
                var dbRecord = GetRecord(deleteRecord.Id);
                _dataContext.TestData.Remove(dbRecord);
                _dataContext.SaveChanges();
            }
            catch (Exception ex)
            {
                errorMessage = $"DeleteRecord error: {ExHelper.GetExceptionText(ex)}";
            }

            return errorMessage;
        }

        #endregion

        #region Get Project from Database

        private DataModel GetRecord(long recordId)
        {
            DataModel dbRecord = null;

            try
            {
                dbRecord = _dataContext.TestData.Where(x => x.Id == recordId).FirstOrDefault();
                if (dbRecord == null)
                    throw new ApplicationException($"Projet Id {recordId} not found.");

            }
            catch (Exception ex)
            {
                throw new ApplicationException($"GetRecord error: {ExHelper.GetExceptionText(ex)}");
            }

            return dbRecord;
        }

        #endregion

        #endregion

        #region Fields

        private ITestEntities _dataContext;

        #endregion
    }
}

