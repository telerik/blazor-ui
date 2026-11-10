using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class RectangleShape : SvgIconBase
    {
        public RectangleShape()
        {
            Name = "rectangle-shape";
            Content = "<path d=\"M448 128v256H64V128zm32-32H32v320h448z\" />";
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
