using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class ArrowsLeftRight : SvgIconBase
    {
        public ArrowsLeftRight()
        {
            Name = "arrows-left-right";
            Content = "<path d=\"m512 240-128-80v64H128v-64L0 240l128 80v-64h256v64z\" />";
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
