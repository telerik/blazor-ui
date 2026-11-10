using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Delicious instead.", false)]
    public class DeliciousBox : SvgIconBase
    {
        public DeliciousBox()
        {
            Name = "delicious-box";
            Content = "<path d=\"M480 448V64c0-17.7-14.3-32-32-32H64c-17.7 0-32 14.3-32 32v384c0 17.7 14.3 32 32 32h384c17.7 0 32-14.3 32-32m-224-32V256H96V96h160v160h160v160z\" />";
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
