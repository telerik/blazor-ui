using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Lightbulb instead.", false)]
    public class LightbulbOutline : SvgIconBase
    {
        public LightbulbOutline()
        {
            Name = "lightbulb-outline";
            Content = "<path d=\"M304 448c8.836 0 16 7.165 16 16s-7.164 16-16 16h-96c-8.836 0-16-7.165-16-16s7.164-16 16-16zM256 32c88.365 0 160 71.635 160 160 0 48.153-21.31 91.293-54.969 120.625l-22.281 80.063-.031.093c-3.925 13.734-16.497 23.216-30.781 23.219H204.062c-14.279-.006-26.825-9.488-30.749-23.219l-.032-.093L151 312.687C117.313 283.355 96 240.176 96 192c0-88.365 71.635-160 160-160m64.625 306.344C300.855 347.087 279.007 352 256 352c-23.017 0-44.88-4.906-64.656-13.656L204.062 384h103.876zM256 64c-70.692 0-128 57.308-128 128s57.308 128 128 128 128-57.308 128-128S326.692 64 256 64\" />";
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
