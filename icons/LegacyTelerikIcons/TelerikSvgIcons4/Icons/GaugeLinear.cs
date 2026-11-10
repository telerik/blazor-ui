using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class GaugeLinear : SvgIconBase
    {
        public GaugeLinear()
        {
            Name = "gauge-linear";
            Content = "<path d=\"M16 164h480v184H16zM90 58h110l-55 74zM16 380h36v74H16zm444 0h36v74h-36zm-222 0h36v74h-36zm-111 0h36v36h-36zm222 0h36v36h-36z\" />";
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
