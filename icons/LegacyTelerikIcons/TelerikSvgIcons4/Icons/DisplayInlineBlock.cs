using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class DisplayInlineBlock : SvgIconBase
    {
        public DisplayInlineBlock()
        {
            Name = "display-inline-block";
            Content = "<path d=\"M448 32h32v448h-32zM32 32h32v448H32zm64 352h320V128H96zm64-192h192v128H160z\" />";
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
