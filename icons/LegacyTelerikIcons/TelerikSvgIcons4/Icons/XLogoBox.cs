using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use XLogo instead.", false)]
    public class XLogoBox : SvgIconBase
    {
        public XLogoBox()
        {
            Name = "x-logo-box";
            Content = "<path d=\"M448 32H64c-17.66 0-32 14.34-32 32v384c0 17.66 14.34 32 32 32h384c17.66 0 32-14.34 32-32V64c0-17.66-14.34-32-32-32m0 416H312.04l-88.02-141L95.06 448H64.04l145.98-158L64 64h135.05l88.97 140L416 64h32L302.55 222.49zM270.45 226.89 185.08 96h-66.05l121.99 189 84.89 131h66.1L283.42 247.48z\" />";
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
