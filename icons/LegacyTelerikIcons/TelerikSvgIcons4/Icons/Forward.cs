using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Forward : SvgIconBase
    {
        public Forward()
        {
            Name = "forward";
            Content = "<path d=\"M0 416V96l256 160zm512-160L256 96v320z\" />";
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
