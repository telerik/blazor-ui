using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Bell : SvgIconBase
    {
        public Bell()
        {
            Name = "bell";
            Content = "<path d=\"M192 416h128c0 35.3-28.7 64-64 64s-64-28.7-64-64m160-256c0-42-26.9-77.6-64.4-90.7.3-1.7.4-3.5.4-5.3 0-17.7-14.3-32-32-32s-32 14.3-32 32c0 1.8.2 3.6.4 5.3C186.9 82.4 160 118 160 160c0 88.4-43 160-96 160v64h384v-64c-53 0-96-71.6-96-160\" />";
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
