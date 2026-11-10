using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class ChartBarClustered : SvgIconBase
    {
        public ChartBarClustered()
        {
            Name = "chart-bar-clustered";
            Content = "<path d=\"M64 448v-64h160V224H64v-32h352V32H32v448h448v-32zm128-192v96H64v-96z\" />";
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
