using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class MinusCircle : SvgIconBase
    {
        public MinusCircle()
        {
            Name = "minus-circle";
            Content = "<path d=\"M256 32C132.3 32 32 132.3 32 256s100.3 224 224 224 224-100.3 224-224S379.7 32 256 32M128 288v-64h256v64z\" />";
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
