using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Filter instead.", false)]
    public class FilterSmall : SvgIconBase
    {
        public FilterSmall()
        {
            Name = "filter-small";
            Content = "<path d=\"M128 128h256v32l-96 96v96l-64 64V256l-96-96z\" />";
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
