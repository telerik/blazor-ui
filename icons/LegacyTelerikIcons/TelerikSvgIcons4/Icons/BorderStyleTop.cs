using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class BorderStyleTop : SvgIconBase
    {
        public BorderStyleTop()
        {
            Name = "border-style-top";
            Content = "<path d=\"M416 32v64H96V32zm-1 416H95v32h320zm33-352v320h32V96zM32 96v320h32V96z\" />";
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
