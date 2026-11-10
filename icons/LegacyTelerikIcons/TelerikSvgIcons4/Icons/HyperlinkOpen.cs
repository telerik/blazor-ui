using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class HyperlinkOpen : SvgIconBase
    {
        public HyperlinkOpen()
        {
            Name = "hyperlink-open";
            Content = "<path d=\"M32 480h448V256h-32v192H64V64h192V32H32zM320 32l56.9 56.9.5.5L224 242.7l45.3 45.3 153.3-153.4L480 192V32z\" />";
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
