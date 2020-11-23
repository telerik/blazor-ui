using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiSelectAndAddButton.Data
{
    public class MsOptionsService
    {
        private List<OptionsModel> _dataSource { get; set; } = new List<OptionsModel>
        {
            new OptionsModel { StringRepresentation = "first",  MyValueField = 1 },
            new OptionsModel { StringRepresentation = "second", MyValueField = 2 },
            new OptionsModel { StringRepresentation = "third", MyValueField = 3 }
        };

        public async Task<List<OptionsModel>> GetOptions()
        {
            await Task.Delay(200); // simulate network delay, remove it for a real app

            List<OptionsModel> optionssData = new List<OptionsModel>(_dataSource);
            return await Task.FromResult(optionssData);
        }

        public async Task<OptionsModel> AddOption(string optionName)
        {
            await Task.Delay(200); // simulate network delay, remove it for a real app
            
            OptionsModel insertedOption = new OptionsModel() { MyValueField = _dataSource.Count + 1, StringRepresentation = optionName };

            _dataSource.Add(insertedOption);

            return await Task.FromResult(insertedOption);
        }

    }
}
