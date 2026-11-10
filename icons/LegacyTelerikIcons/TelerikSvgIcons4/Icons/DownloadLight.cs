using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Download instead.", false)]
    public class DownloadLight : SvgIconBase
    {
        public DownloadLight()
        {
            Name = "download-light";
            Content = "<path d=\"M368 256 256 384 144 256h96V32h32v224zm112 192H32v32h448z\" />";
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
