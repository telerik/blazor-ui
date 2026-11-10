using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class HorizontalRule : SvgIconBase
    {
        public HorizontalRule()
        {
            Name = "horizontal-rule";
            Content = "<path d=\"M320 96H32V64h288zm96 32H32v32h384zm64 96H32v64h448zM320 352H32v32h288zm96 64H32v32h384z\" />";
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
