using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Mobile instead.", false)]
    public class MobileOutline : SvgIconBase
    {
        public MobileOutline()
        {
            Name = "mobile-outline";
            Content = "<path d=\"M384 64v384c0 17.6-14.4 32-32 32H160c-13.57 0-25.24-8.56-29.87-20.56A31.5 31.5 0 0 1 128 448V64c0-4.03.75-7.89 2.13-11.44C134.76 40.56 146.43 32 160 32h192c17.6 0 32 14.4 32 32M160 352h192V64.06l-.06-.06H160.06l-.06.06zm192 32H160v63.94l.06.06h191.88l.06-.06zm-80 32c0-8.84-7.16-16-16-16s-16 7.16-16 16 7.16 16 16 16 16-7.16 16-16\" />";
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
