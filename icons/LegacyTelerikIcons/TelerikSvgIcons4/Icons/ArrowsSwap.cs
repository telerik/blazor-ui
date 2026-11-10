using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class ArrowsSwap : SvgIconBase
    {
        public ArrowsSwap()
        {
            Name = "arrows-swap";
            Content = "<path d=\"M256 160h-64v224h-32V160H96l80-128zm96 192V128h-32v224h-64l80 128 80-128z\" />";
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
