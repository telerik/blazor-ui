using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class ArrowLeft : SvgIconBase
    {
        public ArrowLeft()
        {
            Name = "arrow-left";
            Content = "<path d=\"M288 128v96h128v64l-128 .001V384L96 256.001z\" />";
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
