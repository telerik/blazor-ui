using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data
{
    public class ODataOrder
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipName { get; set; }
    }
}
