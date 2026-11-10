using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class RotateRight : SvgIconBase
    {
        public RotateRight()
        {
            Name = "rotate-right";
            Content = "<path d=\"M320 448V64l160 384zm-32 0H32l256-160zm-32-102.3L143.6 416H256zM64 160v128h32v-96h96v64l96-80-96-80v64z\" />";
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
