using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class OvalShape : SvgIconBase
    {
        public OvalShape()
        {
            Name = "oval-shape";
            Content = "<path d=\"M256 384c106.04 0 192-57.31 192-128s-85.96-128-192-128S64 185.31 64 256s85.96 128 192 128\" />";
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
