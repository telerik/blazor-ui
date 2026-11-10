using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class ArrowDownLeft : SvgIconBase
    {
        public ArrowDownLeft()
        {
            Name = "arrow-down-left";
            Content = "<path d=\"M384 128v160H224v-64L96 304l128 80v-64h192V128\" />";
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
