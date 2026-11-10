using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class GroupSection : SvgIconBase
    {
        public GroupSection()
        {
            Name = "group-section";
            Content = "<path d=\"m128 416 32 32H32V32h128l-32 32H64v352zm320-288H128v32h320zm0 192H128v32h320zm0-96H128v32h320z\" />";
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
