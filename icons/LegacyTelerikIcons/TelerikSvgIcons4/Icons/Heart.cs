using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Heart : SvgIconBase
    {
        public Heart()
        {
            Name = "heart";
            Content = "<path d=\"m447.2 256.8-32.8 32.8L256 448 97.6 289.6l-32.8-32.8c-43.7-43.7-43.7-116.3 0-160s114.7-43.7 158.4 0l32.8 32.8 32.8-32.8c43.7-43.7 114.7-43.7 158.4 0s43.7 116.3 0 160\" />";
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
