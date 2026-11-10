using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class BringToFront : SvgIconBase
    {
        public BringToFront()
        {
            Name = "bring-to-front";
            Content = "<path d=\"M96 128V96h96V64H64v128h32zm224 256h64V128H128v256zm96-64v96h-96v32h128V320z\" />";
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
