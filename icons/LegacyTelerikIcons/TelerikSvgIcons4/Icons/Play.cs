using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Play : SvgIconBase
    {
        public Play()
        {
            Name = "play";
            Content = "<path d=\"M0 512V0l512 256z\" />";
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
