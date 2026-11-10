using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Mirror : SvgIconBase
    {
        public Mirror()
        {
            Name = "mirror";
            Content = "<path d=\"M192 64H32v384h160zm-31 352s0 .1 0 0l-96.9.1-.1-.1V96.1l.1-.1H160v320zm95 64h-32V32h32zm32-416h160v384H288z\" />";
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
