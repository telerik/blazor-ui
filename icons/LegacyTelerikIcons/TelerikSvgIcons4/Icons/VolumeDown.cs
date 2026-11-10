using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class VolumeDown : SvgIconBase
    {
        public VolumeDown()
        {
            Name = "volume-down";
            Content = "<path d=\"M0 352h96l128 128V32L96 160H0zm288 28V132c55.2 14.2 96 64.3 96 124s-40.8 109.8-96 124\" />";
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
