using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class LevelToTop : SvgIconBase
    {
        public LevelToTop()
        {
            Name = "level-to-top";
            Content = "<path d=\"m128 288 80-128 80 128h-64v64h192v32H192v-96zm288-160H96v32h320z\" />";
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
