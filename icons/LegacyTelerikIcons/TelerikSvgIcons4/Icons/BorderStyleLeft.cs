using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class BorderStyleLeft : SvgIconBase
    {
        public BorderStyleLeft()
        {
            Name = "border-style-left";
            Content = "<path d=\"M32 96h64v320H32zm416 1v320h32V97zM96 64h320V32H96zm0 416h320v-32H96z\" />";
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
