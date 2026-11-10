using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Upload : SvgIconBase
    {
        public Upload()
        {
            Name = "upload";
            Content = "<path d=\"M32 384v96h448v-96zm192-64h64V192h96L256 32 128 192h96z\" />";
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
