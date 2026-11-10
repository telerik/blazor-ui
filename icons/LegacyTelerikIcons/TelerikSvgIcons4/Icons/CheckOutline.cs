using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Check instead.", false)]
    public class CheckOutline : SvgIconBase
    {
        public CheckOutline()
        {
            Name = "check-outline";
            Content = "<path d=\"M256 32C132.3 32 32 132.3 32 256s100.3 224 224 224 224-100.3 224-224S379.7 32 256 32m0 416c-106 0-192-86-192-192S150 64 256 64s192 86 192 192-86 192-192 192m-32-154-83-83-45 45 128 128 176-176-45-45z\" />";
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
