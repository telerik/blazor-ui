using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use FilterSortDesc instead.", false)]
    public class FilterSortDescSmall : SvgIconBase
    {
        public FilterSortDescSmall()
        {
            Name = "filter-sort-desc-small";
            Content = "<path d=\"M448 128v32l-96 96v64l-32 64V256l-96-96v-32zM144 384l80-96h-64V128h-32v160H64z\" />";
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
