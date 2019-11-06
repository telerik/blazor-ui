using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data
{
    public class ODataOrdersResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("value")]
        public List<ODataOrder> Orders { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("@odata.count")]
        public int Total { get; set; }
    }
}
