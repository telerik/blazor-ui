using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Login : SvgIconBase
    {
        public Login()
        {
            Name = "login";
            Content = "<path d=\"M384 480h96V32h-96zM32 224v64h128v96l160-128-160-128v96z\" />";
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
