using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use ArrowUp instead.", false)]
    public class ArrowUpOutline : SvgIconBase
    {
        public ArrowUpOutline()
        {
            Name = "arrow-up-outline";
            Content = "<path d=\"M240 432V121.555L139.868 232.311c-5.926 6.554-16.044 7.064-22.599 1.138s-7.063-16.044-1.137-22.598l128-141.581.288-.31a16 16 0 0 1 23.448.31l128 141.581c5.926 6.554 5.417 16.672-1.138 22.598s-16.672 5.416-22.598-1.138L272 121.555V432c0 8.837-7.164 16-16 16s-16-7.163-16-16\" />";
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
