using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use XCircle instead.", false)]
    public class XMarkSmOutline : SvgIconBase
    {
        public XMarkSmOutline()
        {
            Name = "x-mark-sm-outline";
            Content = "<path d=\"M100.686 100.687c6.249-6.249 16.379-6.249 22.627 0l132.689 132.688 132.685-132.686c6.249-6.248 16.379-6.248 22.627 0 6.249 6.249 6.249 16.38 0 22.628L278.629 256.002l132.684 132.685c6.249 6.248 6.249 16.378 0 22.626s-16.378 6.249-22.627 0L256.002 278.629 123.314 411.317c-6.248 6.248-16.378 6.248-22.627 0s-6.248-16.379 0-22.628l132.688-132.687-132.689-132.689c-6.248-6.248-6.248-16.378 0-22.626\" />";
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
