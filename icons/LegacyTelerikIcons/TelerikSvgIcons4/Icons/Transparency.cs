using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Transparency : SvgIconBase
    {
        public Transparency()
        {
            Name = "transparency";
            Content = "<path d=\"M64 64v352h352V64zm32 32h96v96h96V96h96v96h-96v96h96v96h-96v-96h-96v96H96v-96h96v-96H96z\" />";
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
