using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class TableCell : SvgIconBase
    {
        public TableCell()
        {
            Name = "table-cell";
            Content = "<path d=\"M32 32v416h416V32zm128 384H64v-96h96zm0-128H64v-96h96zm0-128H64V64h96zm128 256h-96v-96h96zm0-256h-96V64h96zm128 256h-96v-96h96zm0-128h-96v-96h96zm0-128h-96V64h96z\" />";
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
