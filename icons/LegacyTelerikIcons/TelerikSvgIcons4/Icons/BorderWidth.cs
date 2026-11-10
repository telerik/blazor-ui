using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class BorderWidth : SvgIconBase
    {
        public BorderWidth()
        {
            Name = "border-width";
            Content = "<path d=\"M480 192H32V96h448zm0 32H32v64h448zm0 96H32v32h448zm0 64H32v16h448z\" />";
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
