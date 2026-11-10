using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class CellSplitVertically : SvgIconBase
    {
        public CellSplitVertically()
        {
            Name = "cell-split-vertically";
            Content = "<path d=\"M32 448h416V32H32zm32-32V256h64v160zm160-160v64h-64v-64zm-64 160v-64h64v64zm96 0V256h64v160zm160 0h-64V256h64zM160 224v-64h64v64zM416 64v160h-64V64zm-96 0v160h-64V64zm-96 0v64h-64V64zm-96 0v160H64V64z\" />";
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
