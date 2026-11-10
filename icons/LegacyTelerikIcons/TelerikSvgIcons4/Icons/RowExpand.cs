using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class RowExpand : SvgIconBase
    {
        public RowExpand()
        {
            Name = "row-expand";
            Content = "<path d=\"M32 0h416v480H32zm384 448V160H64v288zM320 32v96h96V32zm-32 0h-96v96h96zM64 32v96h96V32zm192 192v64h64l-80 128-80-128h64v-64\" />";
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
