using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Download : SvgIconBase
    {
        public Download()
        {
            Name = "download";
            Content = "<path d=\"M32 384v96h448v-96zM288 32h-64v128h-96l128 160 128-160h-96z\" />";
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
