using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class MinHeight : SvgIconBase
    {
        public MinHeight()
        {
            Name = "min-height";
            Content = "<path d=\"M240 192H96v32h288v-32zm144 96H96v32h288zM160 448h160l-80-128zm64 0h32v64h-32zm32-384V0h-32v64h-64l80 128 80-128z\" />";
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
