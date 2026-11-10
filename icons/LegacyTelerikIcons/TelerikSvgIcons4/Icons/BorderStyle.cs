using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class BorderStyle : SvgIconBase
    {
        public BorderStyle()
        {
            Name = "border-style";
            Content = "<path d=\"M32 96h32v320H32zm416 1h32v320h-32zM96 32h320v32H96zm0 416h320v32H96z\" />";
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
