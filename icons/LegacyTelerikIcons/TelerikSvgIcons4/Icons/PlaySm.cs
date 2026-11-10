using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Play instead.", false)]
    public class PlaySm : SvgIconBase
    {
        public PlaySm()
        {
            Name = "play-sm";
            Content = "<path d=\"M96 416V96l320 160z\" />";
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
