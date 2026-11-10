using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Layout2By2 : SvgIconBase
    {
        public Layout2By2()
        {
            Name = "layout-2-by-2";
            Content = "<path d=\"M32 224h192V0H32zm224 0h192V0H256zM32 480h192V256H32zm224 0h192V256H256z\" />";
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
