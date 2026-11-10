using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Overlap : SvgIconBase
    {
        public Overlap()
        {
            Name = "overlap";
            Content = "<path d=\"M320 320V64H64v256zM192 448h256V192h-96v160H192z\" />";
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
