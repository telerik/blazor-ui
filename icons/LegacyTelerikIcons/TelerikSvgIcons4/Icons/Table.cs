using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Table : SvgIconBase
    {
        public Table()
        {
            Name = "table";
            Content = "<path d=\"M32 32v416h416V32zm256 32v96h-96V64zm0 128v96h-96v-96zM64 64h96v96H64zm0 128h96v96H64zm0 224v-96h96v96zm128 0v-96h96v96zm224 0h-96v-96h96zm0-128h-96v-96h96zm0-128h-96V64h96z\" />";
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
