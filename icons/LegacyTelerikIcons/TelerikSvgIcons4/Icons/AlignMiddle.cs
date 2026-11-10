using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class AlignMiddle : SvgIconBase
    {
        public AlignMiddle()
        {
            Name = "align-middle";
            Content = "<path d=\"M480 192H32v-32h448zm-64 32H96v32h320zm64 64H32v32h448z\" />";
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
