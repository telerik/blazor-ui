using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appointment_context_menu.Models
{
    public class ContextMenuItem
    {
        public string Text { get; set; }
        public string CommandName { get; set; }
        public string Icon { get; set; }
        public bool Disabled { get; set; }
    }
}
