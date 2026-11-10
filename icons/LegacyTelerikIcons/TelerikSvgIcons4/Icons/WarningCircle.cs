using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class WarningCircle : SvgIconBase
    {
        public WarningCircle()
        {
            Name = "warning-circle";
            Content = "<path d=\"M256 480c123.7 0 224-100.3 224-224S379.7 32 256 32 32 132.3 32 256s100.3 224 224 224m-32-352h64v160h-64zm0 256v-64h64v64z\" />";
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
