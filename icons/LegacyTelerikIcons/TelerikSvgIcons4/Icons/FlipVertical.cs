using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class FlipVertical : SvgIconBase
    {
        public FlipVertical()
        {
            Name = "flip-vertical";
            Content = "<path d=\"M64 288h384L64 448zm0-224v160h384zm32 128v-80l192 80z\" />";
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
