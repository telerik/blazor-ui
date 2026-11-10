using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Globe instead.", false)]
    public class GlobeOutline : SvgIconBase
    {
        public GlobeOutline()
        {
            Name = "globe-outline";
            Content = "<path d=\"M256 32C132.3 32 32 132.3 32 256s100.3 224 224 224 224-100.3 224-224S379.7 32 256 32M64 256c0-57 24.8-108.2 64.3-143.3.3 1.8 1 3.6 1.9 5.4 11.9 22.1 47.7 92.5 87.8 104.1s38.6 22.2 45 29.9c6.5 7.7-12.2 24.4 5.6 55.9 9.6 13.2 18.3 5.5 22.6 27.6 4.1 21-20.6 95-7.8 110.4-9 1.3-18.1 2-27.4 2-106 0-192-86-192-192m222.4 189.6c10.5-37 41.8-89.2 75.8-98.9 24.4-20.5 23.3-38.8 20.1-55.4-7.6-13.9-41.7-26-74.3-54.8-19.5-4.4-43.4 8.3-52.6-3.9s-52.6-29.9-33.6-49.3 47.7.6 59.1-39.3 35.2-23.2 47.2-23.2S342.2 92 320 81.5c-16.7-7.9-38.6-16.1-71.7-17.4 2.6-.1 5.2-.2 7.8-.2 106 0 192 86 192 192C448 351.7 378 431 286.4 445.6\" />";
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
