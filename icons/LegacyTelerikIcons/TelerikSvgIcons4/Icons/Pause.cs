using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Pause : SvgIconBase
    {
        public Pause()
        {
            Name = "pause";
            Content = "<path d=\"M320 0h160v512H320zM32 512h160V0H32z\" />";
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
