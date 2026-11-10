using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Blur : SvgIconBase
    {
        public Blur()
        {
            Name = "blur";
            Content = "<path d=\"M384 320c0 64-32 128-128 128-64 0-128-48-128-128 0-96 128-128 128-256 0 0 128 129.1 128 256\" />";
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
