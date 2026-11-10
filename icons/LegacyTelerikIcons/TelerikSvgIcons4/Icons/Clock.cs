using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Clock : SvgIconBase
    {
        public Clock()
        {
            Name = "clock";
            Content = "<path d=\"M256 128h-32v160h160v-32H256zm0-96C132.3 32 32 132.3 32 256s100.3 224 224 224 224-100.3 224-224S379.7 32 256 32m0 416c-105.9 0-192-86.1-192-192S150.1 64 256 64s192 86.1 192 192-86.1 192-192 192\" />";
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
