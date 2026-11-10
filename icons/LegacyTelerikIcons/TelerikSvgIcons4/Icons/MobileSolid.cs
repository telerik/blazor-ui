using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Mobile instead.", false)]
    public class MobileSolid : SvgIconBase
    {
        public MobileSolid()
        {
            Name = "mobile-solid";
            Content = "<path d=\"M352 32H160c-13.57 0-25.24 8.56-29.87 20.56A31.5 31.5 0 0 0 128 64v384c0 4.03.75 7.89 2.13 11.44 4.63 12 16.3 20.56 29.87 20.56h192c17.6 0 32-14.4 32-32V64c0-17.6-14.4-32-32-32m-96 400c-8.84 0-16-7.16-16-16s7.16-16 16-16 16 7.16 16 16-7.16 16-16 16m96-80H160V64.06l.06-.06h191.88l.06.06z\" />";
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
