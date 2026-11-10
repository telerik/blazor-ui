using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class ArrowsAxes : SvgIconBase
    {
        public ArrowsAxes()
        {
            Name = "arrows-axes";
            Content = "<path d=\"M352 480v-64H128v64H96v-64H32v-32h64V160H32l80-128 80 128h-64v224h224v-64l128 80z\" />";
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
