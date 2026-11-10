using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class ListUnorderedSquare : SvgIconBase
    {
        public ListUnorderedSquare()
        {
            Name = "list-unordered-square";
            Content = "<path d=\"M128 160H32V64h96zm0 64H32v96h96zm0 160H32v96h96zm64-256h288V96H192zm0 160h288v-32H192zm0 160h288v-32H192z\" />";
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
