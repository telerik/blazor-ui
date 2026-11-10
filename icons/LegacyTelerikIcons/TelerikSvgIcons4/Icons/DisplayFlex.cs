using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class DisplayFlex : SvgIconBase
    {
        public DisplayFlex()
        {
            Name = "display-flex";
            Content = "<path d=\"M32 32v448h448V32zm416 416H64V64h384zM128 128h96v256h-96zm160 0h96v256h-96z\" />";
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
