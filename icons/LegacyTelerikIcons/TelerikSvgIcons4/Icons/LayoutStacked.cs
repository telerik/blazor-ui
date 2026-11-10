using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class LayoutStacked : SvgIconBase
    {
        public LayoutStacked()
        {
            Name = "layout-stacked";
            Content = "<path d=\"M32 256h192v96H32zm0 224h192v-96H32zm224-128h192v-96H256zM32 0v224h416V0zm224 480h192v-96H256z\" />";
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
