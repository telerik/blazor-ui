using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Digg : SvgIconBase
    {
        public Digg()
        {
            Name = "digg";
            Content = "<path d=\"M96 96v64H32v160h96V96zm64 0v32h32V96zm0 64v160h32V160zm64 0v160h64v32h-64v32h96V160zm128 0v160h64v32h-64v32h96V160zM64 192h32v96H64zm192 0h32v96h-32zm128 0h32v96h-32z\" />";
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
