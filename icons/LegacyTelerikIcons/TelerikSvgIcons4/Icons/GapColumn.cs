using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class GapColumn : SvgIconBase
    {
        public GapColumn()
        {
            Name = "gap-column";
            Content = "<path d=\"M32 32v448h448V32zm416 416H64V64h384zM96 96h96v320H96zm224 0h96v320h-96z\" />";
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
