using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Circle : SvgIconBase
    {
        public Circle()
        {
            Name = "circle";
            Content = "<path d=\"M384 256c0 70.7-57.3 128-128 128s-128-57.3-128-128 57.3-128 128-128 128 57.3 128 128\" />";
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
