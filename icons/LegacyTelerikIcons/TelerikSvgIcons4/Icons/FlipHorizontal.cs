using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class FlipHorizontal : SvgIconBase
    {
        public FlipHorizontal()
        {
            Name = "flip-horizontal";
            Content = "<path d=\"M448 448H288V64zm-384 0L224 64v384zm128-224-80 192h80z\" />";
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
