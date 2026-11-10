using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class RowCollapse : SvgIconBase
    {
        public RowCollapse()
        {
            Name = "row-collapse";
            Content = "<path d=\"M256 416v-64h64l-80-128-80 128h64v64zM32 224h32v96H32zm384 0h32v96h-32zM32 0v160h416V0zm128 128H64V32h96zm128 0h-96V32h96zm128 0h-96V32h96zM64 448h64v32H64zm-32-64h32v96H32zm160 64h96v32h-96zm224-64h32v96h-32zm-64 64h64v32h-64z\" />";
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
