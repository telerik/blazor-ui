using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Buildings instead.", false)]
    public class BuildingsSolid : SvgIconBase
    {
        public BuildingsSolid()
        {
            Name = "buildings-solid";
            Content = "<path d=\"M448 448V160H256V32H64v416H32v32h448v-32zm-64-128h-32v-32h32zm-32.03-63.76v-32h32v32zM288 288h32v32h-32zm-.03-31.76v-32h32v32zM112 96h32v32h-32zm0 64h32v32h-32zm0 64h32v32h-32zm0 64h32v32h-32zm80 160h-64v-96h64zm16-128h-32v-32h32zm0-64h-32v-32h32zm0-64h-32v-32h32zm0-64h-32V96h32zm80 320v-96h96v96z\" />";
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
