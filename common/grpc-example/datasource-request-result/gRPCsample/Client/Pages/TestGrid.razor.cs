using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gRPCsample.Shared;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor.Components;
using Telerik.DataSource;
using gRPCsample.Client.Models;
using gRPCsample.Shared.Helpers;
using gRPCsample.Client.Helpers;
using static gRPCsample.Shared.UpdateTypeModel.Types;

namespace gRPCsample.Client.Pages
{
    /// <summary>
    /// Code behind for the grid that is populated via gRPC
    /// </summary>
    public partial class TestGrid
    {
        #region Properties

        /// <summary>
        /// The gRPC service
        /// </summary>
        [Inject] public TestDataService.TestDataServiceClient TestDataServiceClient { get; set; }

        /// <summary>
        /// The Grid data, Needs to by type object to cater for the grouped data structure
        /// </summary>
        public IEnumerable<object> GridData { get; set; }

        /// <summary>
        /// Total number of records used by the Grid
        /// </summary>
        public int TotalRecords { get; set; }

        /// <summary>
        /// Reference to the grid component, used for creating records for insertion.
        /// </summary>
        public TelerikGrid<object> GridRef { get; set; }

        #endregion

        #region Page

        /// <summary>
        /// Callback function that is called when the (error) Message Window is closed
        /// </summary>
        /// <returns></returns>
        private Task MessageCallbackAsync()
        {
            _message = null;
            return Task.CompletedTask;
        }

        #endregion

        #region Grid

        #region Read

        /// <summary>
        /// The Grid Read Handler
        /// The DataSourceRequest is serialised and the sent to the service
        /// The response is processed.
        /// The structure is flat without grouping and passed to the grid.
        /// Grouped data is processed to produce the required structure for the grid.
        /// The callback function below is used for the grouping.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private async Task ReadHandler(GridReadEventArgs args)
        {
            try
            {
                _lastArgs = args;

                // Use the following lines to add the Token 
                //CallOptions options = await GrpcBearerTokenProvider.GetCallOptionsAsync();
                //var dataListResponse = (await TestDataServiceClient.GetTestDataAsync(new DataSourceProtoRequest(args.Request), options));

                var dataListResponse = (await TestDataServiceClient.GetTestDataAsync(new DataSourceProtoRequest(args.Request)));
                if (dataListResponse.Result.IsValid)
                {
                    TotalRecords = dataListResponse.Result.TotalRecords;
                    if (dataListResponse.GridData.SubGroups.Count == 0)
                    {
                        // Process the flat item list
                        var gridData = dataListResponse.GridData.GridRows.Unpack<TestDataListModel>();
                        GridData = gridData.Records.ToList();
                    }
                    else
                    {
                        // Process the grouped data
                        GridData = GridHelper.GetGroupedData(dataListResponse.GridData.SubGroups.ToList(), new DataListModelCallBack(UnpackProtoList));
                    }
                } else
                {
                    // Show Error message
                    _message = new MessageWindowModel()
                    {
                        Title = "Server error getting Test Data",
                        Message = dataListResponse.Result.ErrorMessage,
                    };
                }

                StateHasChanged();
            }
            catch (Exception ex)
            {
                // Show Error message
                _message = new MessageWindowModel()
                {
                    Title = "Error getting Test Data",
                    Message = ExHelper.GetExceptionText(ex)
                };
            }
        }

        /// <summary>
        /// Call back function to process the grouped data
        /// </summary>
        /// <param name="dataGroupModel"></param>
        /// <returns></returns>
        private IEnumerable<object> UnpackProtoList(DataGroupModel dataGroupModel)
        {
            if (dataGroupModel.GridRows == null)
                return null;
            else
            {
                var gridData = dataGroupModel.GridRows.Unpack<TestDataListModel>();
                return gridData.Records.ToList();
            }
        }

        #endregion

        #region Create
        /// <summary>
        /// A custom Add command that ensures a model instance is created for cases when there is no data in the grid
        /// see here https://docs.telerik.com/blazor-ui/components/grid/manual-operations#grouping-with-onread
        /// </summary>
        /// <returns></returns>
        async Task StartInsert()
        {
            var currState = GridRef.GetState();
            currState.EditItem = null;
            currState.OriginalEditItem = null;
            currState.InsertedItem = new TestDataModel();
            await GridRef.SetState(currState);
        }

        public async Task CreateHandler(GridCommandEventArgs args)
        {
            await UpdateDatabase((TestDataModel)args.Item, UpdateTypeEnum.Add);
        }

        #endregion

        #region Update

        public async Task UpdateHandler(GridCommandEventArgs args)
        {
            await UpdateDatabase((TestDataModel)args.Item, UpdateTypeEnum.Edit);
        }

        #endregion

        #region Delete

        void DeleteWithConfirmation(GridCommandEventArgs args)
        {
            // Prevent the built-in delete operation from firing
            args.IsCancelled = true;
            _itemToDelete = args.Item as TestDataModel;
            _showDeleteConfirmation = true;
        }

        private async void DeleteCallbackAsync()
        {
            if (_itemToDelete != null)
            {
                _showDeleteConfirmation = false;
                await UpdateDatabase(_itemToDelete, UpdateTypeEnum.Delete);
                _itemToDelete = null;
            }
        }

        #endregion

        #region Update Database

        public async Task UpdateDatabase(TestDataModel project, UpdateTypeEnum updateType)
        {
            try
            {
                UpdateDataRequest request = new UpdateDataRequest()
                {
                    Project = project,
                    UpdateType = new UpdateTypeModel() { Type = updateType }
                };

                var response = (await TestDataServiceClient.UpdateDataRecordAsync(request));
                if (!response.Result.IsValid)
                {
                    _message = new MessageWindowModel()
                    {
                        Title = "Server error updating Data",
                        Message = response.Result.ErrorMessage,
                    };
                }

                // Refresh the Grid
                await ReadHandler(_lastArgs);
            }
            catch (Exception ex)
            {
                _message = new MessageWindowModel()
                {
                    Title = "Error Updating Data",
                    Message = ExHelper.GetExceptionText(ex),
                };
            }
        }

        #endregion

        #endregion

        #region Fields

        private TestDataModel _itemToDelete;
        private bool _showDeleteConfirmation;
        private MessageWindowModel _message;
        private GridReadEventArgs _lastArgs;

        #endregion
    }
}
