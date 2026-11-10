using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class FontFamily : SvgIconBase
    {
        public FontFamily()
        {
            Name = "font-family";
            Content = "<path d=\"M224 416V160h-95l-.8-64H384v64h-96v256z\" />";
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
