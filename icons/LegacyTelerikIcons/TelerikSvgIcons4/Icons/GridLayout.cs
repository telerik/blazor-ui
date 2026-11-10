using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class GridLayout : SvgIconBase
    {
        public GridLayout()
        {
            Name = "grid-layout";
            Content = "<path d=\"M32 32h96v96H32zm128 0v96h320V32zM32 288h96v-96H32zm128 0h320v-96H160zM32 448h96v-96H32zm128 0h320v-96H160z\" />";
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
