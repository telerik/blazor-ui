using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class SizeToGrid : SvgIconBase
    {
        public SizeToGrid()
        {
            Name = "size-to-grid";
            Content = "<path d=\"M384 384H128V128h256zM96 0H64v512h32zm352 0h-32v512h32zm64 64H0v32h512zm0 352H0v32h512z\" />";
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
