using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Cancel instead.", false)]
    public class CancelOutline : SvgIconBase
    {
        public CancelOutline()
        {
            Name = "cancel-outline";
            Content = "<path d=\"M256 32c-56.1 0-107.4 20.6-146.7 54.7-8.1 7-15.6 14.6-22.6 22.6C52.6 148.6 32 199.9 32 256c0 123.7 100.3 224 224 224 56.1 0 107.4-20.6 146.7-54.7 8.1-7 15.6-14.6 22.6-22.6C459.4 363.4 480 312.1 480 256c0-123.7-100.3-224-224-224m0 416c-106 0-192-86-192-192 0-47.2 17.1-90.5 45.4-124L380 402.6c-33.5 28.3-76.8 45.4-124 45.4m146.6-68L132 109.4C165.5 81.1 208.8 64 256 64c106 0 192 86 192 192 0 47.2-17.1 90.5-45.4 124\" />";
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
