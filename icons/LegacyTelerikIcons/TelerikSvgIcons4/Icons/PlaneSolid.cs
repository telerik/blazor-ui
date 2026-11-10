using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Plane instead.", false)]
    public class PlaneSolid : SvgIconBase
    {
        public PlaneSolid()
        {
            Name = "plane-solid";
            Content = "<path d=\"m171.63 304-34.51 63.27A32.09 32.09 0 0 1 108.95 384H32l58-128-58-128h76.92c11.74 0 22.55 6.42 28.17 16.73L171.6 208H240L160 32h76.95c11.74 0 22.55 6.42 28.17 16.73L352 208h80c13.26 0 25.26 5.37 33.94 14.06 9 8.99 14.44 21.54 14.04 35.36-.74 25.64-23.15 46.58-48.8 46.58H352l-86.88 159.27A32.09 32.09 0 0 1 236.95 480H160l80-176z\" />";
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
