using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Upgrade instead.", false)]
    public class UpgradeOutline : SvgIconBase
    {
        public UpgradeOutline()
        {
            Name = "upgrade-outline";
            Content = "<path d=\"M256 64c51.29 0 99.5 19.97 135.76 56.24C428.02 156.5 448 204.72 448 256s-19.97 99.5-56.24 135.76C355.5 428.02 307.28 448 256 448s-99.5-19.97-135.76-56.24C83.98 355.5 64 307.28 64 256s19.97-99.5 56.24-135.76C156.5 83.98 204.72 64 256 64m0-32C132.29 32 32 132.29 32 256s100.29 224 224 224 224-100.29 224-224S379.71 32 256 32m-32 320h64v-96h96L256 96 128 256h96zm64 32h-64v32h64z\" />";
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
