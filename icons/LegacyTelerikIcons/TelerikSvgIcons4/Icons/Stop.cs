using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Stop : SvgIconBase
    {
        public Stop()
        {
            Name = "stop";
            Content = "<path d=\"M32 32h448v448H32z\" />";
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
