using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Barcode : SvgIconBase
    {
        public Barcode()
        {
            Name = "barcode";
            Content = "<path d=\"M480 64H32C14.3 64 0 78.3 0 96v320c0 17.7 14.3 32 32 32h448c17.7 0 32-14.3 32-32V96c0-17.7-14.3-32-32-32M96 384H64V128h32zm96-32h-64V128h64zm64 0h-32V128h32zm64 0h-32V128h32zm64 0h-32V128h32zm64 32h-32V128h32z\" />";
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
