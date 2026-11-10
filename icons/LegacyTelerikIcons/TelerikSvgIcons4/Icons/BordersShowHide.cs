using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class BordersShowHide : SvgIconBase
    {
        public BordersShowHide()
        {
            Name = "borders-show-hide";
            Content = "<path d=\"M64 448h128v32H32V32h448v128h-32V64H64zm384 0h-64v32h96v-96h-32zM160 288v-64H96v64zm64 0h64v-64h-64zm160-32v-32h-32v32zM288 96h-64v64h64zm0 384L160 352l45-45 83 83 147-147 45 45z\" />";
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
