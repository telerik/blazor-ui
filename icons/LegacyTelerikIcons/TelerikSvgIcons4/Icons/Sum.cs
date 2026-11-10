using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Sum : SvgIconBase
    {
        public Sum()
        {
            Name = "sum";
            Content = "<path d=\"M416 64v128l-64-64H160l128 128-128 128h192l64-64v128H96v-64l128-128L96 128V64z\" />";
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
