using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use FilterSortAsc instead.", false)]
    public class FilterSortAscSmall : SvgIconBase
    {
        public FilterSortAscSmall()
        {
            Name = "filter-sort-asc-small";
            Content = "<path d=\"M448 128v32l-96 96v64l-32 64V256l-96-96v-32zM64 224h64v160h32V224h64l-80-96z\" />";
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
