using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Plus instead.", false)]
    public class PlusSm : SvgIconBase
    {
        public PlusSm()
        {
            Name = "plus-sm";
            Content = "<path d=\"M352 224v64h-64v64h-64v-64h-64v-64h64v-64h64v64z\" />";
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
