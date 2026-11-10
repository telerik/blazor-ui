using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class PositionRight : SvgIconBase
    {
        public PositionRight()
        {
            Name = "position-right";
            Content = "<path d=\"M64 480h416V32H32v448zm0-416h384v384H64zm256 32h96v320h-96z\" />";
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
