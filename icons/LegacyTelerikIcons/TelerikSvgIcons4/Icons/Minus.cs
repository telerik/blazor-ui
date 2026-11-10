using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Minus : SvgIconBase
    {
        public Minus()
        {
            Name = "minus";
            Content = "<path d=\"M96 224v64h320v-64z\" />";
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
