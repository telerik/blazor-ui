using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class ChartBarStacked : SvgIconBase
    {
        public ChartBarStacked()
        {
            Name = "chart-bar-stacked";
            Content = "<path d=\"M64 448v-64h352V224H64v-32h256V32H32v448h448v-32zm0-384h96v96H64zm192 192v96H64v-96z\" />";
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
