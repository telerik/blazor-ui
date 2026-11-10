using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Tablet instead.", false)]
    public class TabletSolid : SvgIconBase
    {
        public TabletSolid()
        {
            Name = "tablet-solid";
            Content = "<path d=\"M384 32H128c-13.56 0-25.24 8.56-29.88 20.56C96.76 56.1 96 59.96 96 64v384c0 4.02.76 7.88 2.12 11.44 4.64 12 16.32 20.56 29.88 20.56h256c17.6 0 32-14.4 32-32V64c0-17.6-14.4-32-32-32M256 432c-8.84 0-16-7.16-16-16s7.16-16 16-16c1.4 0 2.74.18 4.04.52C266.92 402.3 272 408.56 272 416c0 8.84-7.16 16-16 16m128-80H128V64h256z\" />";
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
