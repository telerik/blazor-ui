using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class MenuFilter : SvgIconBase
    {
        public MenuFilter()
        {
            Name = "menu-filter";
            Content = "<path d=\"M448 128v32l-96 96v64l-32 64V256l-96-96v-32zM256 256l-96 128-96-128z\" />";
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
