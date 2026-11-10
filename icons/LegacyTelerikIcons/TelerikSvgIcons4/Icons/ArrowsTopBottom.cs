using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class ArrowsTopBottom : SvgIconBase
    {
        public ArrowsTopBottom()
        {
            Name = "arrows-top-bottom";
            Content = "<path d=\"m240 512 80-128h-64V128h64L240 0l-80 128h64v256h-64z\" />";
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
