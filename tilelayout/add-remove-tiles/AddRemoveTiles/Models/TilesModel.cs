using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddRemoveTiles.Models
{
    public class TileItem
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool Visible { get; set; } = true;        
        public int RowSpan { get; set; }
        public int Colspan { get; set; }       
    }
}
