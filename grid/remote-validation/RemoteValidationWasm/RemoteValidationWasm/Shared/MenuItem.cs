using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteValidationWasm.Shared
{
    public class MenuItem
    {
        public string Text { get; set; }
        public string Url { get; set; }
        public List<MenuItem> Items { get; set; }
    }
}
