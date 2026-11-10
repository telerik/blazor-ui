using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Launch : SvgIconBase
    {
        public Launch()
        {
            Name = "launch";
            Content = "<path d=\"M96 96v320h96v-32h-64V128h256v64h32V96zm320 160v160H256l57.4-57.4L192 237.3l45.3-45.3 121.4 121.4.5-.5z\" />";
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
