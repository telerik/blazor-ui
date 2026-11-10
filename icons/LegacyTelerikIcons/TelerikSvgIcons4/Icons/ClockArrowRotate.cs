using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class ClockArrowRotate : SvgIconBase
    {
        public ClockArrowRotate()
        {
            Name = "clock-arrow-rotate";
            Content = "<path d=\"M256 32C132.3 32 32 132.3 32 256h32c0-105.9 86.1-192 192-192s192 86.1 192 192-86.1 192-192 192c-57 0-108.3-25-143.5-64.5L176 320H32v144l57.8-57.8C130.8 451.5 190 480 256 480c123.7 0 224-100.3 224-224S379.7 32 256 32m-32 96v160h160v-32H256V128z\" />";
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
