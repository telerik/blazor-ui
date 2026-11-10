using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class SnapGrid : SvgIconBase
    {
        public SnapGrid()
        {
            Name = "snap-grid";
            Content = "<path d=\"M480 128V96h-96V0h-32v96h-96V0h-32v96h-96V0H96v96H0v32h96v96H0v32h96v96H0v32h96v96h32v-96h96v96h32v-96h96v96h32v-96h96v-32h-96v-96h96v-32h-96v-96zm-352 0h96v96h-96zm0 224v-96h96v96zm224 0h-96v-96h96zm0-128h-96v-96h96z\" />";
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
