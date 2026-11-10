using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Reorder : SvgIconBase
    {
        public Reorder()
        {
            Name = "reorder";
            Content = "<path d=\"M480 128v64H32v-64zM32 224v64h448v-64zm448 96H32v64h448z\" />";
            ViewBox = "0 0 512 512";
            Variants = new System.Collections.Generic.Dictionary<string, string>
            {
                { "solid", "" },
                { "outline", "" },
                { "duotone", "" }
            };
        }
    }
}
