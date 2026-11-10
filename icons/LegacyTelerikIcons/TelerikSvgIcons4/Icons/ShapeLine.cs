using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class ShapeLine : SvgIconBase
    {
        public ShapeLine()
        {
            Name = "shape-line";
            Content = "<path d=\"M480 54.6 54.6 480 32 457.4 457.4 32z\" />";
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
