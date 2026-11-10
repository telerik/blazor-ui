using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class ArrowRight : SvgIconBase
    {
        public ArrowRight()
        {
            Name = "arrow-right";
            Content = "<path d=\"M224 384v-96H96v-64h128v-96l192 128z\" />";
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
