using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class LevelUp : SvgIconBase
    {
        public LevelUp()
        {
            Name = "level-up";
            Content = "<path d=\"m128 288 80-128 80 128h-64v64h192v32H192v-96z\" />";
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
