using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class ArrowsMove : SvgIconBase
    {
        public ArrowsMove()
        {
            Name = "arrows-move";
            Content = "<path d=\"M384 320v-32h-96v96h32l-64 96-64-96h32v-96h-96v32l-96-64 96-64v32h96v-96h-32l64-96 64 96h-32v96h96v-32l96 64z\" />";
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
