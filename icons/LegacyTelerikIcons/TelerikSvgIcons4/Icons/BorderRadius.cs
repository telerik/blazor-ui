using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class BorderRadius : SvgIconBase
    {
        public BorderRadius()
        {
            Name = "border-radius";
            Content = "<path d=\"M64 32h96v32H64v96H32V32zm384 416h-96v32h128V352h-32zM352 32v32h96v96h32V32zM64 352H32v128h128v-32H64z\" />";
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
