using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class DisplayBlock : SvgIconBase
    {
        public DisplayBlock()
        {
            Name = "display-block";
            Content = "<path d=\"M32 32h448v32H32zm0 416h448v32H32zm0-64h448V128H32zm64-192h320v128H96z\" />";
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
