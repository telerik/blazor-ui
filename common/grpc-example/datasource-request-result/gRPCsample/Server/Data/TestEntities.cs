using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gRPCsample.Server.Data
{
    public class TestEntities : ITestEntities
    {
        public TestEntities()
        {
            var data = new List<DataModel>();
            int doubleValue = 1;
            int intValue = 1;
            for (int count = 1; count < 500; count++)
            {
                if (count % 10 == 0)
                    doubleValue++;

                if (count % 5 == 0)
                    intValue++;

                data.Add(new DataModel()
                {
                    Id = count,
                    ColumnInt32 = intValue,
                    ColumnDouble = doubleValue,
                    ColumnFloat = (float)count / 3,
                    ColumnBool = count % 2 == 1,
                    ColumnString = $"Test Data {count}",
                    ColumnBytes = new byte[] { 0x10, 0x11, 0x12 },
                    ObjectId = count,
                    ObjectDescription = $"Test Object Description {count}",
                    Created = DateTimeOffset.Now.AddDays(count),
                    Modified = DateTime.Now.AddDays(count)
                });
            }

            TestData = data;
        }

        public void SaveChanges()
        {
        }

        public List<DataModel> TestData { get; set; }
    }
}
