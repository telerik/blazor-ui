using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikBlazorGrid_Dapper.DataAccess.Models
{
    public class DataSourceResponse<T>
    {
        public DataSourceResponse()
        {

        }

        public DataSourceResponse(List<T> results, int count) : this()
        {
            Results = results;
            Count = count;
        }

        public List<T> Results { get; set; }
        public int Count { get; set; }
    }
}
