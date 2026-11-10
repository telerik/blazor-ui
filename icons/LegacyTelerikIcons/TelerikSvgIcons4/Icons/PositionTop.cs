using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class PositionTop : SvgIconBase
    {
        public PositionTop()
        {
            Name = "position-top";
            Content = "<path d=\"M480 448V32H32v448h448zm-416 0V64h384v384zM96 96h320v96H96z\" />";
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
