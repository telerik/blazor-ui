using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikBlazorGrid_Dapper.DataAccess.Models
{
    public class SqlBuilderAppendage
    {
        public SqlBuilderAppendage(string sql, dynamic? parameters = null)
        {
            Sql = sql;
            Parameters = parameters;
        }

        public string Sql { get; }
        public dynamic Parameters { get; }
    }
}
