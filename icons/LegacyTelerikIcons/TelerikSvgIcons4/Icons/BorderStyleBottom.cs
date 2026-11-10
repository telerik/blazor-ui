using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class BorderStyleBottom : SvgIconBase
    {
        public BorderStyleBottom()
        {
            Name = "border-style-bottom";
            Content = "<path d=\"M96 480v-64h320v64zm1-416h320V32H97zM64 416V96H32v320zm416 0V96h-32v320z\" />";
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
