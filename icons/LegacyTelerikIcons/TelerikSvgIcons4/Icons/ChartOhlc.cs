using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class ChartOhlc : SvgIconBase
    {
        public ChartOhlc()
        {
            Name = "chart-ohlc";
            Content = "<path d=\"M480 448v32H32V32h32v416zM224 320V96h-32v32h-64v32h64v256h32v-64h64v-32zM416 96V32h-32v160h-64v32h64v96h32V128h64V96z\" />";
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
