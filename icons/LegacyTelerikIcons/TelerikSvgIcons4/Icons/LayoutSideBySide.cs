using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class LayoutSideBySide : SvgIconBase
    {
        public LayoutSideBySide()
        {
            Name = "layout-side-by-side";
            Content = "<path d=\"M32 384h416v96H32zm0-32h416v-96H32zm0-128h416v-96H32zM32 0v96h416V0z\" />";
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
