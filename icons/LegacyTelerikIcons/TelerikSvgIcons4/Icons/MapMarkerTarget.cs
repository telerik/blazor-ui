using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class MapMarkerTarget : SvgIconBase
    {
        public MapMarkerTarget()
        {
            Name = "map-marker-target";
            Content = "<path d=\"M256 0C158.8 0 80 78.8 80 176s176 336 176 336 176-238.8 176-336S353.2 0 256 0m0 288c-61.9 0-112-50.1-112-112S194.1 64 256 64s112 50.1 112 112-50.1 112-112 112m48-112c0 26.5-21.5 48-48 48s-48-21.5-48-48 21.5-48 48-48 48 21.5 48 48\" />";
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
