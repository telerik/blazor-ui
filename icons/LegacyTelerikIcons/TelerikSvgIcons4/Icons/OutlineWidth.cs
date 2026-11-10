using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class OutlineWidth : SvgIconBase
    {
        public OutlineWidth()
        {
            Name = "outline-width";
            Content = "<path d=\"M416 32H32v448h448V32zm0 384H96V96h320zm-256-32h224V128H128v256zm0-224h192v192H160z\" />";
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
