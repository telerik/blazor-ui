using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Window : SvgIconBase
    {
        public Window()
        {
            Name = "window";
            Content = "<path d=\"M96 96v320h320V96zm288 288H128V192h256z\" />";
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
