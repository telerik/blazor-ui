using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class RotateLeft : SvgIconBase
    {
        public RotateLeft()
        {
            Name = "rotate-left";
            Content = "<path d=\"M32 448 192 64v384zm192-160 256 160H224zm32 128h112.4L256 345.7zm64-256V96l-96 80 96 80v-64h96v96h32V160z\" />";
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
