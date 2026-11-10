using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class CellSplitHorizontally : SvgIconBase
    {
        public CellSplitHorizontally()
        {
            Name = "cell-split-horizontally";
            Content = "<path d=\"M32 32v416h416V32zm32 32h160v64H64zm160 160h-64v-64h64zM64 160h64v64H64zm0 96h160v64H64zm0 160v-64h160v64zm192-256h64v64h-64zm160 256H256v-64h160zm0-96H256v-64h160zm0-96h-64v-64h64zm0-96H256V64h160z\" />";
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
