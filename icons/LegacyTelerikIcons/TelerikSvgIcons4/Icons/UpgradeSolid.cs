using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Upgrade instead.", false)]
    public class UpgradeSolid : SvgIconBase
    {
        public UpgradeSolid()
        {
            Name = "upgrade-solid";
            Content = "<path d=\"M256 32C132.29 32 32 132.29 32 256s100.29 224 224 224 224-100.29 224-224S379.71 32 256 32m32 384h-64v-32h64zm0-160v96h-64v-96h-96L256 96l128 160z\" />";
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
