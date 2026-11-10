using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Ruler instead.", false)]
    public class RulerSolid : SvgIconBase
    {
        public RulerSolid()
        {
            Name = "ruler-solid";
            Content = "<path d=\"M448.37 192h-48.72v32h-16.04v-32h-31.06v32h-16.03v-32h-32.06v32h-16.04v-32h-32.06v32h-16.03v-32h-32.06v32h-16.04v-32h-32.06v32h-16.03v-32h-32.06v32H96.04v-32H48c-8.84 0-16 7.16-16 16v96c0 8.84 7.16 16 16 16h400.37c8.84 0 16-7.16 16-16v-96c0-8.84-7.16-16-16-16\" />";
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
