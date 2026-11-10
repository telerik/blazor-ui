using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Dimensions : SvgIconBase
    {
        public Dimensions()
        {
            Name = "dimensions";
            Content = "<path d=\"M320 0H0v512h128V128h384V0zM32 32h64v64H32zm64 352H64v32h32v64H32V320h64zm0-192H64v32h32v64H32V128h64zm128-96V64h-32v32h-64V32h160v64zm256 0h-64V64h-32v32h-64V32h160z\" />";
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
