using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class RoundCorners : SvgIconBase
    {
        public RoundCorners()
        {
            Name = "round-corners";
            Content = "<path d=\"M448 320c0 70.692-57.308 128-128 128H192c-70.692 0-128-57.308-128-128V192c0-70.692 57.308-128 128-128h128c70.692 0 128 57.308 128 128z\" />";
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
