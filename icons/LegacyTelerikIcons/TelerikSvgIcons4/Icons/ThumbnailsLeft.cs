using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class ThumbnailsLeft : SvgIconBase
    {
        public ThumbnailsLeft()
        {
            Name = "thumbnails-left";
            Content = "<path d=\"M32 32v96h96V32zm160 0v416h256V32zM32 192v96h96v-96zm0 160v96h96v-96z\" />";
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
