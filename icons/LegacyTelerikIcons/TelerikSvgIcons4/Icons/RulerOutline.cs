using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Ruler instead.", false)]
    public class RulerOutline : SvgIconBase
    {
        public RulerOutline()
        {
            Name = "ruler-outline";
            Content = "<path d=\"M448.37 192H48c-8.84 0-16 7.16-16 16v96c0 8.84 7.16 16 16 16h400.37c8.84 0 16-7.16 16-16v-96c0-8.84-7.16-16-16-16m-16 96H64v-64h32.04v32h16.04v-32h32.06v32h16.03v-32h32.06v32h16.04v-32h32.06v32h16.03v-32h32.06v32h16.04v-32h32.06v32h16.03v-32h31.06v32h16.04v-32h32.72z\" />";
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
