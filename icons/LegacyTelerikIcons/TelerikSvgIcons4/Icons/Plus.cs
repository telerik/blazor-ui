using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Plus : SvgIconBase
    {
        public Plus()
        {
            Name = "plus";
            Content = "<path d=\"M288 224V96h-64v128H96v64h128v128h64V288h128v-64z\" />";
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
