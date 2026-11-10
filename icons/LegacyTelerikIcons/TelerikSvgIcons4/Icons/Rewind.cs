using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Rewind : SvgIconBase
    {
        public Rewind()
        {
            Name = "rewind";
            Content = "<path d=\"M256 256 512 96v320zm0 160V96L0 256z\" />";
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
