using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class ColResize : SvgIconBase
    {
        public ColResize()
        {
            Name = "col-resize";
            Content = "<path d=\"M128 255h64v33h-64v64.6L0 271.9l128-80.7zm96 225h64V32h-64zm288-207.9-128-80.7V256h-64v33h64v63.9z\" />";
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
