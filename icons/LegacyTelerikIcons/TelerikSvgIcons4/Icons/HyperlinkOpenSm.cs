using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use HyperlinkOpen instead.", false)]
    public class HyperlinkOpenSm : SvgIconBase
    {
        public HyperlinkOpenSm()
        {
            Name = "hyperlink-open-sm";
            Content = "<path d=\"M96 416h320v-96h-32v64H128V128h64V96H96zM256 96h160v160l-57.4-57.4L237.3 320 192 274.7l121.4-121.4-.5-.5z\" />";
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
