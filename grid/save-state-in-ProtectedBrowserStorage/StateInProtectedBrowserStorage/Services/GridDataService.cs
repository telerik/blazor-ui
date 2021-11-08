using StateInProtectedBrowserStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateInProtectedBrowserStorage.Services
{
    // the following static class mimics an actual data service that handles the actual data source
    // replace it with your actual service through the DI, this only mimics how the API can look like and works for this basic project
    public class GridDataService
    {
        private static List<SampleData> _data { get; set; } = new List<SampleData>();

        public async Task Create(SampleData itemToInsert)
        {
            itemToInsert.Id = _data.Count + 1;
            _data.Insert(0, itemToInsert);
        }

        public async Task<List<SampleData>> Read()
        {
            if (_data.Count < 1)
            {
                for (int i = 1; i < 50; i++)
                {
                    _data.Add(new SampleData()
                    {
                        Id = i,
                        Name = "name " + i,
                        Team = "team " + i % 5
                    });
                }
            }

            return await Task.FromResult(_data);
        }

        public async Task Update(SampleData itemToUpdate)
        {
            var index = _data.FindIndex(i => i.Id == itemToUpdate.Id);
            if (index != -1)
            {
                _data[index] = itemToUpdate;
            }
        }

        public async Task Delete(SampleData itemToDelete)
        {
            _data.Remove(itemToDelete);
        }
    }
}
