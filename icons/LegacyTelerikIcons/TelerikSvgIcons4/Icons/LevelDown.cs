using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class LevelDown : SvgIconBase
    {
        public LevelDown()
        {
            Name = "level-down";
            Content = "<path d=\"M288 192v64h64l-80 128-80-128h64v-64H128v-32h288v32z\" />";
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
