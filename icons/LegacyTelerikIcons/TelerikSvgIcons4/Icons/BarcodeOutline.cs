using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Barcode instead.", false)]
    public class BarcodeOutline : SvgIconBase
    {
        public BarcodeOutline()
        {
            Name = "barcode-outline";
            Content = "<path d=\"M96 384H64V128h32zm96-256h-64v224h64zm64 0h-32v224h32zm64 0h-32v224h32zm64 0h-32v224h32zm64 0h-32v256h32zm64-32v320c0 17.7-14.3 32-32 32H32c-17.7 0-32-14.3-32-32V96c0-17.7 14.3-32 32-32h448c17.7 0 32 14.3 32 32m-32 0H32v320h448z\" />";
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
