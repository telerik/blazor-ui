using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Minus instead.", false)]
    public class MinusSm : SvgIconBase
    {
        public MinusSm()
        {
            Name = "minus-sm";
            Content = "<path d=\"M352 224v64H160v-64z\" />";
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
