using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class HexagonShape : SvgIconBase
    {
        public HexagonShape()
        {
            Name = "hexagon-shape";
            Content = "<path d=\"m349.62 96 93.33 160-93.33 160H162.38L69.05 256l93.33-160zM368 64H144L32 256l112 192h224l112-192z\" />";
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
