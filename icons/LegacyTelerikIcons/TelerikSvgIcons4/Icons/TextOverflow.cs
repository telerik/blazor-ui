using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class TextOverflow : SvgIconBase
    {
        public TextOverflow()
        {
            Name = "text-overflow";
            Content = "<path d=\"M288 304v176h32V304zm0-272v176h32V32zM64 32v448h32V32zm288 288v-48H128v-32h224v-48l96 64z\" />";
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
