using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Logout : SvgIconBase
    {
        public Logout()
        {
            Name = "logout";
            Content = "<path d=\"M128 32H32v448h96zm64 192v64h128v96l160-128-160-128v96z\" />";
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
