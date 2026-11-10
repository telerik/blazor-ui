using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class BorderStyleRight : SvgIconBase
    {
        public BorderStyleRight()
        {
            Name = "border-style-right";
            Content = "<path d=\"M480 416h-64V96h64zm-416-1V95H32v320zm352 33H96v32h320zm0-416H96v32h320z\" />";
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
