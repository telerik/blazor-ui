using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class WindowMinimize : SvgIconBase
    {
        public WindowMinimize()
        {
            Name = "window-minimize";
            Content = "<path d=\"M416 288v64H96v-64z\" />";
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
