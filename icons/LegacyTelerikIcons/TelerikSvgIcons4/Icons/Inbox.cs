using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Inbox : SvgIconBase
    {
        public Inbox()
        {
            Name = "inbox";
            Content = "<path d=\"M384 32H128L32 288v160c0 17.7 14.3 32 32 32h384c17.7 0 32-14.3 32-32V288zM150.2 64h211.6l84 224H352l-32 64H192l-32-64H66.2z\" />";
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
