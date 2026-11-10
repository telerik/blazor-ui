using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Rows : SvgIconBase
    {
        public Rows()
        {
            Name = "rows";
            Content = "<path d=\"M480 64v96H32V64zM32 192v96h448v-96zm448 128H32v96h448z\" />";
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
