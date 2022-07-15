using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdjustHeightWithBrowser.Data
{
    public class CityService
    {
        string _dataPath = $"Data{Path.DirectorySeparatorChar}worldcities.csv";
        public Task<List<City>> GetCitiesAsync()
        {
            List<City> cityList = null;
            if (File.Exists(_dataPath))
            {
                using (TextFieldParser csvParser = new TextFieldParser(_dataPath))
                {
                    csvParser.SetDelimiters(new string[] { "," });
                    csvParser.HasFieldsEnclosedInQuotes = true;

                    // Skip Row with column names
                    csvParser.ReadLine();

                    cityList = new List<City>();
                    while (!csvParser.EndOfData)
                    {
                        // Read row
                        var values = csvParser.ReadFields();

                        // Convert CSV Values to City
                        var city = City.FromCSV(values);
                        if (city != null)
                        {
                            cityList.Add(city);
                        }
                    }
                }
            }

            return Task.FromResult(cityList);
        }
    }

}
