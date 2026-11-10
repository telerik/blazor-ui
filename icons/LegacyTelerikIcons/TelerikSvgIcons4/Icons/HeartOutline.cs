using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Heart instead.", false)]
    public class HeartOutline : SvgIconBase
    {
        public HeartOutline()
        {
            Name = "heart-outline";
            Content = "<path d=\"M447.2 96.8c-43.7-43.7-114.7-43.7-158.4 0L256 129.6l-32.8-32.8c-43.7-43.7-114.7-43.7-158.4 0s-43.7 116.3 0 160l32.8 32.8L256 448l158.4-158.4 32.8-32.8c43.7-43.7 43.7-116.3 0-160m-22.6 137.4L256 402.7 87.4 234.2C72.3 219.1 64 198.7 64 176.8s8.3-42.3 23.4-57.4S122.6 96 144 96s41.5 8.3 56.6 23.4l55.4 55.4 55.4-55.4C326.5 104.3 346.6 96 368 96s41.5 8.3 56.6 23.4 23.4 35.5 23.4 57.4-8.3 42.3-23.4 57.4\" />";
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
