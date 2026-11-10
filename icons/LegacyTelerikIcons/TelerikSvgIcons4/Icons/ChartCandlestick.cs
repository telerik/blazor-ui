using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class ChartCandlestick : SvgIconBase
    {
        public ChartCandlestick()
        {
            Name = "chart-candlestick";
            Content = "<path d=\"M480 448v32H32V32h32v416zm-192-96h-64v64h-32v-64h-64V96h64V32h32v64h64zm-32-224h-96v192h96zm224 64h-64V64h-32v128h-64v128h64v64h32v-64h64z\" />";
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
