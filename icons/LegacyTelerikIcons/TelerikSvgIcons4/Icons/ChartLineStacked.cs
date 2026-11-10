using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class ChartLineStacked : SvgIconBase
    {
        public ChartLineStacked()
        {
            Name = "chart-line-stacked";
            Content = "<path d=\"M480 448v32H32V32h32v416zM224 292l128 64 128-96v-36l-128 96-128-64-128 96v36zm0-160 128 92 128-60v-36l-128 60-128-92-128 64v36z\" />";
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
