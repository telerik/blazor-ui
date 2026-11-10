using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class ArrowDown : SvgIconBase
    {
        public ArrowDown()
        {
            Name = "arrow-down";
            Content = "<path d=\"M128 224h96V96h64l.001 128H384L256.001 416z\" />";
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
