using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gRPCsample.Server.Data
{
    public interface ITestEntities
    {
        List<DataModel> TestData { get; set; }
        void SaveChanges();
    }
}
