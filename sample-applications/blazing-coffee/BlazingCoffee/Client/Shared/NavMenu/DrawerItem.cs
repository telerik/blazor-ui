using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telerik.SvgIcons;

namespace BlazingCoffee.Client.Shared.NavMenu
{
    public class DrawerItem
    {
        public string Text { get; set; }

        public ISvgIcon? Icon { get; set; }

        public string Url { get; set; }

        public string Group { get; set; }
    }

}
