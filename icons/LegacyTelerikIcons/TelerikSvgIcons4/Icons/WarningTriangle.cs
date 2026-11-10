using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class WarningTriangle : SvgIconBase
    {
        public WarningTriangle()
        {
            Name = "warning-triangle";
            Content = "<path d=\"M256 32 0 480h512zm-32 160h64v160h-64zm0 256v-64h64v64z\" />";
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
