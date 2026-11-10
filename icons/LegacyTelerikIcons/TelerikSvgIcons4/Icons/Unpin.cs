using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Unpin : SvgIconBase
    {
        public Unpin()
        {
            Name = "unpin";
            Content = "<path d=\"M256 320h160c17.6 0 32-14.4 32-32v-96c0-17.6-14.4-32-32-32H256V96h-32v128H64v32h160v128h32zm0-128h160v64H256z\" />";
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
