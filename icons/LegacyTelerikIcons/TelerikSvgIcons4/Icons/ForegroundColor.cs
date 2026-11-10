using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class ForegroundColor : SvgIconBase
    {
        public ForegroundColor()
        {
            Name = "foreground-color";
            Content = "<path d=\"M299.5 96h-87.1L96 416h64l23.3-64h145.4l23.3 64h64zm-92.9 192L256 152.2 305.4 288z\" />";
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
