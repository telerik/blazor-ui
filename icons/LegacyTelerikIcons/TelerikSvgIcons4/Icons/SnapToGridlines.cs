using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class SnapToGridlines : SvgIconBase
    {
        public SnapToGridlines()
        {
            Name = "snap-to-gridlines";
            Content = "<path d=\"M160 32H0v416h288V32zm-32 384H32v-96h96zm0-128H32v-96h96zm0-128H32V64h96zm128 256h-96v-96h96zm0-128h-96v-96h96zm0-128h-96V64h96zm256 80c0 44.2-35.8 80-80 80h-32v-32h32c26.5 0 48-21.5 48-48s-21.5-48-48-48h-32v-32h32c44.2 0 80 35.8 80 80m-160-48h32v-32h-32zm0 128h32v-32h-32z\" />";
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
