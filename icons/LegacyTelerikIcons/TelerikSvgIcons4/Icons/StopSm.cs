using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Stop instead.", false)]
    public class StopSm : SvgIconBase
    {
        public StopSm()
        {
            Name = "stop-sm";
            Content = "<path d=\"M416 416H96V96h320z\" />";
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
