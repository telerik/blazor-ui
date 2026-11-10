using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Checkbox : SvgIconBase
    {
        public Checkbox()
        {
            Name = "checkbox";
            Content = "<path d=\"M64 64v384h384V64zm352 352H96V96h320z\" />";
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
