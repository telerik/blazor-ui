using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class ChartColumnStacked : SvgIconBase
    {
        public ChartColumnStacked()
        {
            Name = "chart-column-stacked";
            Content = "<path d=\"M320 192v256h-32V96H128v352H64V32H32v448h448V192zM160 448V256h96v192zm192 0v-96h96v96z\" />";
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
