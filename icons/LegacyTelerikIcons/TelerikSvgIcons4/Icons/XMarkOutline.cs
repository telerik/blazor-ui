using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use XCircle instead.", false)]
    public class XMarkOutline : SvgIconBase
    {
        public XMarkOutline()
        {
            Name = "x-mark-outline";
            Content = "<path d=\"M452.687 36.687c6.248-6.249 16.379-6.249 22.628 0s6.248 16.378 0 22.627L278.627 256l196.687 196.687c6.248 6.248 6.248 16.378 0 22.626s-16.379 6.249-22.627 0L256 278.627 59.315 475.313c-6.249 6.249-16.38 6.249-22.628 0s-6.248-16.378 0-22.626L233.373 256 36.687 59.314c-6.249-6.249-6.249-16.38 0-22.627 6.248-6.249 16.378-6.249 22.627 0L256 233.373z\" />";
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
