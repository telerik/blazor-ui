using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikBlazorGrid_Dapper.DataAccess.Models
{
    internal class FilterDescriptorProperties
    {
        public string Op { get; set; }
        public string ValuePrefix { get; set; }
        public string ValueSuffix { get; set; }
        public bool HasValue { get; set; } = true;
    }
}
