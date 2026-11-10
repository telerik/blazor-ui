using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Pause instead.", false)]
    public class PauseSm : SvgIconBase
    {
        public PauseSm()
        {
            Name = "pause-sm";
            Content = "<path d=\"M288 96h96v320h-96zM96 416h96V96H96z\" />";
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
