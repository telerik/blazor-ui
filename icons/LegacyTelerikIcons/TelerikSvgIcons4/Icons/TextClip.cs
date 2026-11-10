using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class TextClip : SvgIconBase
    {
        public TextClip()
        {
            Name = "text-clip";
            Content = "<path d=\"M64 32v448h32V32zm384 448V32h-32v448zM320 320v-48H128v-32h192v-48l96 64z\" />";
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
