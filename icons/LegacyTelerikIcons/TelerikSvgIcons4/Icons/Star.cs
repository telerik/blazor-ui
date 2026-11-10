using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Star : SvgIconBase
    {
        public Star()
        {
            Name = "star";
            Content = "<path d=\"M256 391.5 117.2 480 154 314.1 32 202.4 192.9 188 256 32l63.1 156L480 202.4 358 314.1 394.8 480z\" />";
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
