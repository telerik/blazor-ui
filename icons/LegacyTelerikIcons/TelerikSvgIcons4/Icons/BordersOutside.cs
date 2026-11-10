using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class BordersOutside : SvgIconBase
    {
        public BordersOutside()
        {
            Name = "borders-outside";
            Content = "<path d=\"M128 256H96v-32h32zm64-32h-32v32h32zm64 0h-32v32h32zm0-64h-32v32h32zm0-64h-32v32h32zm0 256h-32v32h32zm0-64h-32v32h32zm64-64h-32v32h32zm64 0h-32v32h32zm64-192v416H32V32zm-32 32H64v352h352z\" />";
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
