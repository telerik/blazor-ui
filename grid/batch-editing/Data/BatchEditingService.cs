using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatchEditing.Data
{
    public class BatchEditingService
    {
        private List<BatchEditModel> Data { get; set; }
        public BatchEditingService()
        {
            if (Data == null)
            {
                var rng = new Random();
                Data = Enumerable.Range(1, 50).Select(index => new BatchEditModel
                {

                    Id = index,
                    Name = $"Name {index}",
                    Age = rng.Next(18, 100),
                    HireDate = DateTime.Now.Date.AddDays(-index)
                }).ToList();

            }
        }
        public Task<List<BatchEditModel>> GetData()
        {
            return Task.FromResult(Data);
        }

        public Task<List<BatchEditModel>> BatchUpdate(
            List<BatchEditModel> deletedItems, List<BatchEditModel> insertedItems, List<BatchEditModel> updatedItems)
        {
            //just sample CRUD operations
            //this is a singleton service to cater for all users at the same time
            //in a real app it may be transient instead
            //also, this code does not cater for concurrency conflicts and errors
            //while a real service should take them into account
            //e.g., insert instead of attempt an update on a missing item that another user deleted
            //in this example this also returns the newly updated data for the grid
            foreach (BatchEditModel item in deletedItems)
            {
                Data.Remove(item);
            }

            foreach (BatchEditModel item in insertedItems)
            {
                item.Id = Data.Max(item => item.Id) + 1;
                Data.Insert(0, item);
            }

            foreach (BatchEditModel item in updatedItems)
            {
                var index = Data.FindIndex(i => i.Id == item.Id);
                if (index != -1)
                {
                    Data[index] = item;
                }
            }

            //clean up the view model information to be sure we do not "predefine" user actions
            foreach (BatchEditModel item in Data)
            {
                item.IsChanged = false;
                item.IsDeleted = false;
                item.IsNew = false;
            }

            return Task.FromResult(Data);
        }
    }
}
