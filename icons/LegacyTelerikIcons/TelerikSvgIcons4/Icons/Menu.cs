using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Menu : SvgIconBase
    {
        public Menu()
        {
            Name = "menu";
            Content = "<path d=\"M480 32v96H32V32zM32 192v96h448v-96zm448 160H32v96h448z\" />";
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
