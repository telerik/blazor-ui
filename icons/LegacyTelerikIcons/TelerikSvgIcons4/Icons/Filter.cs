using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Filter : SvgIconBase
    {
        public Filter()
        {
            Name = "filter";
            Content = "<path d=\"M64 64v32l160 160v224l64-64V256L448 96V64z\" />";
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
