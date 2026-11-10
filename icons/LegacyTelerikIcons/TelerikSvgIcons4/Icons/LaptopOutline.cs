using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Laptop instead.", false)]
    public class LaptopOutline : SvgIconBase
    {
        public LaptopOutline()
        {
            Name = "laptop-outline";
            Content = "<path d=\"M480 384c0 8.84-3.58 16.84-9.37 22.63S456.84 416 448 416H64c-17.67 0-32-14.33-32-32h192v8c0 4.42 3.58 8 8 8h48c4.42 0 8-3.58 8-8v-8zm-64-256H96v192h320zm0-32c17.67 0 32 14.33 32 32v224H64V128c0-17.67 14.33-32 32-32z\" />";
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
