using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class ColumnFreeze : SvgIconBase
    {
        public ColumnFreeze()
        {
            Name = "column-freeze";
            Content = "<path d=\"M32 32v416h416V32zm128 32v64L96 64zM64 96l96 96v64l-96-96zm0 128 96 96v64l-96-96zm0 192v-64l64 64zm224 0h-96v-96h96zm0-128h-96v-96h96zm-96-128V64h96v96zm224 256h-96v-96h96zm0-128h-96v-96h96zm0-128h-96V64h96z\" />";
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
