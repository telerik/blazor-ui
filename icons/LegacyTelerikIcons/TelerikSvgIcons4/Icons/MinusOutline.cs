using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Minus instead.", false)]
    public class MinusOutline : SvgIconBase
    {
        public MinusOutline()
        {
            Name = "minus-outline";
            Content = "<path d=\"M128 224h256v64H128zM256 32C132.3 32 32 132.3 32 256s100.3 224 224 224 224-100.3 224-224S379.7 32 256 32m0 416c-106 0-192-86-192-192S150 64 256 64s192 86 192 192-86 192-192 192\" />";
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
