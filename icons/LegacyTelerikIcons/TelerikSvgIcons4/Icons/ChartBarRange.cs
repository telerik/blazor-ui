using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class ChartBarRange : SvgIconBase
    {
        public ChartBarRange()
        {
            Name = "chart-bar-range";
            Content = "<path d=\"M480 448v32H32V32h32v416zm-96-192H160v96h224zm32-32v160H128V224zm64-192H256v160h224z\" />";
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
