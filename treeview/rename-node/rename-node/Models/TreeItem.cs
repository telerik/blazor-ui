using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rename_node.Models
{
    /// <summary>
    /// Sample tree item model, uses the default field names.
    /// </summary>
    public class TreeItem
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int? ParentId { get; set; }
        public bool HasChildren { get; set; }
        public string Icon { get; set; }
        public bool Expanded { get; set; }
    }
}
