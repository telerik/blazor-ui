using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikBlazorGrid_Dapper.DataAccess.Models
{
    public class DataSourceRequestTemplates
    {
        public SqlBuilder.Template SelectTemplate { get; set; }
        public SqlBuilder.Template CountTemplate { get; set; }
    }
}
