using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class GroupHeaderSection : SvgIconBase
    {
        public GroupHeaderSection()
        {
            Name = "group-header-section";
            Content = "<path d=\"m128 448 32 32H32V32h128l-32 32H64v384zm320-320H128v96h320zm0 160H128v32h320zm0 64H128v32h320z\" />";
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
