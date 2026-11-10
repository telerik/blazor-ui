using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class ArrowShape : SvgIconBase
    {
        public ArrowShape()
        {
            Name = "arrow-shape";
            Content = "<path d=\"m480 32-4.81 20.87-1.96 8.47-27.13 117.55-45.2-45.19-158.19 158.19L54.57 480 32 457.43l73.31-73.31 95.88-95.88 18.94-18.93-.02-.02L378.3 111.1l-45.19-45.2 117.55-27.13 8.47-1.96z\" />";
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
