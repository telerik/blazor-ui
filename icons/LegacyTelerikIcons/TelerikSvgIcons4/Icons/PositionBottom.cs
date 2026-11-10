using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class PositionBottom : SvgIconBase
    {
        public PositionBottom()
        {
            Name = "position-bottom";
            Content = "<path d=\"M32 64v416h448V32H32zm416 0v384H64V64zM96 320h320v96H96z\" />";
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
