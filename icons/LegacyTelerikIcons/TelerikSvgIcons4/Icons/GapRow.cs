using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class GapRow : SvgIconBase
    {
        public GapRow()
        {
            Name = "gap-row";
            Content = "<path d=\"M480 32H32v448h448zM64 448V64h384v384zM96 96h320v96H96zm0 224h320v96H96z\" />";
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
